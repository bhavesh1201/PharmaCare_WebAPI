using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PharmaCare.Data;
using PharmaCare.Helper;
using PharmaCare.Models;
using PharmaCare.Models.DTO;
using PharmaCare.Repository.IRepository;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace PharmaCare.Repository
{
    public class UserRepository : IUserRepository
    {
        private string SecretKey;
        private readonly PharmacyContext context;
        public UserRepository(PharmacyContext _context, IConfiguration configuration)
        {
            context = _context;
            SecretKey = configuration.GetValue<string>("ApiSettings:Secret");

        }
        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await context.Users.AnyAsync(x => x.email == email);
        }

        public string CheckPasswordAsync(string password)
        {

            StringBuilder sb = new StringBuilder();
            Regex validateGuidRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (!validateGuidRegex.IsMatch(password))
            {
                sb.Append("Password Should be Alphanumeric");

            }
            return sb.ToString();
        }

        public async Task<bool> CheckUserNameExistsAsync(string username)
        {
            return await context.Users.AnyAsync(x => x.username == username);
        }

        public async Task<List<User>> GetAllUser()
        {
            return await context.Users.ToListAsync();
        }

        public string JWT_Token(User user)
        {
            var temp = context.Users.Where(u => u.username.ToLower() == user.username && u.password == user.password).FirstOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);


            var TokenDiscript = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role,temp.role),
                    new Claim(ClaimTypes.Name,temp.name),
                    new Claim(ClaimTypes.Email,temp.email)


                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


            };

            var token = tokenHandler.CreateToken(TokenDiscript);

            return tokenHandler.WriteToken(token);
        }

        public async Task<string> Login(UserDTO user)
        {
            var temp = await context.Users.FirstOrDefaultAsync(x => x.username == user.UserName);
            temp.Token = JWT_Token(temp);
            return temp.Token;
        }

        public async Task<bool> Register(User user)
        {
            user.password = PasswordHasher.HashPassword(user.password);
            user.Token = "";
            user.role = "Doctor";

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUser(UserDTO user)
        {
            var temp = await context.Users.FirstOrDefaultAsync(x => x.username == user.UserName);
            return temp;
        }


        public async Task <bool> Delete(int id)
        {

            var temp = await context.Users.FirstOrDefaultAsync(x => x.id == id);
            context.Users.Remove(temp);
            context.SaveChanges();


            return  true;

        }
       
    }
}
