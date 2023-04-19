using AutoMapper;
using MediatR;
using Sample.Core.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Student.Commands.Create
{

    public class CreateStudentCommand: IRequest<bool>
    {
        public CreateStudentDto CreateStudentDto { get; set; }

        public CreateStudentCommand(CreateStudentDto createStudentDto)
        {
            CreateStudentDto = createStudentDto;
        }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IStudentCommandRepository _repository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Core.Domain.Student>(request.CreateStudentDto);

            try
            {
                _repository.Create(entity);
            }
            catch
            {
                throw new Exceptions.ApplicationException("Failed to add new Student to the post");
            }

            return true;
        }
    }
}
