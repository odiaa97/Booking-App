using System.Collections.Generic;

namespace API.DTOs
{
    public class UserDto
    {
        public string username { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
    }
}