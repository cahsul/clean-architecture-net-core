using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Menu.Commands.CreateMenu
{
    public class CreateMenuValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuValidator()
        {
            RuleFor(r => r.Label).NotEmpty();
            RuleFor(r => r.MenuKey).NotEmpty();
        }
    }
}
