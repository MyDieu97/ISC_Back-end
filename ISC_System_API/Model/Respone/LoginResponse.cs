using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model.Respone
{
    public class LoginResponse
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
