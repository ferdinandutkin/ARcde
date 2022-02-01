using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto.Command.Arguments;
using Auto.Interfaces;
using Auto.Request;

namespace Auto.Command.Factory
{
    internal class RemoveCommandFactory : IFactory<UserRequest, ICommand>
    {
        private readonly BranchOffice _branchOffice;

        public RemoveCommandFactory(BranchOffice branchOffice)
        {
            _branchOffice = branchOffice;
        }

        public ICommand? CreateInstance(UserRequest userRequest)
            => new RemoveCommand(_branchOffice,
                new RemoveCommandArguments(userRequest.Model, userRequest.Count, userRequest.Price));
    }
}
