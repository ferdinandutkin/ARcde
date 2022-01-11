using Auto.Interfaces;
using Auto.IO;
using Console.IO;

namespace Console;

internal class InputProcessor
{
    private readonly IIOProvider _ioProvider;
    private readonly IRequestParser _requestParser;
    private readonly IUserRequestProcessor _requestProcessor;


    public InputProcessor(IRequestParser requestParser, IUserRequestProcessor requestProcessor, IIOProvider? ioProvider = null)
    {
        _ioProvider = ioProvider ?? new ConsoleIOProvider();
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
                    _ioProvider.Write("Unsupported request type. No request processor was able to process it");
                }
            }
            catch (Exception e)
            {
                _ioProvider.Write(e.Message);
            }

        }
    }
}
