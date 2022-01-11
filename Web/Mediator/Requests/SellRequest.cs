using Auto.Request;
using MediatR;
using Web.Mediator.Arguments;

namespace Web.Mediator.Requests;

public class SellRequest : UserRequest, IRequest
{
    public SellRequest(SellRequestArguments arguments) : base(UserRequestType.Sell)
    {
        (Mark, Model, Count) = arguments;
    }
}