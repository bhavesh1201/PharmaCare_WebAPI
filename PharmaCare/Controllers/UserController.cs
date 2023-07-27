using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PharmaCare.Data;
using PharmaCare.Helper;
using PharmaCare.Models;
using PharmaCare.Models.DTO;
using PharmaCare.Repository.IRepository;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerControllerOrder(1)]
    public class UserController : ControllerBase
    {


       
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
            
          
        }
        [HttpPost]
        [Route("login")]

        public  async Task<IActionResult> Login([FromBody]  UserDTO user)
        {


            if(user== null)
            {

                return BadRequest();
            }

            var temp = await userRepository.GetUser(user);
            if (temp ==  null)
            {
                return NotFound(new {Message="User Name does not exists"});
            }

            if (!PasswordHasher.VerifyPassword(user.Password, temp.password))
            {

                return BadRequest(new { Message = "Password is incorrect" });
            }

            temp.Token =await userRepository.Login(user);


            return Ok(new {
                Token = temp.Token,
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

            if (await userRepository.CheckUserNameExistsAsync(user.username))
            {
                return BadRequest(new 
                { 
                Message="User Name already Exists"
                });

            }

            if (await userRepository.CheckEmailExistsAsync(user.email))
            {
                return BadRequest(
                    new {
                    Message="Email ALready Exists"
                    }

                    );
            }
            var psp = userRepository.CheckPasswordAsync(user.password);

            if (!String.IsNullOrEmpty(psp))
            {
                return BadRequest(new
                { 
                    Message = "Password should be Alphanumeric" }
                );

            }

         bool dz=  await userRepository.Register(user);

         
            return Ok(new {Message ="SUCCESS ADDED"});

        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUser")]

        public async Task<ActionResult<User>> GetAllUser()
        {
           var temp= await userRepository.GetAllUser();
            return Ok(temp);
        }
        [HttpDelete]
        [Route("DeleteUser")]

        public async Task<ActionResult> DeleteUser(int id)
        {
         
              
            var temp = await userRepository.Delete(id);
            return Ok(temp);
        }





    }
}
