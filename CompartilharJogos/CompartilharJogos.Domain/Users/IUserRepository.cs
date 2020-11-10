using CompartilharJogos.Domain._Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompartilharJogos.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetTokenUser(string username, string password);
    }
}
