using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto.Command.Arguments;
using Auto.Interfaces;

namespace Auto.Command
{
    internal class RemoveCommand : ICommand
    {
        private readonly BranchOffice _branchOffice;
        private readonly RemoveCommandArguments _arguments;

        public RemoveCommand(BranchOffice branchOffice, RemoveCommandArguments arguments)
        {
            _branchOffice = branchOffice;
            _arguments = arguments;
        }

        public void Execute() => _branchOffice.Remove(_arguments.Model);

    }

}
