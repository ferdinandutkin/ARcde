using Auto.Command.Factory;
using Auto.Interfaces;
using Auto.Repository;
using Auto.Request;
using Microsoft.Extensions.Logging;
using Shared.IO;
using Shared.Logging;

namespace Auto;

public class HeadOffice 
{
    private const int transactionSize = 10;

    private readonly Transaction _transaction;

    private readonly IReadOnlyCollection<BranchOffice> _branchOffices = new List<BranchOffice>
    {
            new("audi", BranchOfficeRepository.CreateInstance("audi")),
            new("bmw", BranchOfficeRepository.CreateInstance("bmw"))
    };

    private readonly IFactory<UserRequest, ICommand> _commandFactory;

    private readonly IFactory<UserRequest, IRollbackCommand> _rollbackCommandFactory;

    private readonly ILogger _logger;
    private readonly IIOProvider _ioProvider;

    public HeadOffice(ILogger? logger = null,  IIOProvider? ioProvider = null)
    {
        _logger = logger ?? Logger.Instance;
        _ioProvider = ioProvider ?? IOProvider.Instance;
        
        _rollbackCommandFactory = new BranchOfficeRollbackCommandFactory(_branchOffices);
        _commandFactory = new BranchOfficeCommandFactory(_branchOffices);

        _transaction = new(_logger);
        _transaction.CommandQueueSizeChanged += CommandQueueSizeChanged;
       
    }

    private void CommandQueueSizeChanged(int newSize)
    {
        if (newSize >= transactionSize)
        {
            _transaction.Execute();
        }
    }

    public void ProcessRequest(UserRequest request)
    {

        ICommand? command = _commandFactory.CreateInstance(request);

        if (command is not null)
        {
            command.Execute();
            return;
        }
        
        IRollbackCommand? rollbackCommand = _rollbackCommandFactory.CreateInstance(request);

        if (rollbackCommand is not null)
        {
            _transaction.PushCommand(rollbackCommand);
            return;
        }

        throw new ArgumentException("Unable to create command from provided arguments");
    }

}
