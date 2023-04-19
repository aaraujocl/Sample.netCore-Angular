using AutoMapper;
using MediatR;
using Sample.Application.Student.Commands.SeedWork;
using Sample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Student.Commands.Query.GetStudent
{
    public class GetStudentQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
    }

    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
    {
        private readonly IStudentQueryRepository _repository;
        private readonly IMapper _mapper;

        public GetStudentQueryHandler(IStudentQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.Get(request.Id);
            return _mapper.Map<StudentDto>(entity);
        }
    }

}
