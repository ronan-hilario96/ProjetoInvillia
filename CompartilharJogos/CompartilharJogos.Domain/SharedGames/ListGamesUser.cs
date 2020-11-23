using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompartilharJogos.Domain.SharedGames
{
    public class ListGamesUser
    {
        private readonly IShareGamesRepository _repository;
        public ListGamesUser(IShareGamesRepository repository)
        {
            _repository = repository;
        }

        public Task<ICollection<ShareGame>> GetListGames(int userId)
        {
            return _repository.Consult(userId);
        }
    }
}
