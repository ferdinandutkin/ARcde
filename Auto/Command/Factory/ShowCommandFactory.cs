using Auto.Interfaces;
using Auto.Request;

namespace Auto.Command.Factory;

internal class ShowCommandFactory : IFactory<UserRequest, ICommand>
{
    private readonly BranchOffice[] _branchOffices;

    public ShowCommandFactory(BranchOffice branchOffice)
    {
        _branchOffices = new[] { branchOffice };
    }

    public ShowCommandFactory(IReadOnlyCollection<BranchOffice> offices)
    {
        _branchOffices = offices.ToArray();
    }
    public ICommand? CreateInstance(UserRequest userRequest)
    {
        return new ShowCommand(_branchOffices, new Arguments.ShowCommandArguments(userRequest.IOProvider));
    }
}
