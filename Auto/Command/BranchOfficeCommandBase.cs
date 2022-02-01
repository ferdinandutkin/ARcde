using Auto.Interfaces;

namespace Auto.Command;

abstract class BranchOfficeCommandBase : IRollbackCommand
{
    protected BranchOffice Office;
    protected BranchOfficeCommandBase(BranchOffice office) => Office = office;

    public abstract void Execute();

    public abstract void Rollback();

}
