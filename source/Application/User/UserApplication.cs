using DotNetCore.Objects;
using IDCardScanning.Domain;
using IDCardScanning.Model.Models;
using System.Collections.Generic;

namespace IDCardScanning.Application
{
    public sealed class UserApplication : IUserApplication
    {
        public UserApplication(IUserDomain userDomain)
        {
            UserDomain = userDomain;
        }

        private IUserDomain UserDomain { get; }

        public PagedList<UserModel> List(PagedListParameters parameters)
        {
            return UserDomain.List(parameters);
        }

        public IEnumerable<UserModel> List()
        {
            return UserDomain.List();
        }

        public UserModel Select(long userId)
        {
            return UserDomain.Select(userId);
        }
    }
}
