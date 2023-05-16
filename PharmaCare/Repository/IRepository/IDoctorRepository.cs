using PharmaCare.Models;
using PharmaCare.Models.DTO;

namespace PharmaCare.Repository.IRepository
{
    public interface IDoctorRepository
    {
        bool isUnique(string Email);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<Doctor> Register(RegistrationRequestDTO registrationRequestDTO);


    }
}
