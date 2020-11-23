using CompartilharJogos.Domain._Base;
using CompartilharJogos.Domain.SharedGames;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompartilharJogos.Domain.Users;
using CompartilharJogos.JWT.Services;

namespace CompartilharJogos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ShareGameController : ControllerBase
    {
        private readonly Share _share;
        private readonly IRepository<ShareGame> _repository;
        private readonly ListGamesUser _listGamesUser;

        public ShareGameController(Share share, IRepository<ShareGame> repository, ListGamesUser listGamesUser) {
            _share = share;
            _repository = repository;
            _listGamesUser = listGamesUser;
        }
        [HttpGet]
        public Task<ICollection<ShareGame>> Get()
        {
            string authorization = HttpContext.Request.Headers["Authorization"];
            var idUser= TokenService.DecocodeToken(authorization.Replace("Bearer ", ""));
            return _listGamesUser.GetListGames(idUser);
        }
        [HttpPost]
        public void Post([FromBody] ShareGamesDto dto)
        {
            _share.Shared(dto);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
