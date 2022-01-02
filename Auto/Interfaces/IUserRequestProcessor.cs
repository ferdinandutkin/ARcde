using Auto.Request;

namespace Auto.Interfaces;

public interface IUserRequestProcessor
{
    UserRequest? ProcessRequest(UserRequest request);
}
