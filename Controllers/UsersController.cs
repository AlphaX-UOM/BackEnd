using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using SuggestorCodeFirstAPI;
using SuggestorCodeFirstAPI.Models;
using Ubiety.Dns.Core;

namespace SuggestorCodeFirstAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private readonly JWTSettings _jwtsettings;
        private IWebHostEnvironment _hostingEnvironment;

        public UsersController(RepositoryContext context, IOptions<JWTSettings> jwtsettings, IWebHostEnvironment environment)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
            _hostingEnvironment = environment;
        }

        // GET: api/Users
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [Authorize]
        [HttpGet("AutherizedEndpoint")]
        public async Task<ActionResult<IEnumerable<User>>> AutherizedGetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        ///[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = _context.Users
                                .Include(u => u.TransportServices)
                                .Where(u => u.ID == id)
                                .Include(i => i.Reservations)
                                .Where(i => i.ID == id)
                                .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }




        [HttpPost("Login")]
        public async Task<ActionResult<UserWithToken>> Login()
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            if (!Request.Headers.ContainsKey("Authorization"))
                return NotFound();

            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string emailAddress = credentials[0];
            string password = credentials[1];

             var user = await _context.Users
                                    .Include(u => u.Reservations)
                                .Where(u => u.Email == emailAddress
                                   && u.Password == password)
                                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            UserWithToken userWithToken = new UserWithToken(user);

            if (userWithToken == null)
            {
                return NotFound();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("ID", user.ID.ToString()),
                    new Claim("Role", user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userWithToken.Token = tokenHandler.WriteToken(token);

            return userWithToken;
        }

        [HttpPut("PasswordChange/{id}")]
        public async Task<IActionResult> PutUser(Guid id)
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            if (!Request.Headers.ContainsKey("Authorization"))
                return NotFound();

            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] passwords = Encoding.UTF8.GetString(bytes).Split(":");
            string oldPassword = passwords[0];
            string newPassword = passwords[1];



            var user = await _context.Users
                               .Where(u =>u.ID == id)
                               .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }
            else if (!VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest();
            }
            else
            {
                CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Password = newPassword;

                _context.Entry(user).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }

                return NoContent();
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        [HttpPost("RegisterProtected")]
        public async Task<ActionResult<User>> RegisterUser(User user)
        {
            if (UserExistsByMail(user.Email))
            {
                return BadRequest();
            }
            
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            //creating a token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("compareKey", user.ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            var hosturl = "https://alphax-api.azurewebsites.net/api/users/ConfirmEmail?";
            var useridurl = "userId=" + user.ID + "&&";
            var tokenidurl = "token=" + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(token.ToString()));
            var confirmationLink = hosturl + useridurl + tokenidurl;

            string emailSender = "vvisitalphax@gmail.com";
            string emailSenderPassword = "qwertyuiop0112294169a";
            string emailSenderHost = "smtp.gmail.com";
            int emailSenderPort = 587;
            bool emailIsSSL = true;

            string MailText = "<h3>Dear [newusername],</h3><p>Thank you for registering with us!<p><a href =[confirmLink]>Click here to verify your email.</ a >";
  
            MailText = MailText.Replace("[newusername]", user.FirstName);
            MailText = MailText.Replace("[confirmLink]", confirmationLink);

            string subject = "Welcome to Vvisit Platform";
 
            MailMessage _mailmsg = new MailMessage();
 
            _mailmsg.IsBodyHtml = true;
 
            _mailmsg.From = new MailAddress(emailSender);
 
            _mailmsg.To.Add(user.Email);

            _mailmsg.Subject = subject;
  
            _mailmsg.Body = MailText;
  
            SmtpClient _smtp = new SmtpClient();
  
            _smtp.Host = emailSenderHost;
 
            _smtp.Port = emailSenderPort;
  
            _smtp.EnableSsl = emailIsSSL;
 
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;  
            _smtp.Send(_mailmsg);

            return Ok();
        }

        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult<User>> EmailConfirm(string userId, string token)
        {
            var bytes = Convert.FromBase64String(token);
            string[] mytoken = Encoding.UTF8.GetString(bytes).Split(".");
            string myObject = mytoken[1];

            
            var myUserId = JObject.Parse(myObject)["compareKey"].ToString();

            if (myUserId == userId)
            {
                Guid newGuid = Guid.Parse(userId);
                var user = await _context.Users.FindAsync(newGuid);

                if(user == null)
                {
                    return BadRequest();
                }

                user.Verified = true;
                _context.Entry(user).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();

                    return Redirect("https://vvisitfrontend.azurewebsites.net/");
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
            }

            return NotFound();
        }

        [HttpPost("LoginProtected")]
        public async Task<ActionResult<UserWithToken>> LoginUser()
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            if (!Request.Headers.ContainsKey("Authorization"))
                return NotFound();

            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string emailAddress = credentials[0];
            string password = credentials[1];

            var user = await _context.Users
                                   .Include(u => u.Reservations)
                               .Where(u => u.Email == emailAddress)
                               .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }
            else if (user.Verified == false)
            {
                return Unauthorized();
            }
            else if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                return BadRequest();
            }
            else
            {

                UserWithToken userWithToken = new UserWithToken(user);

                if (userWithToken == null)
                {
                    return NotFound();
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("ID", user.ID.ToString()),
                    new Claim("Role", user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                userWithToken.Token = tokenHandler.WriteToken(token);

                return userWithToken;
            }
        }

        [HttpPost("CheckEmail")]
        public async Task<ActionResult<User>> EmailCheckPasswordResetUser()
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            if (!Request.Headers.ContainsKey("Authorization"))
                return BadRequest();

            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string emailAddress = credentials[1];

            var user = await _context.Users
                               .Where(u => u.Email == emailAddress)
                               .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var hosturl = "https://vvisitfrontend.azurewebsites.net/passwordreset/";
                var useridurl = user.ID.ToString();
                var resetRedirectLink = hosturl + useridurl;

                string emailSender = "vvisitalphax@gmail.com";
                string emailSenderPassword = "qwertyuiop0112294169a";
                string emailSenderHost = "smtp.gmail.com";
                int emailSenderPort = 587;
                bool emailIsSSL = true;

                string MailText = "<h3>Dear [newusername],</h3><p>It looks like you fogot your password!<p><a href =[confirmLink]>Click here to reset you password.</ a >";
               

                 MailText = MailText.Replace("[newusername]", user.FirstName);
                 MailText = MailText.Replace("[confirmLink]", resetRedirectLink);

                string subject = "Vvisit Platform - Password Reset";

                MailMessage _mailmsg = new MailMessage();

                _mailmsg.IsBodyHtml = true;

                _mailmsg.From = new MailAddress(emailSender);

                _mailmsg.To.Add(user.Email);

                _mailmsg.Subject = subject;

                _mailmsg.Body = MailText;

                SmtpClient _smtp = new SmtpClient();

                _smtp.Host = emailSenderHost;

                _smtp.Port = emailSenderPort;

                _smtp.EnableSsl = emailIsSSL;

                NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
                _smtp.Credentials = _network;
                _smtp.Send(_mailmsg);

                return Ok();
            }
        }

        [HttpPut("PasswordReset")]
        public async Task<IActionResult> PasswordResetUser()
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            if (!Request.Headers.ContainsKey("Authorization"))
                return NotFound();

            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string userStoredId = credentials[0];
            string newPassword = credentials[1];

            Guid newGuid = Guid.Parse(userStoredId);
            var user = await _context.Users.FindAsync(newGuid);

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Password = newPassword;

                _context.Entry(user).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();

                    return Redirect("https://vvisitfrontend.azurewebsites.net/");
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

      

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.ID == id);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool UserExistsByMail(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
