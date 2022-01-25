using Application.ModelOperations.UserModelOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules.UserValidationRules
{
    public class DeleteUserValidator : AbstractValidator<DeleteUser>
    {
        public DeleteUserValidator()
        {
            RuleFor(u => u.Id).NotEmpty().GreaterThan(0);
        }
    }
}
