using Auto;
using Auto.Interfaces;
using Auto.Request;

namespace IO.RequestProcessor;
public class HeadOfficeUserRequestProcessor : IUserRequestProcessor
{
    private readonly HeadOffice _headOffice;

    private static readonly UserRequestType[] _supportedRequestTypes =
    {
            UserRequestType.Buy,
            UserRequestType.Sell,
            UserRequestType.Show,
            UserRequestType.Remove,
            UserRequestType.Add,
    };

    public HeadOfficeUserRequestProcessor(HeadOffice headOffice) => _headOffice = headOffice;
    public UserRequest? ProcessRequest(UserRequest request)
    {
        if (_supportedRequestTypes.Contains(request.Type))
        {
            _headOffice.ProcessRequest(request);
            return null;
        }
        return request;
    }
}
