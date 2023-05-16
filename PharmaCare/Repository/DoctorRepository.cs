using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Models.DTO;
using PharmaCare.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PharmaCare.Repository
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly PharmacyContext pharmacyContext;
        private string SecretKey;
        public DoctorRepository(PharmacyContext _pharmacyContext , IConfiguration configuration)
        {
            pharmacyContext= _pharmacyContext;
            SecretKey = configuration.GetValue<string>("ApiSettings:Secret");

        }

        public bool isUnique(string Email)
        {
            var temp = pharmacyContext.Doctors.Where(u => u.Email == Email).FirstOrDefault();
            if(temp != null)
            {
                return false;
            }
            return true;  

        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
           
           var temp = pharmacyContext.Doctors.Where(u => u.Email.ToLower() == loginRequestDTO.Email.ToLower() && u.Password==loginRequestDTO.password).FirstOrDefault();

            if(temp==null)
            {
                return new LoginResponseDTO()
                {
                    Token="",
                    Doctor=null
                    
                };
            }

            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);


            var TokenDiscript = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,temp.Id.ToString()),
                    new Claim(ClaimTypes.Role,temp.Role.ToString())


                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


            };

            var token = tokenHandler.CreateToken(TokenDiscript);

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Doctor = temp
            };

            return loginResponseDTO;


            
        }

        public async Task<Doctor> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            Doctor dct = new(){

                Email = registrationRequestDTO.Email,Password = registrationRequestDTO.Password , Role=registrationRequestDTO.Role
            };

           await pharmacyContext.Doctors.AddAsync(dct);
            await pharmacyContext.SaveChangesAsync();
            dct.Password = "";
            return dct;
        }
    }
}
