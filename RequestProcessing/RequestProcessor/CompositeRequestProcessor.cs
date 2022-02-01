using Auto.Interfaces;
using Auto.Request;

namespace IO.RequestProcessor
{
    public class CompositeRequestProcessor : IUserRequestProcessor
    {
        private readonly IUserRequestProcessor[] _processors;

        public CompositeRequestProcessor(IUserRequestProcessor[] processors)
        {
            _processors = processors;
        }

        public UserRequest? ProcessRequest(UserRequest request)
        => _processors.Select(processor => processor.ProcessRequest(request))
            .Any(unprocessed => unprocessed is null) ? null : request;

    }
}
