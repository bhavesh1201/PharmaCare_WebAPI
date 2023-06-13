using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.Models.DTO;
using PharmaCare.Models;
using PharmaCare.Repository.IRepository;
using System.Net;
using AutoMapper;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        //Visibility changed to private of git - Test1
        private readonly ILogger<Order> _logger;   // Injected Logger Dependecy Injection
        protected APIResponses responses; // All responses return at one place
        private readonly IOrderRepository _orderRepository; //Injected Drug Dependency Injection
        private readonly IMapper mapper;

        public OrderController(ILogger<Order> logger, IOrderRepository orderRepository , IMapper _mapper)
        {
            this._logger = logger;
            _orderRepository = orderRepository;
            responses = new();
            mapper = _mapper;
        }



        #region Get All the order details
        [HttpGet] // This Get Fetches all the orders in form of list

        // [Authorize(Roles ="doctor")]
        public async Task<ActionResult<List<Order>>> GetAllOrder()
        {


            try
            {
                _logger.LogInformation("Getting All order infomarion");
                responses.Result = await _orderRepository.GetAllAsync();
                responses.HttpStatus = HttpStatusCode.OK;
                return Ok(responses.Result);

            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest();
            }

            return Ok(responses.Result);



        }
        #endregion




        #region Get Specific Order

        [HttpGet("{Id}", Name = "GetOrder")]  // This Get method fetches particular Order from the database
        public async Task<ActionResult<APIResponses>> GetOrder(int Id)
        {


            try
            {

                if (Id == 0)
                {
                    _logger.LogError("Invalid Id is" + Id);
                    return BadRequest();
                }
                var temp = await _orderRepository.GetAsync(u => u.OrderId == Id);
                if (temp == null)
                {
                    _logger.LogError("Id not found");
                    return NotFound();
                }


                responses.Result = await _orderRepository.GetAsync(u => u.OrderId == Id);
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



        #region Add new Order


        [HttpPost] // This method inserts new order in database
        public async Task<ActionResult> AddDrug([FromBody] Order order)
        {



            try
            {
                if (order == null)
                {
                    return BadRequest();
                }

                if (order.OrderId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                _logger.LogInformation($"{order.OrderId} has been added to database");
                //  drug.Id = _context.Drugs.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

                await _orderRepository.CreateAsync(order);
                await _orderRepository.SaveAsync();

                responses.Result = order;
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




        #region Delete Order

        [HttpDelete("{Id}", Name = "DeleteOrder")] // This method deletes existince order from database
        public async Task<ActionResult<APIResponses>> DeleteOrder(int Id)
        {

            try
            {
                if (Id == null)
                {
                    return BadRequest();
                }

                var drz = await _orderRepository.GetAsync(u => u.OrderId == Id);

                if (drz == null)
                {
                    return BadRequest();
                }

                _logger.LogInformation($"{drz.OrderId} Has Been Deleted from Database");
                await _orderRepository.RemoveAsync(drz);
                await _orderRepository.SaveAsync();

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




        #region Update order details
        [HttpPut("{Id}", Name = "UpdateOrder")] // This method updates the order
        public async Task<ActionResult> UpdateOrder(int Id, Order order)
        {

            try
            {

                if (Id == null || Id == 0 || Id != order.OrderId) return BadRequest();
                var drg = await _orderRepository.GetAsync(u => u.OrderId == Id);








                  drg.IsApproved = order.IsApproved;
               





                _logger.LogInformation($"{order.OrderId} Has been updated");
                await _orderRepository.UpdateAsync(drg);
                await _orderRepository.SaveAsync();

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
