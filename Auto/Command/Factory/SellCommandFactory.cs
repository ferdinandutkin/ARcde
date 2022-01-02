using Auto.Command.Arguments;
using Auto.Interfaces;
using Auto.Request;

namespace Auto.Command.Factory;

internal class SellCommandFactory : IFactory<UserRequest, IRollbackCommand>
{
    private readonly BranchOffice _branchOffice;

    public SellCommandFactory(BranchOffice branchOffice)
    {
        this._branchOffice = branchOffice;
    }
    public IRollbackCommand? CreateInstance(UserRequest args)
    {
        return new SellCommand(_branchOffice, new SellCommandArguments(args.Model, args.Count));
    }
}
