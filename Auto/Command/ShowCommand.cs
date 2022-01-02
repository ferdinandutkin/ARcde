using Auto.Command.Arguments;
using Auto.Interfaces;


namespace Auto.Command;

internal class ShowCommand : ICommand
{
    private readonly BranchOffice _branchOffice;
    private readonly ShowCommandArguments _arguments;

    public ShowCommand(BranchOffice branchOffice, ShowCommandArguments arguments)
    {
        _branchOffice = branchOffice;
        _arguments = arguments;
    }
    public void Execute()
    {
        _arguments.IOProvider.WriteString(string.Join(Environment.NewLine, _branchOffice.Products));
    }


}
