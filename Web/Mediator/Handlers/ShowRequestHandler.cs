using Auto.Interfaces;
using Auto.Product;
using MediatR;
using Web.IO;
using Web.Mediator.Requests;

namespace Web.Mediator.Handlers;

public class ShowRequestHandler : IRequestHandler<ShowRequest, CarProduct[]>
{
    private readonly IUserRequestProcessor _requestProcessor;
    private readonly ILogger _logger;

    public ShowRequestHandler(IUserRequestProcessor requestProcessor, ILogger logger)
    {
        _requestProcessor = requestProcessor;
        _logger = logger;
    }
    public Task<CarProduct[]> Handle(ShowRequest request, CancellationToken cancellationToken)
    {
        var receiver = new CarProductReceiver();

        request.IOProvider = new WebIOProvider(receiver, _logger);

        _requestProcessor.ProcessRequest(request);

        return Task.FromResult(receiver.Cars);
    }
}