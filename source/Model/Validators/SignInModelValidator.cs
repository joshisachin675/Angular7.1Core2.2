using DotNetCore.Validation;
using IDCardScanning.CrossCutting.Resources;
using IDCardScanning.Model.Models;
using FluentValidation;

namespace IDCardScanning.Model.Validators
{
    public sealed class SignInModelValidator : Validator<SignInModel>
    {
        public SignInModelValidator() : base(Texts.LoginPasswordInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
