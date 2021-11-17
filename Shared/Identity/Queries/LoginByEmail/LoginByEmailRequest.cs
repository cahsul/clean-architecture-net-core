using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shared.Identity.Resources;
using Shared.X.Requests;

namespace Shared.Identity.Queries.LoginByEmail
{
    public class LoginByEmailRequest : BaseRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginByEmailRequestValidator : AbstractValidator<LoginByEmailRequest>
    {
        public LoginByEmailRequestValidator()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress().WithName(IdentityLang.Form_Email);
            RuleFor(r => r.Password).NotEmpty().WithName(IdentityLang.Form_Password);
        }
    }
}
