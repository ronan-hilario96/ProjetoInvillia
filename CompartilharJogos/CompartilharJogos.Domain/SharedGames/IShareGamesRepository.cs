using CompartilharJogos.Domain._Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompartilharJogos.Domain.SharedGames
{
    public interface IShareGamesRepository : IRepository<ShareGame>
    {
        Task<ICollection<ShareGame>> Consult(int userId);
    }
}
