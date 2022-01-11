using Auto.Product;
using Auto.Request;
using MediatR;
using Web.Mediator.Arguments;

namespace Web.Mediator.Requests;

public class ShowRequest : UserRequest, IRequest<CarProduct[]>
{
    public ShowRequest(ShowRequestArguments arguments) : base(UserRequestType.Show)
    {
        Mark = arguments.Mark;
    }
}