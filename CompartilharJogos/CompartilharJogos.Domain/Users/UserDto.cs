using System;
using System.Collections.Generic;
using System.Text;

namespace CompartilharJogos.Domain.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
