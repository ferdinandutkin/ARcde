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
    public IRollbackCommand? CreateInstance(UserRequest officeName)
    {
        return new SellCommand(_branchOffice, new SellCommandArguments(officeName.Model, officeName.Count));
    }
}
