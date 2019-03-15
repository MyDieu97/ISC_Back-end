using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Respone
{
    public class LoginResponse
    {
        [Key]
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
