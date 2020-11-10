using CompartilharJogos.Data.Context;
using CompartilharJogos.Domain.SharedGames;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompartilharJogos.Data.Repository
{
    // public class FriendsRepository : RepositoryBase<Friend>, IFriendRepository
    public class SharedGamesRepository : RepositoryBase<ShareGame>, IShareGamesRepository
    {
        public SharedGamesRepository(ApplicationDbContext context) : base(context) { }

        public async Task<ICollection<ShareGame>> Consult(int userId)
        {
            return await Context.Set<ShareGame>().Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
