using PharmaCare.Models.DTO;

namespace PharmaCare.Data
{
    public class DrugStaic
    {
        public static List<DrugDTO> Drugs = new List<DrugDTO>{
                new DrugDTO {Id = 1 , DrugName = "Acetopylon" , price=23f },
                new DrugDTO {Id = 2 ,DrugName ="Methylon", price=43f }


            };

    }
}
