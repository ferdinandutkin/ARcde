using MediatR;
using Web.Mediator.Arguments;
using Web.Mediator.Requests;

namespace Web.Mediator.Handlers
{
    public class GetModelsRequestHandler : IRequestHandler<GetModelsRequest, string[]>
    {
        private readonly IMediator _mediator;

        public GetModelsRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<string[]> Handle(GetModelsRequest request, CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new ShowRequest(new(request.Mark)));
            return products.Select(product => product.Subject.Model).ToArray();
        }
    }
}
