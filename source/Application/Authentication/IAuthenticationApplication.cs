using IDCardScanning.Model.Models;

namespace IDCardScanning.Application
{
    public interface IAuthenticationApplication
    {
        string SignIn(SignInModel signInModel);

        void SignOut(SignOutModel signOutModel);
    }
}
