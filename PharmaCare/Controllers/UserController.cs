using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using PharmaCare.Data;
using PharmaCare.Helper;
using PharmaCare.Models;
using PharmaCare.Models.DTO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly PharmacyContext context;
        public UserController(PharmacyContext _context)
        {
            context= _context;
        }
        [HttpPost]
        [Route("login")]

        public  async Task<IActionResult> Login([FromBody]  UserDTO user)
        {


            if(user== null)
            {

                return BadRequest();
            }

            var temp =  await context.Users.FirstOrDefaultAsync(x=>x.username==user.UserName);
            if(temp ==  null)
            {
                return NotFound(new {Message="User Name does not exists"});
            }

            if (!PasswordHasher.VerifyPassword(user.Password, temp.password))
            {

                return BadRequest(new { Message = "Password is incorrect" });
            }
            return Ok(new {
            Message ="Login Success"
            });

        }

        [HttpPost]
        [Route("SignUp")]

        public async Task<IActionResult>  Register([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }

            if (await CheckUserNameExistsAsync(user.username))
            {
                return BadRequest(new 
                { 
                Message="User Name already Exists"
                });

            }

            if (await CheckEmailExistsAsync(user.email))
            {
                return BadRequest(
                    new {
                    Message="Email ALready Exists"
                    }

                    );
            }
            var psp = CheckPasswordAsync(user.password);

            if (!String.IsNullOrEmpty(psp))
            {
                return BadRequest(new
                { 
                    Message = "Password should be Alphanumeric" }
                );

            }

            user.password = PasswordHasher.HashPassword(user.password);
            user.Token = "";
            user.role = "Doctor";

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(new {Message ="SUCCESS ADDED"});

        }

        [NonAction]
        public async Task<bool> CheckUserNameExistsAsync(string username)
        {
            return await context.Users.AnyAsync(x => x.username == username);
        }

        [NonAction]
        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await context.Users.AnyAsync(x => x.email == email);
        }

        [NonAction]

        public  string CheckPasswordAsync(string password)
        {

            StringBuilder sb = new StringBuilder();
            Regex validateGuidRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if(!validateGuidRegex.IsMatch(password))
            {
                sb.Append("Password Should be Alphanumeric");

            }
            return sb.ToString();
        }

    }
}
