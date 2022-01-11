using Auto.Request;

namespace Console;

internal interface IRequestParser
{
    public UserRequest ParseRequest(string request);
}
