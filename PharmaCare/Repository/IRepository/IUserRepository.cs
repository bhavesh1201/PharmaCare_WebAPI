using PharmaCare.Models.DTO;
using PharmaCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace PharmaCare.Repository.IRepository
{
    public interface IUserRepository
    {


        string CheckPasswordAsync(string password);
        Task<bool> CheckUserNameExistsAsync(string username);

        Task<bool> CheckEmailExistsAsync(string email);
        string JWT_Token(User user);

        Task<ActionResult<User>> GetAllUser();




        Task<string> Login(LoginRequestDTO loginRequestDTO);

        Task<bool> Register(RegistrationRequestDTO registrationRequestDTO);


    }
}
