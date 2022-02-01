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
    internal class AddCommandFactory : IFactory<UserRequest, ICommand>
    {
        private readonly BranchOffice _branchOffice;

        public AddCommandFactory(BranchOffice branchOffice)
        {
            _branchOffice = branchOffice;
        }

        public ICommand? CreateInstance(UserRequest userRequest)
            => new AddCommand(_branchOffice,
                new AddCommandArguments(userRequest.Model, userRequest.Count, userRequest.Price));
    }
}
