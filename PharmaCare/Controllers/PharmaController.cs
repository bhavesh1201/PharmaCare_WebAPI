﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Models.DTO;
using PharmaCare.Repository.IRepository;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaController : ControllerBase
    {

        //Visibility changed to private of git - Test1
        private readonly ILogger<DrugDTO> _logger;   // Injected Logger Dependecy Injection
        protected APIResponses responses; // All responses return at one place
        private readonly IDrugRepository _drugRepository; //Injected Drug Dependency Injection

        public PharmaController(ILogger<DrugDTO> logger, IDrugRepository drugRepository)
        {
            this._logger = logger;
             _drugRepository = drugRepository;
            responses = new();
        }
        [HttpGet] // This Get Fetches all the drug in form of list
        public  async Task<ActionResult<IEnumerable<DrugDTO>>> GetAllDrug() {

            _logger.LogInformation("Getting All drug infomarion");
            return Ok(await _drugRepository.GetAllAsync());
            

        }
        [HttpGet("{Id}", Name = "GetDrug")]  // This Get method fetches particular drug from the database
        public async Task<ActionResult<DrugDTO>> GetDrug(int Id)
        {

            if (Id == 0)
            {
                _logger.LogError("Invalid Id is" + Id);
                return BadRequest();
            }
            var temp = await _drugRepository.GetAsync(u=>u.Id==Id);
            if (temp == null)
            {
                _logger.LogError("Id not found");
                return NotFound();
            }
            _logger.LogInformation($"{temp.DrugName} has been Accessed");
            return Ok(temp);

        }


        [HttpPost] // This method inserts new drug in database
        public async Task<ActionResult<Drug>> AddDrug([FromBody] Drug drug)
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

          await _drugRepository.CreateAsync(drug);
          await  _drugRepository.SaveAsync();
            return CreatedAtRoute("GetDrug", new { id = drug.Id }, drug);



        }


        [HttpDelete("{Id}", Name = "DeleteDrug")] // This method deletes existince drug from database
        public async Task<IActionResult> DeleteDrug(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var drz = await _drugRepository.GetAsync(u => u.Id == Id);

            if (drz == null)
            {
                return BadRequest();
            }

            _logger.LogInformation($"{drz.DrugName} Has Been Deleted from Database");
           await _drugRepository.RemoveAsync(drz);
           await _drugRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{Id}", Name = "UpdateDrug")] // This method updates the drug
        public async Task<IActionResult> Update(int Id, [FromBody] Drug drug)
        {

            if (Id == null || Id == 0 || Id != drug.Id) return BadRequest();
            var drg = await _drugRepository.GetAsync(u => u.Id == Id);





            //Id = drug.Id,
            drg.price = drug.price;
            drg.DrugName = drug.DrugName;
            drg.ExpiryDate = drug.ExpiryDate;


            drg.ImageUrl = drug.ImageUrl;
           


            _logger.LogInformation($"{drug.DrugName} Has been updated");
          await _drugRepository.UpdateAsync(drg);
             await _drugRepository.SaveAsync(); 
            return Ok();


        }

        [HttpPatch("{Id}", Name = "PartialUpdateDrug")] // this method updates the particular feild of drug

        public async Task<IActionResult> PartialUpdateDrug(int Id, JsonPatchDocument<DrugDTO> patch)
        {
            if (Id == null || Id == 0)
            {
                return BadRequest();
            }
            var temp = await _drugRepository.GetAsync(u => u.Id == Id,false);
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
             await _drugRepository.UpdateAsync(tempz);
           await _drugRepository.SaveAsync();

            return Ok();

        }



    }
}
