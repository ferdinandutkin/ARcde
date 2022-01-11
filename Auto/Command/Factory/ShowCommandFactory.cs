﻿using Auto.Interfaces;
using Auto.Request;

namespace Auto.Command.Factory;

internal class ShowCommandFactory : IFactory<UserRequest, ICommand>
{
    private readonly BranchOffice _branchOffice;

    public ShowCommandFactory(BranchOffice branchOffice)
    {
        _branchOffice = branchOffice;
    }
    public ICommand? CreateInstance(UserRequest userRequest)
    {
        return new ShowCommand(_branchOffice, new Arguments.ShowCommandArguments(userRequest.IOProvider));
    }
}
