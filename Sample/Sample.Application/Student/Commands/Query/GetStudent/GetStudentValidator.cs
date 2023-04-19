using FluentValidation;
using Sample.Application.Student.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Student.Commands.Query.GetStudent
{
    public class GetStudentValidator : AbstractValidator<GetStudentQuery>
    {
        public GetStudentValidator()
        {
            RuleFor(model => model.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'UserName' field")
                .NotEmpty().WithMessage("UserName field shouldn't be empty");


        }
    }
}
