using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Student.Commands.Query.GetStudents
{
    public class GetStudentsValidator : AbstractValidator<GetStudentsQuery>
    {
        public GetStudentsValidator()
        {
        }
    }
}
