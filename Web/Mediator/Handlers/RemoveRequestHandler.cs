using Auto.Interfaces;
using Auto.Request;
using MediatR;
using Web.Mediator.Arguments;
using Web.Mediator.Requests;

namespace Web.Mediator.Handlers
{
    public class RemoveRequestHandler : IRequestHandler<RemoveRequest>
    {
        private readonly IUserRequestProcessor _requestProcessor;
        private readonly IMediator _mediator;

        public RemoveRequestHandler(IUserRequestProcessor requestProcessor, IMediator mediator)
        {
            _requestProcessor = requestProcessor;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(RemoveRequest request, CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new ShowRequest(new(request.Mark)));

            var toRemove = products.FirstOrDefault(product => product.Subject.Model == request.Model);

            _requestProcessor.ProcessRequest(new UserRequest(UserRequestType.Remove)
            {
                Mark = request.Mark,
                Model = request.Model,
                Count = toRemove.Count,
                Price = toRemove.Price
            });

            return Unit.Value;
        }
    
    }
}
