using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Models.DTO;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaController : ControllerBase
    {

        [HttpGet] 
        public IEnumerable<DrugDTO> GetAllDrug() {


            return DrugStaic.Drugs;
 
        }
        [HttpGet("Id")]
        public DrugDTO GetDrug(int Id)
        {


            return DrugStaic.Drugs.FirstOrDefault(u => u.Id == Id);

        }

    }
}
