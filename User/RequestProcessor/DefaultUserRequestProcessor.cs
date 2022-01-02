using Auto.Interfaces;
using Auto.Request;

namespace User.RequestProcessor;

internal class DefaultUserRequestProcessor : IUserRequestProcessor
{
    public DefaultUserRequestProcessor()
    {
    }
    private static readonly UserRequestType[] _supportedRequestTypes =
    {
            UserRequestType.Help,
    };

    public UserRequest? ProcessRequest(UserRequest request)
    {
        if (_supportedRequestTypes.Contains(request.Type))
        {
            if (request.Type == UserRequestType.Help)
            {
                var help = "buy count (integer) mark (string) model (string)" + Environment.NewLine +
                "example: buy 3 audi x" + Environment.NewLine + Environment.NewLine +
                "sell count (integer) mark (string) model (string)" + Environment.NewLine +
                "example: sell 3 audi x" + Environment.NewLine + Environment.NewLine +
                "show mark (string)" + Environment.NewLine +
                "example: show audi" + Environment.NewLine;



                request.IOProvider.WriteString(help);
            }
            return null;
        }

        return request;
    }
}
