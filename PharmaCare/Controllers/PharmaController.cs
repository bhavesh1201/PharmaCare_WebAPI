using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult<IEnumerable<DrugDTO>> GetAllDrug() {


            return Ok(DrugStaic.Drugs);

        }
        [HttpGet("{Id}", Name = "GetDrug")]
        public ActionResult<DrugDTO> GetDrug(int Id)
        {

            if (Id == 0)
                return BadRequest();

            var temp = DrugStaic.Drugs.FirstOrDefault(u => u.Id == Id);
            if (temp == null) return NotFound();

            return Ok(temp);

        }


        [HttpPost]
        public ActionResult<DrugDTO> AddDrug([FromBody] DrugDTO drug)
        {
            if (drug == null)
            {
                return BadRequest();
            }

            if (drug.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            drug.Id = DrugStaic.Drugs.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            DrugStaic.Drugs.Add(drug);
            return CreatedAtRoute("GetDrug", new { id = drug.Id }, drug);



        }


        [HttpDelete("{Id}", Name = "DeleteDrug")]
        public IActionResult DeleteDrug(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var drz = DrugStaic.Drugs.Where(u => u.Id == Id).FirstOrDefault();


            DrugStaic.Drugs.Remove(drz);
            return Ok();
        }

        [HttpPut("{Id}", Name = "UpdateDrug")]
        public IActionResult Update(int Id, [FromBody] DrugDTO drug)
        {

            if (Id == null || Id == 0 || Id != drug.Id) return BadRequest();
            var temp = DrugStaic.Drugs.Where(u => u.Id == Id).FirstOrDefault();
            temp.price = drug.price;
            temp.DrugName = drug.DrugName;
            return Ok();


        }

        [HttpPatch("{Id}", Name = "PartialUpdateDrug")]

        public IActionResult PartialUpdateDrug(int Id, JsonPatchDocument<DrugDTO> patch)
        {
            if (Id == null || Id == 0)
            {
                return BadRequest();
            }
            var temp =  DrugStaic.Drugs.Where(u=>u.Id== Id).FirstOrDefault();
            if (temp == null) return BadRequest();
             
            patch.ApplyTo(temp,ModelState);
            if(!ModelState.IsValid)return BadRequest();


            return Ok();

        }



    }
}
