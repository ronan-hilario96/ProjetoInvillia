using CompartilharJogos.Domain.Users;

namespace CompartilharJogos.Domain.SharedGames
{
    public class ShareGamesDto
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string? Friend { get; set; }
        public string? Game { get; set; }
        public int UserId { get; set; }
    }
}
