using System.ComponentModel.DataAnnotations;

namespace PharmaCare.Models
{
    public class Doctor
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }



        public string Email {get; set;} 

       
        public int PhoneNumber { get; set; }



        public int Role { get; set; }


       
        public string Password { get; set; }
    }
}
