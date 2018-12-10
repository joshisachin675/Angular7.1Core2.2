using DotNetCore.EntityFrameworkCore;
using IDCardScanning.Model.Entities;
using IDCardScanning.Model.Enums;
using IDCardScanning.Model.Models;

namespace IDCardScanning.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public SignedInModel SignIn(SignInModel signInModel)
        {
            return SingleOrDefault<SignedInModel>
            (
                userEntity => userEntity.Login.Equals(signInModel.Login)
                && userEntity.Password.Equals(signInModel.Password)
                && userEntity.Status == Status.Active
            );
        }
    }
}
