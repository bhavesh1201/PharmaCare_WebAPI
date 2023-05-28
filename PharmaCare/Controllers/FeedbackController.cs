using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.Models.DTO;
using PharmaCare.Models;
using PharmaCare.Repository.IRepository;
using System.Net;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {


        private readonly IFeedbackRepository feedbackRepository;
        private readonly ILogger<SupplierDTO> _logger;   // Injected Logger Dependecy Injection
        protected APIResponses responses; // All responses return at one place
        private readonly IMapper mapper;

        public FeedbackController(IFeedbackRepository _feedbackRepository, ILogger<SupplierDTO> logger, IMapper _mapper)
        {
            feedbackRepository = _feedbackRepository;
            _logger = logger;
            responses = new();
            mapper = _mapper;
        }




        #region Get all the feedbacks

        [HttpGet] // This Get Fetches all the feedbacks in form of list
        public async Task<ActionResult<List<Supplier>>> GetAllFeedbacks()
        {


            try
            {
                _logger.LogInformation("Getting All Feedbacks");
                responses.Result = await feedbackRepository.GetAllAsync();
                responses.HttpStatus = HttpStatusCode.OK;
                return Ok(responses);

            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
                _logger.LogInformation(ex.Message);
            }

            return Ok(responses);



        }

        #endregion


        #region Get Specific feedback
        [HttpGet("{Id}", Name = "Get Feedback")]  // This Get method fetches particular feedback from the database
        public async Task<ActionResult<APIResponses>> GetFeedback(int Id)
        {


            try
            {

                if (Id == 0)
                {
                    _logger.LogError("Invalid Id is" + Id);
                    return BadRequest();
                }
                var temp = await feedbackRepository.GetAsync(u => u.Id == Id);
                if (temp == null)
                {
                    _logger.LogError("Id not found");
                    return NotFound();
                }
                _logger.LogInformation($"{temp.Name} has given feedback and accessed");

                responses.Result = await feedbackRepository.GetAsync(u => u.Id == Id);
                responses.HttpStatus = HttpStatusCode.OK;
                return Ok(responses);
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
                _logger.LogInformation(ex.Message);
            }

            return responses;

        }

        #endregion




        #region Add a new Feedback
        [HttpPost] // This method inserts new feedback in database
        public async Task<ActionResult> AddFeedback([FromBody] Feedback feedback)
        {



            try
            {
                if (feedback == null)
                {
                    return BadRequest();
                }

                if (feedback.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

               // _logger.LogInformation($"{feedback.SuppilerName} has been added to database");
                //  drug.Id = _context.Drugs.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

                await feedbackRepository.CreateAsync(feedback);
                await feedbackRepository.SaveAsync();

                responses.Result = feedback;
                responses.HttpStatus = HttpStatusCode.Created;
                return Ok();
                // return CreatedAtRoute("GetDrug", new { id = drug.Id }, responses);
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
                _logger.LogInformation(ex.Message);
            }

            return Ok();


        }

        #endregion




        #region Remove a feedback
        [HttpDelete("{Id}", Name = "Delete Feedback")] // This method deletes existince feedback from database
        public async Task<ActionResult<APIResponses>> DeleteFeedback(int Id)
        {

            try
            {
                if (Id == null)
                {
                    return BadRequest();
                }

                var drz = await feedbackRepository.GetAsync(u => u.Id == Id);

                if (drz == null)
                {
                    return BadRequest();
                }

                _logger.LogInformation($"{drz.Name} feedback Has Been Deleted from Database");
                await feedbackRepository.RemoveAsync(drz);
                await feedbackRepository.SaveAsync();

                responses.HttpStatus = HttpStatusCode.NoContent;
                responses.IsSuccess = true;
                return Ok(responses);
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
                _logger.LogInformation(ex.Message);
            }

            return responses;
        }


        #endregion

    }
}
