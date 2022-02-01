using Auto.Request;
using MediatR;
using Web.Mediator.Arguments;

namespace Web.Mediator.Requests
{
    public class AddRequest : UserRequest, IRequest
    {
        public AddRequest(AddRequestArguments arguments) : base(UserRequestType.Add)
        {
            (Mark, Model, Count, Price) = arguments;
        }
    }
}
