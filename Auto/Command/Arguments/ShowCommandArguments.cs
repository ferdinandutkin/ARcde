using Auto.IO;

namespace Auto.Command.Arguments;

internal class ShowCommandArguments
{
    public ShowCommandArguments(IIOProvider IOProvider) => this.IOProvider = IOProvider;

    public IIOProvider IOProvider { get; }
}
