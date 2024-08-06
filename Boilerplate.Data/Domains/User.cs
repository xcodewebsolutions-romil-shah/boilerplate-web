using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boilerplate.Data.Domains
{
    [Table("UserInfo")]
    public class User
    {
        [Key]
        public int? UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
