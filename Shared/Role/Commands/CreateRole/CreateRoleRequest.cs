using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Shared.Role.Commands.CreateRole
{
    public class CreateRoleRequest
    {
        public string RoleName { get; set; }
        public string Test { get; set; }
    }

    public class CreateRoleValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleValidator()
        {
            RuleFor(r => r.Test).NotEmpty();
            RuleFor(r => r.RoleName).NotEmpty();
        }
    }
}
