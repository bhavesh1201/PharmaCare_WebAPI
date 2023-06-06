using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaCare.Models
{
    public class Supplier
    {
        [Key]
        public int SuppilerId { get; set; }


        
        public string SuppilerName { get; set;}

        public string Email { get; set;}

        public int quntity { get; set; }
        public int? DrugId { get; set;}

        [ForeignKey("DrugId")]
        public virtual Drug Drugs { get; set;}



       

    }
}
