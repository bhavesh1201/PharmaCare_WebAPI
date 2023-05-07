using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaCare.Models
{
    public class Drug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }

        


        public string DrugName { get; set; }

        public float price { get; set; }

        //public DateOnly ExpieryDate { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime ExpiryDate { get; set; }


        public String ImageUrl { get; set; }    




    }
}
