namespace Auto.Exceptions;

internal class OfficeNotFoundException : Exception
{
    public OfficeNotFoundException()
    {
    }

    public OfficeNotFoundException(string name)
        : base(name)
    {
    }

    public OfficeNotFoundException(string name, Exception inner)
        : base(name, inner)
    {
    }

    public static void ThrowIfNull(BranchOffice? branchOffice, string name)
    {
        if (branchOffice is null)
        {
            throw new OfficeNotFoundException($"No office named {name} was found");
        }
    }
}
