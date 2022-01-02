using Auto.Command.Arguments;

namespace Auto.Command;

class BuyCommand : BranchOfficeCommandBase
{
    private readonly BuyCommandArguments _arguments;

    public BuyCommand(BranchOffice branchOffice, BuyCommandArguments arguments) : base(branchOffice)
        => _arguments = arguments;

    public override void Execute() => Office.Buy(_arguments.Model, _arguments.Count);
    public override void Rollback() => Office.Sell(_arguments.Model, _arguments.Count);

}
