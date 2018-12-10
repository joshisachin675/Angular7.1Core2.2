using DotNetCore.Security;
using IDCardScanning.Database;
using IDCardScanning.Model.Enums;
using IDCardScanning.Model.Models;
using IDCardScanning.Model.Validators;

namespace IDCardScanning.Domain
{
    public sealed class AuthenticationDomain : IAuthenticationDomain
    {
        public AuthenticationDomain(
            IHash hash,
            IJsonWebToken jsonWebToken,
            IUserLogDomain userLogDomain,
            IUserRepository userRepository)
        {
            Hash = hash;
            JsonWebToken = jsonWebToken;
            UserLogDomain = userLogDomain;
            UserRepository = userRepository;
        }

        private IHash Hash { get; }
        private IJsonWebToken JsonWebToken { get; }
        private IUserLogDomain UserLogDomain { get; }
        private IUserRepository UserRepository { get; }

        public string SignIn(SignInModel signInModel)
        {
            new SignInModelValidator().ValidateThrow(signInModel);

            TransformLoginAndPasswordToHash(signInModel);

            var signedInModel = UserRepository.SignIn(signInModel);
            new SignedInModelValidator().ValidateThrow(signedInModel);

            var userLogModel = new UserLogModel(signedInModel.UserId, LogType.Login);
            UserLogDomain.Save(userLogModel);

            return CreateJwt(signedInModel);
        }

        public void SignOut(SignOutModel signOutModel)
        {
            var userLogModel = new UserLogModel(signOutModel.UserId, LogType.Logout);
            UserLogDomain.Save(userLogModel);
        }

        private string CreateJwt(SignedInModel signedInModel)
        {
            var sub = signedInModel.UserId.ToString();
            var roles = signedInModel.Roles.ToString().Split(", ");

            return JsonWebToken.Encode(sub, roles);
        }

        private void TransformLoginAndPasswordToHash(SignInModel signInModel)
        {
            signInModel.Login = Hash.Create(signInModel.Login);
            signInModel.Password = Hash.Create(signInModel.Password);
        }
    }
}
