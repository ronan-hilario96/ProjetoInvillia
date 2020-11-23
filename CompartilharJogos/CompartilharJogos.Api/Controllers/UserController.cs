using CompartilharJogos.Domain.Users;
using CompartilharJogos.JWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CompartilharJogos.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly SaveUser _save;
        private readonly GetTolkenUser _getTolkenUser;

        public UserController(
            SaveUser save, 
            GetTolkenUser getTolkenUser)
        {
            _save = save;
            _getTolkenUser = getTolkenUser;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            // Recupera o usuário
            var model = new UserDto()
            {
                Username = username,
                Password = password
            };
            var user = await _getTolkenUser.Get(model);

            // Verifica se o usuário existe
            if (user == null)
                return Unauthorized();

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            UserDto response = new UserDto
            {
                Id = user.Id,
                Role = user.Role,
                Username = user.Username
            };

            // Retorna os dados
            return Ok(new
            {
                user = response,
                token = token
            });
        }

        [HttpPost]
        [Route("create-account")]
        public async Task Create([FromBody]UserDto model)
        {
            _save.Save(model);
        }
    }
}
