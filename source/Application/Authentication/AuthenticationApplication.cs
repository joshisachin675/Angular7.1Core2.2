using IDCardScanning.Domain;
using IDCardScanning.Model.Models;

namespace IDCardScanning.Application
{
    public sealed class AuthenticationApplication : IAuthenticationApplication
    {
        public AuthenticationApplication(IAuthenticationDomain authenticationDomain)
        {
            AuthenticationDomain = authenticationDomain;
        }

        private IAuthenticationDomain AuthenticationDomain { get; }

        public string SignIn(SignInModel signInModel)
        {
            return AuthenticationDomain.SignIn(signInModel);
        }

        public void SignOut(SignOutModel signOutModel)
        {
            AuthenticationDomain.SignOut(signOutModel);
        }
    }
}
