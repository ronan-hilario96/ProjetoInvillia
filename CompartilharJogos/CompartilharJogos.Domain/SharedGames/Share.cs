using System;
using System.Collections.Generic;
using System.Text;

namespace CompartilharJogos.Domain.SharedGames
{
    public class Share
    {
        private readonly IShareGamesRepository _repository;
        public Share(IShareGamesRepository repository)
        {
            _repository = repository;
        }
        public void Shared(ShareGamesDto dto)
        {
            var share = new ShareGame(dto.Friend, dto.Game, dto.UserId);

            if(dto.Id > 0)
            {
                share = _repository.GetById(dto.Id);
                share.setFriend(dto.Friend);
                share.setGame(dto.Game);
            }

            if (dto.Id == 0)
            {
                _repository.Save(share);
            }
            
        }
    }
}
