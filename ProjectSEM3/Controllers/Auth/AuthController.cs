using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs.Auth;
using ProjectSEM3.Entities;
using ProjectSEM3.Services;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IEmailService _emailService;
        public AuthController(ProjectSem3Context context, IConfiguration config, IEmailService emailService)
        {
            _context = context;
            _config = config;
            _emailService = emailService;
        }
        // dadafas
        [HttpPost, Route("register")]
        [AllowAnonymous]
        async public Task<IActionResult> Register(UserRegister data)
        {
            if (ModelState.IsValid)
            {
                // hash pw and token
                var token = BCrypt.Net.BCrypt.HashString(data.Email, 10);
                var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
                var passHash = BCrypt.Net.BCrypt.HashPassword(data.Password,salt);
                // create new user and user info
                var user = new User { Email = data.Email, Token = data.Email, Password = passHash };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                var userInfo = new UserInfo { Gender = data.Gender, Birthday = data.Birthday, Name = data.FirstName + data.LastName,UserId= user.Id };
                await _context.UserInfos.AddAsync(userInfo);
                // save user
                await _context.SaveChangesAsync();
                // send verify email
                _emailService.SendEmail(userInfo.Name, data.Email, token);

                return Ok(true);
            }
            return BadRequest(false);
        }
        [HttpPost, Route("register-gg")]
        [AllowAnonymous]
        async public Task<IActionResult> RegisterGG(GoogleToken data)
        {
            if (ModelState.IsValid)
            {
                // hash pw and token
                var token = BCrypt.Net.BCrypt.HashString(data.email, 10);
                var user = new User { Email = data.email, Token = data.email };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                var userInfo = new UserInfo {  Name = data.family_name + data.given_name,UserId= user.Id};
                await _context.UserInfos.AddAsync(userInfo);
                // save user
                await _context.SaveChangesAsync();
                // send verify email
                _emailService.SendEmail(userInfo.Name, data.email, token);

                return Ok(true);
            }
            return BadRequest(false);
        }

        private string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signatureKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
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
                expires: DateTime.Now.AddHours(3),
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
            if (ModelState.IsValid)
            {
                // if activate false 
                var u = await _context.Users.Where(a => a.Email.Equals(data.Email)).Include(e => e.Admins).FirstOrDefaultAsync();
                if (u == null) return NotFound();
                var checkPW = BCrypt.Net.BCrypt.Verify(data.Password, u.Password);
                if (!checkPW) return Unauthorized();
                return Ok(new UserData { Id = u.Id, Email = u.Email, Token = GJWT(u) });
            }
            return BadRequest();

        }

        [HttpPost, Route("login-gg"), AllowAnonymous]
        async public Task<IActionResult> LoginWithGG(GoogleToken data)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.Where(u => u.Email.Equals(data.email)).FirstOrDefaultAsync();
                if (user == null) return NotFound();

                return Ok(new UserData { Id = user.Id, Email = data.email, Token = GJWT(user) });
            }
            return BadRequest();
        }
        [HttpGet, Route("profile")]
        async public Task<IActionResult> GetProfile()
        {
            // xac thuc danh tinh user
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.IsAuthenticated)
            {
                var userClaims = identity.Claims;
                var UserId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var user= await _context.Users.Include(e=>e.UserInfos).Where(c => c.Id == Convert.ToInt32(UserId) ).FirstOrDefaultAsync();
                /*var user = new UserData
                {
                    Id = Convert.ToInt32(UserId),
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value
                };*/
                return Ok(user);
            }
            return Unauthorized();
        }

        [HttpGet, Route("test-profile"),AllowAnonymous]
        async public Task<IActionResult> GetProfileDemo(int? id)
        {
            var UInfo = await _context.UserInfos.Include(e => e.User).Where(e => e.UserId == id).FirstOrDefaultAsync();
            if (UInfo == null) return NotFound();
            return Ok(UInfo);
        }


        [HttpPost, Route("check-register"), AllowAnonymous]
        async public Task<IActionResult> IsEmailExist(string email)
        {
            var u = await _context.Users.Where(e => e.Email.Equals(email)).FirstOrDefaultAsync();
            if (u == null) return Ok(false);
            return Ok(true);
        }

        [HttpPost, Route("verify-email"), AllowAnonymous]
        async public Task<IActionResult> VerifyEmail(string email, string token)
        {
            var u = await _context.Users.Where(e => e.Email.Equals(email)).FirstOrDefaultAsync();
            if (u == null) return NotFound(false);

            var check = BCrypt.Net.BCrypt.Verify(u.Token, token);
            if (!check) return BadRequest(false);

            u.Activate = true;
            _context.Users.Update(u);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost, Route("check-token")]
        async public Task<IActionResult> CheckToken()
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null) return Unauthorized(new { CheckToken=false});
            return Ok(new { CheckToken = true });
        }
    }
}
