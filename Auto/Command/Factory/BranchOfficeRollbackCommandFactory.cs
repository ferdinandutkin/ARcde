using Auto.Interfaces;
using Auto.Request;

namespace Auto.Command.Factory;

internal class BranchOfficeRollbackCommandFactory : IFactory<UserRequest, IRollbackCommand>
{
    private readonly IReadOnlyCollection<BranchOffice> _branchOffices;

    internal BranchOfficeRollbackCommandFactory(IReadOnlyCollection<BranchOffice> branchOffices)
    {
        _branchOffices = branchOffices;
    }


    public IRollbackCommand? CreateInstance(UserRequest userRequest)
    {
        var branchOffice = _branchOffices.Where(branchOffice => branchOffice.Mark == userRequest.Mark).FirstOrDefault();

        ArgumentNullException.ThrowIfNull(branchOffice, "branch office not found unknown car mark");

        IFactory<UserRequest, IRollbackCommand>? factory = userRequest.Type switch
        {
            UserRequestType.Sell => new BuyCommandFactory(branchOffice),
            UserRequestType.Buy => new SellCommandFactory(branchOffice),
            _ => null,
        };

        return factory?.CreateInstance(userRequest);
    }
}
