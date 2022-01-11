using Auto.IO;
using Auto.Product;
using Web.Mediator;

namespace Web.IO
{
    public class WebIOProvider : IIOProvider
    {
        private readonly CarProductReceiver _carProductReceiver;
        private readonly ILogger _logger;

        public WebIOProvider(CarProductReceiver carProductReceiver, ILogger logger)
        {
            _carProductReceiver = carProductReceiver;
            _logger = logger;
        }
        public void Write(CarProduct[] cars)
        {
            _carProductReceiver.Cars = cars;
        }

        public string ReadString()
        {
            throw new NotImplementedException();
        }

        public void Write(string @string)
        {
            _logger.LogInformation(@string);
        }
    }
}
