using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Models.DTO;
using System.Runtime.InteropServices;

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

            var temp =  await context.Users.FirstOrDefaultAsync(x=>x.username==user.UserName && x.password==user.Password);
            if(temp ==  null)
            {
                return NotFound();
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

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(new {Message ="SUCCESS ADDED"});

        }
    }
}
