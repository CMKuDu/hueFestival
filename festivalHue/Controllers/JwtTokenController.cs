using festivalHue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace festivalHue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HueFestivalApiContext _context;
        public JwtTokenController(HueFestivalApiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Account user)
        {
            if (user != null && user.Phone != null && user.Password != null)
            {
                //var userData = await GetUser(user.Phone.ToString(), user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<JwtHeaderParameterNames>();
                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.Idaccount.ToString()),
                new Claim ("NameAccount", user.Nameaccount),
                new Claim ("Email", user.Email),
                new Claim("PhoneNumber", user.Phone.ToString()),
                new Claim("Password", user.Password)
            };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
            }

            return BadRequest("Invalid");
        }
        [HttpGet]
        public async Task<Account> GetUser(string phoneNumber, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(u => u.Phone.ToString() == phoneNumber && u.Password == password);
        }
        //public async Task<IActionResult> Post(Account user)
        //{
        //    if (user != null && user.Phone != null && user.Password != null)
        //    {
        //        //var userData = await GetUser(user.Phone.ToString(), user.Password);
        //        var jwt = _configuration.GetSection("Jwt").Get<JwtHeaderParameterNames>();
        //        if (user != null)
        //        {
        //            var claims = new[]
        //            {
        //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //                new Claim("Id", user.Idaccount.ToString()),
        //                new Claim("PhoneNumber", user.Phone.ToString()),
        //                new Claim("Password", user.Password)
        //            };
        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //            var token = new JwtSecurityToken(
        //                    _configuration["Jwt:Issuer"],
        //                    _configuration["Jwt:Audience"],
        //                    claims,
        //                    expires: DateTime.Now.AddMinutes(20),
        //                    signingCredentials: signIn
        //                );
        //            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        //        }
        //        else
        //        {
        //            return BadRequest("Invalid");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid");
        //    }
        //}

        //[HttpGet]
        //public async Task<Account> GetUser(string phoneNumber, string password)
        //{
        //    return await _context.Accounts.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber && u.Password == password);
        //}
    }
}
