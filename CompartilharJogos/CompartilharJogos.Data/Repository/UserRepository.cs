using CompartilharJogos.Data.Context;
using CompartilharJogos.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompartilharJogos.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User> GetTokenUser(string username, string password)
        {
            return await Context.Set<User>().Where(u => u.Username == username && u.Password == password).FirstAsync();
        }
    }
}
