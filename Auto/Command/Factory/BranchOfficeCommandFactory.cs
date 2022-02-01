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
        var branchOffice = _branchOffices.FirstOrDefault(branchOffice => branchOffice.Mark == userRequest.Mark);

        if (userRequest.Type != UserRequestType.Show)
        {
            OfficeNotFoundException.ThrowIfNull(branchOffice, userRequest.Mark);
        }


        IFactory<UserRequest, ICommand>? factory = userRequest.Type switch
        {
            UserRequestType.Show when branchOffice is null => new ShowCommandFactory(_branchOffices),
            UserRequestType.Show => new ShowCommandFactory(branchOffice!),
            UserRequestType.Add => new AddCommandFactory(branchOffice!),
            UserRequestType.Remove => new RemoveCommandFactory(branchOffice!),
            _ => null
        };

        return factory?.CreateInstance(userRequest);
    }
}
