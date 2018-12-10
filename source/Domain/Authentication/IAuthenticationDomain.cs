using IDCardScanning.Model.Models;

namespace IDCardScanning.Domain
{
    public interface IAuthenticationDomain
    {
        string SignIn(SignInModel signInModel);

        void SignOut(SignOutModel signOutModel);
    }
}
