using Auto.Command.Factory;
using Auto.Interfaces;
using Auto.Product;
using Auto.Request;
using Microsoft.Extensions.Logging;
using Shared.IO;
using Shared.Logging;

namespace Auto;

public class HeadOffice 
{
    private const int transactionSize = 10;
    private readonly Transaction _transaction;
    private readonly IFactory<string, IRepository<CarProduct>> _repositoryFactory;
    private readonly IReadOnlyCollection<BranchOffice> _branchOffices;
    private readonly IFactory<UserRequest, ICommand> _commandFactory;
    private readonly IFactory<UserRequest, IRollbackCommand> _rollbackCommandFactory;
    private readonly ILogger _logger;
    private readonly IIOProvider _ioProvider;

    public HeadOffice(IFactory<string, IRepository<CarProduct>> repositoryFactory, ILogger? logger = null,  IIOProvider? ioProvider = null)
    {
        _repositoryFactory = repositoryFactory;
        
        _branchOffices = new List<BranchOffice>
        {
            new("audi", _repositoryFactory.CreateInstance("audi")),
            new("bmw", _repositoryFactory.CreateInstance("bmw"))
        };
        
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
