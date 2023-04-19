using FluentValidation;
using Sample.Application.Student.Commands.Query.GetStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.User.Commands.Query
{
    public class GetUserValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserValidator()
        {
            RuleFor(model => model.Login.UserName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'UserName' field")
                .NotEmpty().WithMessage("UserName field shouldn't be empty");

            RuleFor(model => model.Login.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'Password' field")
                .NotEmpty().WithMessage("Password field shouldn't be empty");


        }
    }
}
