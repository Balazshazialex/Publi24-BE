using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Publi24.BMs;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace Publi24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            if (user.Username == "user" && user.Password == "pass")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("encodeMeAlready@333"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new LoginResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}