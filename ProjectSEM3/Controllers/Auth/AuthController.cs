using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging;
using ProjectSEM3.DTOs.Auth;
using ProjectSEM3.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectSEM3.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    [Authorize(Policy = "Auth")]
    public class AuthController : ControllerBase
    {
        private readonly ProjectSem3Context _context;
        private readonly IConfiguration _config;
        public AuthController(ProjectSem3Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        // dadafas
        [HttpPost, Route("register")]
        [AllowAnonymous]
        async public Task<IActionResult> Register(UserRegister data)
        {
            var hashPW = BCrypt.Net.BCrypt.HashPassword(data.Password);
            var user = new User { Username = data.UserName, Email = data.Email, Password = hashPW };
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
            return Ok(new UserData { Username = user.Username, Email = user.Email, Token = GenerateJWT(user) });
        }

        private string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signatureKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Email,user.Email)
                //new Claim("IT",user.JobTitle)
            };
            var ad = user.Admins;
            if (ad.Any())
            {
                claims = claims.Append(new Claim(ClaimTypes.Role, ad.First().Role)).ToArray();
            }

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signatureKey
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GJWT(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.Username),
            new Claim(ClaimTypes.Email,user.Email)
        };

            var ad = user.Admins;
            if (ad.Any())
            {
                claims = claims.Append(new Claim(ClaimTypes.Role, ad.First().Role)).ToArray();
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost, Route("login")]
        [AllowAnonymous]
        async public Task<IActionResult> Login(UserLogin data)
        {
            var u = await _context.Users.Where(a => a.Username.Equals(data.UserName)).Include(e => e.Admins).FirstAsync();
            if (u == null) return NotFound();

            var checkPW = BCrypt.Net.BCrypt.Verify(data.Password, u.Password);
            if (!checkPW) return Unauthorized();


            return Ok(new UserData { Username = u.Username, Email = u.Email, Token = GJWT(u) });
        }

        [HttpGet, Route("profile")]
        async public Task<IActionResult> GetProfile()
        {
            // xac thuc danh tinh user
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var Id = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var user = new UserData
                {
                    Id = Convert.ToInt32(Id),
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value
                };
                return Ok(user);
            }
            return Unauthorized();

        }

    }
}
