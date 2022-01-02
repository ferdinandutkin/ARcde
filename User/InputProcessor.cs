using Auto.Interfaces;
using Shared.IO;

namespace User;

internal class InputProcessor
{
    private readonly IIOProvider _ioProvider;
    private readonly IRequestParser _requestParser;
    private readonly IUserRequestProcessor _requestProcessor;


    public InputProcessor(IRequestParser requestParser, IUserRequestProcessor requestProcessor, IIOProvider? ioProvider = null)
    {
        _ioProvider = ioProvider ?? IOProvider.Instance;
        _requestParser = requestParser;
        _requestProcessor = requestProcessor;

    }
    public void Start()
    {
        while (true)
        {
            try
            {
                var input = _ioProvider.ReadString();

                var request = _requestParser.ParseRequest(input);

                var unprocessed = _requestProcessor.ProcessRequest(request);

                if (unprocessed is not null)
                {
                    _ioProvider.WriteString("Unsupported request type. No request proccessor was able to process it");
                }
            }
            catch (Exception e)
            {
                _ioProvider.WriteString(e.Message);
            }

        }
    }
}
