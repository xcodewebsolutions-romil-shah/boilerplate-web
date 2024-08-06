using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Infrastructure.Dtos
{
    public class UserDto
    {
        public int? UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
