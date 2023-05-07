using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Models.DTO;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaController : ControllerBase
    {
        private readonly ILogger<DrugDTO> _logger;
        private readonly PharmacyContext _context;

        public PharmaController(ILogger<DrugDTO> logger, PharmacyContext context)
        {
            this._logger = logger;
            _context = context; 
        }
        [HttpGet]
        public ActionResult<IEnumerable<DrugDTO>> GetAllDrug() {

            _logger.LogInformation("Getting All drug infomarion");
            return Ok(_context.Drugs.ToList());

        }
        [HttpGet("{Id}", Name = "GetDrug")]
        public ActionResult<DrugDTO> GetDrug(int Id)
        {

            if (Id == 0)
            {
                _logger.LogError("Invalid Id is" + Id);
                return BadRequest();
            }
            var temp = _context.Drugs.FirstOrDefault(u => u.Id == Id);
            if (temp == null)
            {
                _logger.LogError("Id not found");
                return NotFound();
            }
            _logger.LogInformation($"{temp.DrugName} has been Accessed");
            return Ok(temp);

        }


        [HttpPost]
        public ActionResult<Drug> AddDrug([FromBody] Drug drug)
        {
            if (drug == null)
            {
                return BadRequest();
            }

            if (drug.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _logger.LogInformation($"{drug.DrugName} has been added to database");
          //  drug.Id = _context.Drugs.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            _context.Drugs.Add(drug);
            _context.SaveChanges();
            return CreatedAtRoute("GetDrug", new { id = drug.Id }, drug);



        }


        [HttpDelete("{Id}", Name = "DeleteDrug")]
        public IActionResult DeleteDrug(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var drz = _context.Drugs.Where(u => u.Id == Id).FirstOrDefault();

            _logger.LogInformation($"{drz.DrugName} Has Been Deleted from Database");
            _context.Drugs.Remove(drz);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{Id}", Name = "UpdateDrug")]
        public IActionResult Update(int Id, [FromBody] Drug drug)
        {

            if (Id == null || Id == 0 || Id != drug.Id) return BadRequest();
            var drg = _context.Drugs.Where(u => u.Id == Id).FirstOrDefault();





            //Id = drug.Id,
            drg.price = drug.price;
            drg.DrugName = drug.DrugName;
            drg.ExpiryDate = drug.ExpiryDate;


            drg.ImageUrl = drug.ImageUrl;
           


            _logger.LogInformation($"{drug.DrugName} Has been updated");
            _context.Drugs.Update(drg);
            _context.SaveChanges(); 
            return Ok();


        }

        [HttpPatch("{Id}", Name = "PartialUpdateDrug")]

        public IActionResult PartialUpdateDrug(int Id, JsonPatchDocument<DrugDTO> patch)
        {
            if (Id == null || Id == 0)
            {
                return BadRequest();
            }
            var temp = _context.Drugs.AsNoTracking().Where(u => u.Id == Id).FirstOrDefault();
            if (temp == null) return BadRequest();


            DrugDTO drg = new()
            {
                Id = temp.Id,
                DrugName = temp.DrugName,
                price = temp.price,
                ExpieryDate = temp.ExpiryDate,
                ImageUrl = temp.ImageUrl,


            };

            patch.ApplyTo(drg, ModelState);



            Drug tempz = new Drug()
            {
                Id= drg.Id,
            price = drg.price,
            DrugName = drg.DrugName,
            ExpiryDate = drg.ExpieryDate,
            
            ImageUrl = drg.ImageUrl
        };
            
          
            if(!ModelState.IsValid)return BadRequest();

            _logger.LogInformation($"{temp.DrugName} Has been updated");
            _context.Drugs.Update(tempz);
            _context.SaveChanges();

            return Ok();

        }



    }
}
