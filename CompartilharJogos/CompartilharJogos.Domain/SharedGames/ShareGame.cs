using CompartilharJogos.Domain._Base;
using CompartilharJogos.Domain.Users;

namespace CompartilharJogos.Domain.SharedGames
{
    public class ShareGame : Entity
    {
        protected ShareGame() { }
        public User User { get; private set; }
        public string? Friend { get; private set; }
        public string? Game { get; private set; }
        public int UserId { get; private set; }
        public ShareGame(string? friend, string? game, int userId)
        {
            this.Friend = friend;
            this.Game = game;
            UserId = userId;
        }
        public void setFriend(string friend) 
        {
            // Validar
            this.Friend = friend;
        }
        public void setGame(string game)
        {
            // Validar
            this.Game = game;
        }
    }
}
