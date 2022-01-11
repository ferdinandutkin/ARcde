using Auto.Command.Factory;
using Auto.Interfaces;
using Auto.IO;
using Auto.Product;
using Auto.Request;
using Microsoft.Extensions.Logging;
using Shared.Logging;

namespace Auto;

public partial class HeadOffice 
{
    private readonly IReadOnlyCollection<BranchOffice> _branchOffices;
    private readonly IUserRequestProcessor _requestProcessor;

    private readonly ILogger _logger;
    private readonly IIOProvider _ioProvider;

    public HeadOffice(IFactory<string, IRepository<CarProduct>> repositoryFactory, IIOProvider ioProvider, ILogger? logger = null)
    {
        
        _branchOffices = new List<BranchOffice>
        {
            new("audi", repositoryFactory.CreateInstance("audi")),
            new("bmw", repositoryFactory.CreateInstance("bmw"))
        };
        
        _logger = logger ?? Logger.Instance;
        _ioProvider = ioProvider;

        _requestProcessor = new RequestProcessor(logger, ioProvider, _branchOffices);

    }



    public void ProcessRequest(UserRequest request)
    {
        var unprocessed = _requestProcessor.ProcessRequest(request);
        if (unprocessed is not null)
        {
            throw new ArgumentException("Unable to create command from provided arguments");
        }
    }

}
