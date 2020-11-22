using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KARYA.API.REST.Models.Auth;
using KARYA.BUSINESS.Abstract;
using KARYA.BUSINESS.Abstract.Karya;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KARYA.API.REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        IConfiguration _configuration;

        IUserManager _userManager;
        public AuthController(IUserManager userManager, IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
        {

            var result = await _userManager.Login(userLoginModel);
            Users loginUser;
            var expiresDate = DateTime.UtcNow.AddDays(7);
            if (result.Success == true)
            {
                if (result.Data != null)
                {
                    loginUser = result.Data;
                    return Ok(new
                    {
                        login = true,
                        Token = GenerateToken(),
                        EndTime = expiresDate,
                        Message = result.Message
                    });
                }
                else
                {
                    return NoContent();
                }
                
            }
            else
            {
                return BadRequest(new
                {
                    login = false,
                    Message = result.Message
                });
            }


            string GenerateToken()
            {

                
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,loginUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Email,loginUser.EMail),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer:_configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims,
                    expires: expiresDate,
                    signingCredentials:credentials
                    );

                var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

                return encodeToken;
            }

        }


        
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody]UserModel userModel)
        {
            var addUser = new Users
            {
                Code = "otomatik",
                Name = userModel.Name,
                Lastname = userModel.Lastname,
                UserName = userModel.UserName,
                Password = userModel.Password,
                UserGroupId = userModel.UserGroupId,
                EMail = userModel.EMail,
                Enable = true,
                Description = "açıklama"
            };

            var resultUser = await _userManager.Add(addUser);

            return Ok(new
            {
                success = resultUser.Success,
                Message = resultUser.Message
            });

        }

        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            IList<Claim> claims = identity.Claims.ToList();
            var userName = claims[0].Value;
            return "Login user : " + userName;
        }

        [HttpGet("GetValues")]
        public IEnumerable<string> GetValues()
        {

            return new string[]
            {
                "Values",
                "Values1",
                "Values2"
            };
        }
    }
}
