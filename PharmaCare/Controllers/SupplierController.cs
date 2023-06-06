using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.Models;
using PharmaCare.Models.DTO;
using PharmaCare.Repository;
using PharmaCare.Repository.IRepository;
using System.Collections.Immutable;
using System.Net;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly ISuppilerRepository suppilerRepository;
        private readonly ILogger<SupplierDTO> _logger;   // Injected Logger Dependecy Injection
        protected APIResponses responses; // All responses return at one place
        private readonly IMapper mapper;

        public SupplierController(ISuppilerRepository _suppilerRepository, ILogger<SupplierDTO> logger, IMapper _mapper)
        {
            suppilerRepository = _suppilerRepository;
            _logger = logger;
            responses = new();
            mapper = _mapper;
        }




        #region Get all the suppliers

        [HttpGet] // This Get Fetches all the drug in form of list
        public async Task<ActionResult<List<Supplier>>> GetAllSupplier()
        {


            try
            {
                
                _logger.LogInformation("Getting All supplier information infomation");
                var temp = suppilerRepository.GetAllSupWithDrug();
               
                
                responses.HttpStatus = HttpStatusCode.OK;
                return Ok(temp.Result);

            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return Ok(responses.Result);



        }

        #endregion


        #region Get Specific Supplier
        [HttpGet("{Id}", Name = "GetSupplier")]  // This Get method fetches particular drug from the database
        public async Task<ActionResult<APIResponses>> GetSupplier(int Id)
        {


            try
            {

                if (Id == 0)
                {
                    _logger.LogError("Invalid Id is" + Id);
                    return BadRequest();
                }
                var temp = await suppilerRepository.GetAsync(u => u.SuppilerId == Id);
                if (temp == null)
                {
                    _logger.LogError("Id not found");
                    return NotFound();
                }
                _logger.LogInformation($"{temp.SuppilerName} has been Accessed");


                responses.Result = await suppilerRepository.GetAsync(u => u.SuppilerId == Id);
                responses.HttpStatus = HttpStatusCode.OK;
                return Ok(responses);
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return responses;

        }

        #endregion




        #region Add a new supplier
        [HttpPost] // This method inserts new supplier in database
        public async Task<ActionResult> AddSupplier([FromBody] Supplier supplier)
        {



            try
            {
                if (supplier == null)
                {
                    return BadRequest();
                }

                if (supplier.SuppilerId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                _logger.LogInformation($"{supplier.SuppilerName} has been added to database");
                //  drug.Id = _context.Drugs.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

                await suppilerRepository.CreateAsync(supplier);
                await suppilerRepository.SaveAsync();

                responses.Result = supplier;
                responses.HttpStatus = HttpStatusCode.Created;
                return Ok();
                // return CreatedAtRoute("GetDrug", new { id = drug.Id }, responses);
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return Ok();


        }

        #endregion




        #region Remove a supplier
        [HttpDelete("{Id}", Name = "DeleteSupplier")] // This method deletes existince drug from database
        public async Task<ActionResult<APIResponses>> DeleteSupplier(int Id)
        {

            try
            {
                if (Id == null)
                {
                    return BadRequest();
                }

                var drz = await suppilerRepository.GetAsync(u => u.SuppilerId == Id);

                if (drz == null)
                {
                    return BadRequest();
                }

                _logger.LogInformation($"{drz.SuppilerName} Has Been Deleted from Database");
                await suppilerRepository.RemoveAsync(drz);
                await suppilerRepository.SaveAsync();

                responses.HttpStatus = HttpStatusCode.NoContent;
                responses.IsSuccess = true;
                return Ok(responses);
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return responses;
        }


        #endregion




        #region Update Supplier Details
        [HttpPut("{Id}", Name = "UpdateSupplier")] // This method updates the drug
        public async Task<ActionResult> UpdateSupplier(int Id, SupplierDTO supplier)
        {

            try
            {

                if (Id == null || Id == 0 || Id != supplier.SuppilerId) return BadRequest();
                var drg = await suppilerRepository.GetAsync(u => u.SuppilerId == Id , tracked:false);





                //Id = drug.Id,


              drg=  mapper.Map<Supplier>(supplier);


                _logger.LogInformation($"{drg.SuppilerName} Has been updated");
                await suppilerRepository.UpdateAsync(drg);
                await suppilerRepository.SaveAsync();

                responses.HttpStatus = HttpStatusCode.NoContent;
                responses.IsSuccess = true;
                return Ok(responses.Result);
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return BadRequest(responses.Result);





        }
        #endregion
    }
}