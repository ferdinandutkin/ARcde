using Auto.Command.Arguments;
using Auto.Interfaces;
using Auto.Request;

namespace Auto.Command.Factory;

internal class BuyCommandFactory : IFactory<UserRequest, IRollbackCommand>
{
    private readonly BranchOffice _branchOffice;

    public BuyCommandFactory(BranchOffice branchOffice)
    {
        _branchOffice = branchOffice;
    }
    public IRollbackCommand? CreateInstance(UserRequest officeName)
    {
        return new BuyCommand(_branchOffice, new BuyCommandArguments(officeName.Model, officeName.Count));
    }
}
