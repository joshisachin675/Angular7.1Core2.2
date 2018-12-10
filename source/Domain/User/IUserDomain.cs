using DotNetCore.Objects;
using IDCardScanning.Model.Models;
using System.Collections.Generic;

namespace IDCardScanning.Domain
{
    public interface IUserDomain
    {
        PagedList<UserModel> List(PagedListParameters parameters);

        IEnumerable<UserModel> List();

        UserModel Select(long userId);
    }
}
