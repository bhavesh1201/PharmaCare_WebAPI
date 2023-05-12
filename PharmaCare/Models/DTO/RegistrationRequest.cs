namespace PharmaCare.Models.DTO
{
    public class RegistrationRequest
    {

        public string Username { get; set; }    

        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
    }
}
