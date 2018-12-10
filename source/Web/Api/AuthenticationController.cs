using DotNetCore.AspNetCore;
using DotNetCore.Extensions;
using IDCardScanning.Application;
using IDCardScanning.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDCardScanning.Web
{
    [ApiController]
    [RouteController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationApplication authenticationApplication)
        {
            AuthenticationApplication = authenticationApplication;
        }

        private IAuthenticationApplication AuthenticationApplication { get; }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public string SignIn(SignInModel signInModel)
        {
            return AuthenticationApplication.SignIn(signInModel);
        }

        [HttpPost("[action]")]
        public void SignOut()
        {
            var signOutModel = new SignOutModel(User.ClaimNameIdentifierValue());
            AuthenticationApplication.SignOut(signOutModel);
        }
    }
}
