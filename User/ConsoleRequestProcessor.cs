using Auto;
using Auto.Interfaces;
using IO.RequestProcessor;

namespace Console
{
    internal class ConsoleRequestProcessor : CompositeRequestProcessor
    {
        public ConsoleRequestProcessor(HeadOffice headOffice) : base(new IUserRequestProcessor[]{new HeadOfficeUserRequestProcessor(headOffice), new DefaultUserRequestProcessor()})
        {
        }
    }
}
