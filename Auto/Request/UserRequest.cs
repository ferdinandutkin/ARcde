using Auto.IO;

namespace Auto.Request;

public class UserRequest
{
    public string Mark { get; set; }
    public UserRequestType Type { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public string Model { get; set; }
    public IIOProvider IOProvider { get; set; } 
    public UserRequest(UserRequestType type) => Type = type;

}
