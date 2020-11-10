using CompartilharJogos.Domain._Base;
using CompartilharJogos.Domain.SharedGames;
using System.Collections.Generic;

namespace CompartilharJogos.Domain.Users
{
    public class User : Entity
    {
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Role { get; protected set; }
        public List<ShareGame> SharedGames { get; protected set; }
        public User(string Username, string Password, string role = "")
        {
            ValidationRules.New().When(Username == "", Resource.HasGame).TriggerException();
            this.Username = Username;
            this.Password = Password;
            this.Role = role;
        }
    }
}