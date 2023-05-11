using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaCare.Models
{
    public class Supplier
    {

        public int SuppilerId { get; set; }

        public string SuppilerName { get; set;}

        public string Email { get; set;}


        public int DrugId { get; set;}

        [ForeignKey("DrugId")]
        public Drug drug { get; set;}   


        public int Totel_Drugs { get; set;}

    }
}
