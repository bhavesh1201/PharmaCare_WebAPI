using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.Models;
using PharmaCare.Models.DTO;
using PharmaCare.Repository.IRepository;

namespace PharmaCare.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> CheckEmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public string CheckPasswordAsync(string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserNameExistsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<User>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public string JWT_Token(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
