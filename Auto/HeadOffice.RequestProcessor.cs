using Auto.Command.Factory;
using Auto.Interfaces;
using Auto.Request;
using Microsoft.Extensions.Logging;
using Shared.IO;

namespace Auto;

public partial class HeadOffice
{
    private class RequestProcessor : IUserRequestProcessor
    {
        private const int transactionSize = 10;

        private readonly Transaction _transaction;
        private readonly IFactory<UserRequest, ICommand> _commandFactory;
        private readonly IFactory<UserRequest, IRollbackCommand> _rollbackCommandFactory;

        private readonly ILogger _logger;
        private readonly IIOProvider _ioProvider;

        private void CommandQueueSizeChanged(int newSize)
        {
            if (newSize >= transactionSize)
            {
                _transaction.Execute();
            }
        }

        public RequestProcessor(ILogger logger, IIOProvider ioProvider, IReadOnlyCollection<BranchOffice> branchOffices)
        {
            _logger = logger;
            _ioProvider = ioProvider;
            _rollbackCommandFactory = new BranchOfficeRollbackCommandFactory(branchOffices);
            _commandFactory = new BranchOfficeCommandFactory(branchOffices);

            _transaction = new(_logger);
            _transaction.CommandQueueSizeChanged += CommandQueueSizeChanged;
        }
        public UserRequest? ProcessRequest(UserRequest request)
        {

            ICommand? command = _commandFactory.CreateInstance(request);

            if (command is not null)
            {
                command.Execute();
                return null;
            }

            IRollbackCommand? rollbackCommand = _rollbackCommandFactory.CreateInstance(request);

            if (rollbackCommand is not null)
            {
                _transaction.PushCommand(rollbackCommand);
                return null;
            }

            return request;
        }


    }
}