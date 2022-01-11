using Auto;
using Auto.Interfaces;
using Auto.Request;

namespace User.RequestProcessor;



internal class UserRequestProcessor : IUserRequestProcessor
{

    private readonly DefaultUserRequestProcessor _defaultUserRequestProcessor;
    private readonly HeadOfficeUserRequestProcessor _headOfficeUserRequestProcessor;
    public UserRequestProcessor(HeadOffice headOffice)
    {

        _defaultUserRequestProcessor = new();
        _headOfficeUserRequestProcessor = new(headOffice);
    }
    public UserRequest? ProcessRequest(UserRequest request)
    {
        var defResult = _defaultUserRequestProcessor.ProcessRequest(request);
        if (defResult is null)
            return null;

        var headOfficeResult = _headOfficeUserRequestProcessor.ProcessRequest(request);
        if (headOfficeResult is null)
            return null;

        return headOfficeResult;

    }
}
