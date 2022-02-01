using Auto.Request;
using MediatR;
using Web.Mediator.Arguments;

namespace Web.Mediator.Requests;

public class RemoveRequest : UserRequest, IRequest
{
    public RemoveRequest(RemoveRequestArguments arguments) : base(UserRequestType.Remove)
    {
        (Mark, Model) = arguments;
    }
}