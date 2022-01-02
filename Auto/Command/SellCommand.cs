using Auto.Command.Arguments;

namespace Auto.Command;

class SellCommand : BranchOfficeCommandBase
{
    private readonly SellCommandArguments _arguments;

    public SellCommand(BranchOffice branchOffice, SellCommandArguments arguments) : base(branchOffice)
        => _arguments = arguments;

    public override void Execute() => Office.Sell(_arguments.Model, _arguments.Count);
    public override void Rollback() => Office.Buy(_arguments.Model, _arguments.Count);

}
