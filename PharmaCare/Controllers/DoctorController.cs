using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PharmaCare.Models.DTO;
using PharmaCare.Repository.IRepository;


namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository doctorRepository; // Injected IDoctRepo
        public DoctorController(IDoctorRepository _doctorRepository)
        {
            doctorRepository = _doctorRepository;
            
        }


        #region Login Request

        [HttpPost("Login")]   //Login Request
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {

            var login = await doctorRepository.Login(model);
            if(login.Doctor==null ||  String.IsNullOrEmpty(login.Token))
            {
                return BadRequest(new { Message = "UserName or password is incorrect" });
            }
            return Ok(login);
        }

        #endregion



        #region Register Request
        [HttpPut("Register")]  //Register Request
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {

            bool check = doctorRepository.isUnique(model.Email);

            if (!check)
            {
                return BadRequest(new { Message = "User already exists" });
            }

            var doctor = doctorRepository.Register(model);
            if (doctor == null)
            {
                return BadRequest(new { Message = "User already exists" });

            }
            return Ok();
        }
        #endregion
    }
}
