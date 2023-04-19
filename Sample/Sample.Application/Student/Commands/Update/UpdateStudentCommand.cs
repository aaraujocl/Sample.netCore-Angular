using AutoMapper;
using MediatR;
using Sample.Application.Student.Commands.Create;
using Sample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Student.Commands.Update
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public CreateStudentDto CreateStudentDto { get; set; }
        public int Id { get; set; }

        public UpdateStudentCommand(CreateStudentDto createStudentDto, int id)
        {
            CreateStudentDto = createStudentDto;
            Id = id;
        }
    }

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentCommandRepository _repository;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IStudentCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Core.Domain.Student>(request.CreateStudentDto);
            var id = request.Id;

            try
            {
                _repository.Update(id,entity);
            }
            catch
            {
                throw new Exceptions.ApplicationException("Failed to Update Student to the post");
            }

            return true;
        }
    }
}
