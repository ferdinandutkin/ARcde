using Auto.Request;
using Shared.IO;
using Sprache;

namespace User
{
    internal class RequestParser : IRequestParser
    {


        private static readonly Parser<int> _intParser = Parse.Char('-')
            .Token()
            .Optional()
            .SelectMany(op => Parse.Number, (op, num) => int.Parse(num) * (op.IsDefined ? -1 : 1));


        private static readonly Parser<UserRequestType> _typeParser =
                            from leading in Parse.WhiteSpace.Many()
                            from type in Parse.Letter.Many().Text()
                            from trailing in Parse.WhiteSpace.Many()
                            select Enum.Parse<UserRequestType>(type, true);

        private static readonly Parser<string> _showRequestBodyParser =
            from leading in Parse.WhiteSpace.Many()
            from mark in Parse.LetterOrDigit.Many().Text()
            from trailing in Parse.WhiteSpace.Many()
            select mark;


        private static readonly Parser<(int count, string mark, string model)> _buySellRequestBodyParser =
            from leading in Parse.WhiteSpace.Many()
            from count in _intParser
            from middle in Parse.WhiteSpace.Many()
            from mark in Parse.LetterOrDigit.Many().Text()
            from middle1 in Parse.WhiteSpace.Many()
            from model in Parse.LetterOrDigit.Many().Text()
            from trailing in Parse.WhiteSpace.Many()
            select (count, mark, model);


        public static Parser<UserRequestType> ExactTypeParser(UserRequestType type)
            => Parse.IgnoreCase(type.ToString()).Text().Select(type => _typeParser.Parse(type));


        private static readonly Parser<UserRequest> _showRequestParser =
             ExactTypeParser(UserRequestType.Show).Then(type => _showRequestBodyParser.Select(body => new UserRequest(type) { Mark = body, IOProvider = IOProvider.Instance }));


        private static readonly Parser<UserRequest> _buySellRequestParser
            = ExactTypeParser(UserRequestType.Buy).Or(ExactTypeParser(UserRequestType.Sell))
            .Then(type => _buySellRequestBodyParser.Select(body => new UserRequest(type) { Count = body.count, Model = body.model, Mark = body.mark }));


        private static readonly Parser<UserRequest> _helpRequestParser
           = ExactTypeParser(UserRequestType.Help).Then(type => Parse.Return(new UserRequest(type) { IOProvider = IOProvider.Instance }));



        private static readonly Parser<UserRequest> _requestParser = _buySellRequestParser.Or(_showRequestParser).Or(_helpRequestParser);

        public UserRequest ParseRequest(string input) => _requestParser.Parse(input);
    }
}
