using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KARYA.BUSINESS.Abstract.TranslateApp;
using KARYA.MODEL.Entities.TranslateApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TRANSLATEAPP.API.REST.Models;

namespace TRANSLATEAPP.API.REST.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IConfiguration _configuration;
        IInnovaUserManager _innovaUserManager;
        public UserController(IInnovaUserManager innovaUserManager, IConfiguration configuration)
        {
            _configuration = configuration;
            _innovaUserManager = innovaUserManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _innovaUserManager.LoginUser(username,password);

            InnovaUser loginUser;
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
                    new Claim(JwtRegisteredClaimNames.Sub,loginUser.Username),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims,
                    expires: expiresDate,
                    signingCredentials: credentials
                    );

                var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

                return encodeToken;
            }
        }

        //[Authorize]
        [HttpPost("UserUpdate")]
        public async Task<IActionResult> Update(InnovaUser innovaUser)
        {
            var result = await _innovaUserManager.UpdateUser(innovaUser);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //[Authorize]
        [HttpPost("UserDelete")]
        public async Task<IActionResult> Delete(InnovaUser innovaUser)
        {
            var result = await _innovaUserManager.DeleteUser(innovaUser);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
