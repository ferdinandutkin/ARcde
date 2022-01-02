using Auto.Exceptions;
using Auto.Interfaces;
using Auto.Request;


namespace Auto.Command.Factory;

internal class BranchOfficeCommandFactory : IFactory<UserRequest, ICommand>
{
    private readonly IReadOnlyCollection<BranchOffice> _branchOffices;

    internal BranchOfficeCommandFactory(IReadOnlyCollection<BranchOffice> branchOffices)
    {
        _branchOffices = branchOffices;
    }

    public ICommand? CreateInstance(UserRequest officeName)
    {
        var branchOffice = _branchOffices.Where(branchOffice => branchOffice.Mark == officeName.Mark).FirstOrDefault();

        OfficeNotFoundException.ThrowIfNull(branchOffice, officeName.Mark);

        var factory = officeName.Type switch
        {
            UserRequestType.Show => new ShowCommandFactory(branchOffice!),
            _ => null
        };

        return factory?.CreateInstance(officeName);
    }
}
