using Auto.Interfaces;
using Auto.Request;
using MediatR;

namespace Web.Mediator.Handlers;

public class UserRequestHandler<T> : IRequestHandler<T> where T : UserRequest, IRequest
{
    private readonly IUserRequestProcessor _requestProcessor;

    public UserRequestHandler(IUserRequestProcessor requestProcessor)
    {
        _requestProcessor = requestProcessor;
    }
    public Task<Unit> Handle(T request, CancellationToken cancellationToken)
    {
        _requestProcessor.ProcessRequest(request);
        return Task.FromResult(Unit.Value);
    }
}