using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmaCare.Models.DTO
{
    public class DrugDTO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DrugName { get; set; }

        public float price { get; set; }    

        public DateTime ExpieryDate { get; set; }

        public String ImageUrl { get; set; }


    }
}
