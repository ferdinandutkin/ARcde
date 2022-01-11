using Auto.Command.Factory;
using Auto.Interfaces;
using Auto.IO;
using Auto.Request;
using Microsoft.Extensions.Logging;

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

            _transaction = new(_ioProvider, _logger);
            _transaction.CommandQueueSizeChanged += CommandQueueSizeChanged;
        }
        public UserRequest? ProcessRequest(UserRequest request)
        {

            ICommand? command = _commandFactory.CreateInstance(request);


            if (command is not null)
            {
                _logger.LogDebug($"command {command} created");
                command.Execute();
                return null;
            }

            IRollbackCommand? rollbackCommand = _rollbackCommandFactory.CreateInstance(request);

            if (rollbackCommand is not null)
            {
                _logger.LogDebug($"rollback command {rollbackCommand} created");
                _transaction.PushCommand(rollbackCommand);
                return null;
            }

            return request;
        }


    }
}