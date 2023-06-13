using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace PharmaCare.Models
{
    public class Admin
    {

        [Key]

        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name cannot be empty")]

        public string Name { get; set; }


        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        
        [Required(ErrorMessage = "Password Cannot be empty")]
        public string Password { get; set; }


        public int RoleId { get; set; }

       
      



    }
}
