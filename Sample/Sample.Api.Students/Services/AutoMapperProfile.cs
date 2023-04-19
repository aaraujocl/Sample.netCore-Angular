using AutoMapper;
using Sample.Application.Student.Commands.Create;
using Sample.Application.Student.Commands.SeedWork;
using Sample.Application.User.Commands.SeedWork;
using Sample.Core.Domain;

namespace Sample.Api.Students.Services
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateStudentDto, Student>().ReverseMap(); //reverse so the both direction

            CreateMap<StudentDto, Student>().ReverseMap(); //reverse so the both direction

            CreateMap<UserDto, User>().ReverseMap(); //reverse so the both direction
        }
    }
}
