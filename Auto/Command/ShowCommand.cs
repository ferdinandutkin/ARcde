using Auto.Command.Arguments;
using Auto.Interfaces;


namespace Auto.Command;

internal class ShowCommand : ICommand
{
    private readonly BranchOffice[] _branchOffices;
    private readonly ShowCommandArguments _arguments;

    public ShowCommand(BranchOffice[] branchOffices, ShowCommandArguments arguments)
    {
        _branchOffices = branchOffices;
        _arguments = arguments;
    }


    public void Execute()
    {
        _arguments.IOProvider.Write(_branchOffices.SelectMany(office => office.Products).ToArray());
    }


}
