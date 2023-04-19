using FluentValidation;
using Sample.Application.Student.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Student.Commands.Delete
{
    public class DeleteStudentValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentValidator()
        {
            RuleFor(model => model.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'Id' field")
                .NotEmpty().WithMessage("Id field shouldn't be empty");


        }
    }
}
