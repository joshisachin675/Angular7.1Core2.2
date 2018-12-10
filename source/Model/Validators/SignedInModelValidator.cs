using DotNetCore.Validation;
using IDCardScanning.CrossCutting.Resources;
using IDCardScanning.Model.Models;
using FluentValidation;

namespace IDCardScanning.Model.Validators
{
    public sealed class SignedInModelValidator : Validator<SignedInModel>
    {
        public SignedInModelValidator() : base(Texts.LoginPasswordInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
