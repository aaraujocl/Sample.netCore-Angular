using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Student.Commands.Create
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(model => model.CreateStudentDto.UserName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'UserName' field")
                .NotEmpty().WithMessage("UserName field shouldn't be empty");

            RuleFor(model => model.CreateStudentDto.FirstName)
                .NotNull().WithMessage("FirstName field shouldn't be empty")
                .NotEmpty().WithMessage("FirstName field shouldn't be empty");

            RuleFor(model => model.CreateStudentDto.LastName)
                .NotNull().WithMessage("LastName field shouldn't be empty")
                .NotEmpty().WithMessage("LastName field shouldn't be empty");

            RuleFor(model => model.CreateStudentDto.Career)
                .NotNull().WithMessage("Career field shouldn't be empty")
                .NotEmpty().WithMessage("Career field shouldn't be empty");

            RuleFor(model => model.CreateStudentDto.Age)
                .NotNull().WithMessage("Age field shouldn't be empty")
                .NotEmpty().WithMessage("Age field shouldn't be empty");
        }
    }
}
