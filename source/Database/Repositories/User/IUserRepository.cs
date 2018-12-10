using DotNetCore.Repositories;
using IDCardScanning.Model.Entities;
using IDCardScanning.Model.Models;

namespace IDCardScanning.Database
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        SignedInModel SignIn(SignInModel signInModel);
    }
}
