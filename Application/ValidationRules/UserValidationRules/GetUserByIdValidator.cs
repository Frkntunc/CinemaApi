using Application.ModelOperations.UserModelOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules.UserValidationRules
{
    public class GetUserByIdValidator : AbstractValidator<GetUserById>
    {
        public GetUserByIdValidator()
        {
            RuleFor(u => u.Id).NotEmpty().GreaterThan(0);
        }
    }
}
