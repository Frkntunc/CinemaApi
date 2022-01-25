using Application.ModelOperations.UserModelOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules.UserValidationRules
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.Id).NotEmpty().GreaterThan(0);
            RuleFor(u => u.user.FirstName).MinimumLength(2);
            RuleFor(u => u.user.LastName).MinimumLength(2);
            RuleFor(u => u.user.Password).MinimumLength(5);
        }
    }
}
