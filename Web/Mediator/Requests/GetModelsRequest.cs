using MediatR;
using Web.Mediator.Arguments;

namespace Web.Mediator.Requests
{
    public class GetModelsRequest : IRequest<string[]>
    {
        public string Mark { get; }
        public GetModelsRequest(GetModelsRequestArguments arguments)
        {
            Mark = arguments.Mark;
        }
    }
}
