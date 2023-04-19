using AutoMapper;
using MediatR;
using Sample.Application.Student.Commands.Create;
using Sample.Application.Student.Commands.Query.GetStudent;
using Sample.Application.User.Commands.SeedWork;
using Sample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.User.Commands.Query
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public LoginDto Login { get; set; }

        public GetUserQuery(LoginDto login)
        {
            Login = login;
        }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserQueryRepository _repository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.Get(request.Login.UserName, request.Login.Password);
            return _mapper.Map<UserDto>(entity);
        }
    }
}
