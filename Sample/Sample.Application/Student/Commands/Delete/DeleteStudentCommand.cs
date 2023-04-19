using AutoMapper;
using MediatR;
using Sample.Application.Student.Commands.Create;
using Sample.Application.Student.Commands.Update;
using Sample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Student.Commands.Delete
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentCommandRepository _repository;
        private readonly IMapper _mapper;

        public DeleteStudentCommandHandler(IStudentCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
           
            var id = request.Id;

            try
            {
                _repository.Delete(id);
            }
            catch
            {
                throw new Exceptions.ApplicationException("Failed to Delete Student to the post");
            }

            return true;
        }
    }
}
