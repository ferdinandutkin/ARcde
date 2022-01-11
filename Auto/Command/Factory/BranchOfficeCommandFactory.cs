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

    public ICommand? CreateInstance(UserRequest userRequest)
    {
        var branchOffice = _branchOffices.Where(branchOffice => branchOffice.Mark == userRequest.Mark).FirstOrDefault();

        OfficeNotFoundException.ThrowIfNull(branchOffice, userRequest.Mark);

        var factory = userRequest.Type switch
        {
            UserRequestType.Show => new ShowCommandFactory(branchOffice!),
            _ => null
        };

        return factory?.CreateInstance(userRequest);
    }
}
