using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shared.Identity.Resources;
using Shared.X.Requests;
using Shared.X.Resources;

namespace Shared.Identity.Commands.RegisterByEmail
{
    public class RegisterByEmailRequest : BaseRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
    }

    public class RegisterByEmailRequestValidator : AbstractValidator<RegisterByEmailRequest>
    {
        public RegisterByEmailRequestValidator()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress().WithName(IdentityLang.Form_Email);
            RuleFor(r => r.Password).NotEmpty().WithName(IdentityLang.Form_Password);
            RuleFor(r => r.PasswordRepeat).NotEmpty().WithName(IdentityLang.Form_PasswordRepeat);
            RuleFor(r => r.PasswordRepeat).Equal(e => e.Password).WithName(IdentityLang.Form_PasswordRepeat).WithMessage(ValidatorLang.PasswordNotEqual);
        }
    }
}
