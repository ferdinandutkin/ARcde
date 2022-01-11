using Auto.Request;
using MediatR;
using Web.Mediator.Arguments;

namespace Web.Mediator.Requests;

public class BuyRequest : UserRequest, IRequest
{
    public BuyRequest(BuyRequestArguments arguments) : base(UserRequestType.Buy)
    {
        (Mark, Model, Count) = arguments;
    }
}