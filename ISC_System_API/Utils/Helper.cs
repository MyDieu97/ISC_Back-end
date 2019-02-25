using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISC_System_API.Utils
{
    public class Helper
    {
        public readonly static string OAuthKey = "132jdiwoajdoi5656awfhaiufhakacbsj";
        public static string Gethash(string input)
        {
            return string.Join("", new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input))
                .Select(x => x.ToString("X2")).ToArray());
        }
    }
}
