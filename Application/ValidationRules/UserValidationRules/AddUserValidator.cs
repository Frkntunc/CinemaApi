using Application.ModelOperations.UserModelOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules.UserValidationRules
{
    public class AddUserValidator : AbstractValidator<CreateUserModel>
    {
        public AddUserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty().MinimumLength(5);
            RuleFor(u => u.Email).Must(Contain).WithMessage("Geçersiz e-posta");
        }

        private bool Contain(string arg)
        {
            return arg.Contains('@');
        }
    }
}
