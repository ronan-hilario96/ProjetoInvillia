using CompartilharJogos.Data.Repository;
using CompartilharJogos.Domain._Base;
using CompartilharJogos.Domain.SharedGames;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompartilharJogos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ShareGameController : ControllerBase
    {
        private readonly Share _share;
        private readonly IShareGamesRepository _repository;
        private readonly IRepository<ShareGame> _repository1;

        public ShareGameController(Share share, IShareGamesRepository repository, IRepository<ShareGame> repository1) {
            _share = share;
            _repository = repository;
            _repository1 = repository1;
        }
        [HttpGet]
        public Task<ICollection<ShareGame>> Get()
        {
            return _repository.Consult();
        }
        [HttpPost]
        public void Post([FromBody] ShareGamesDto dto)
        {
            _share.Shared(dto);
        }
        [HttpDelete]
        public void Delete(int Id)
        {
            _repository1.Delete(Id);
        }
    }
}
