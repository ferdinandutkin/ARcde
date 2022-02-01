using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto.Command.Arguments;
using Auto.Interfaces;

namespace Auto.Command;

internal class AddCommand : ICommand
{
    private readonly AddCommandArguments _arguments;
    private readonly BranchOffice _branchOffice;

    public AddCommand(BranchOffice branchOffice, AddCommandArguments arguments)
    {
        _arguments = arguments;
        _branchOffice = branchOffice;
    }

    public void Execute()
    {
        _branchOffice.Add(_arguments.Model, _arguments.Count, _arguments.Price);
    }
}