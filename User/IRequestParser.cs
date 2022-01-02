using Auto.Request;

namespace User;

internal interface IRequestParser
{
    public UserRequest ParseRequest(string request);
}
