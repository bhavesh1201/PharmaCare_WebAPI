using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaCare.Models.DTO
{
    public class SupplierDTO
    {
        
        public int SuppilerId { get; set; }

        public string SuppilerName { get; set; }

        public string Email { get; set; }


        public int DrugId { get; set; }

      
    }
}
