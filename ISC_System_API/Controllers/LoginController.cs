using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ISC_System_API.Model;
using ISC_System_API.Request;
using ISC_System_API.Respone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISC_System_API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;
        public LoginController(Context context)
        {
            _context = context;

            // Thêm tài khoản đăng nhập mới
            if (_context.Admins.ToList().Count() == 0)
            {
                ADMIN newUser = new ADMIN
                {
                    Username = "admin",
                    Password = Utils.Helper.Gethash("123456"),
                    Fullname = "System admin"
                };
                _context.Admins.Add(newUser);
                _context.SaveChanges();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseRespone>> Login(LoginRequest request)
        {
            if (!string.IsNullOrEmpty(request.Username) && (!string.IsNullOrEmpty(request.Password)))
            {
                var userLogin = await _context.Admins.Where(
                    log => log.Username == request.Username &&
                    log.Password == Utils.Helper.Gethash(request.Password)).AsNoTracking().SingleOrDefaultAsync();

                if (userLogin != null)
                {
                    //generate token (key) to secure for api
                    var claimData = new[] { new Claim(ClaimTypes.Name, request.Username) };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7C4A8D09CA3762AF61E59520943DC26494F8941B"));
                    var singingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: "http://localhost",
                        audience: "http://localhost",
                        expires: DateTime.Now.AddMinutes(30),   // time for living
                        signingCredentials: singingCredential
                        );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return new BaseRespone(new LoginResponse
                    {
                        AdminId = userLogin.Adminid,
                        Username = userLogin.Username,
                        Password = userLogin.Password,
                        Fullname = userLogin.Fullname,
                        Token = "Bearer " + tokenString
                    });
                }
                else
                {
                    return new BaseRespone
                    {
                        ErrorCode = 1,
                        Message = "username or password = null"
                    };

                }
            }
            return new BaseRespone
            {
                ErrorCode = 2,
                Message = "Missing Parameters"
            };
        }
    }
}
