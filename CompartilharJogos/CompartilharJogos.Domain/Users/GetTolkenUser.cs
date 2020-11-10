using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompartilharJogos.Domain.Users
{
    public class GetTolkenUser
    {
        private readonly IUserRepository _repository;
        public GetTolkenUser(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<User> Get(UserDto dto)
        {
            return _repository.GetTokenUser(dto.Username, dto.Password);
        }
    }
}
