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

        Task<List<User>> GetAllUser();




        Task<string> Login(UserDTO user);

        Task<User> GetUser(UserDTO user);

        Task<bool> Register(User user);


    }
}
