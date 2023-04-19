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

namespace Sample.Application.Student.Commands.Query.GetStudents
{
    public class GetStudentsQuery : IRequest<IEnumerable<StudentDto>>
    {
    }

    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IStudentQueryRepository _repository;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(IStudentQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetList();
            return _mapper.Map<IEnumerable<StudentDto>>(entity);
        }
    }
}
