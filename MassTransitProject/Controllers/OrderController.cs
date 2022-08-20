using MassTransit;
using MassTransitProject.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MassTransitProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        readonly ILogger<OrderController> _logger;
        readonly IRequestClient<SubmitOrder> _submitOrderRequestClient;

        public OrderController(ILogger<OrderController> logger, IRequestClient<SubmitOrder> submitOrderRequestClient)
        {
            _logger = logger;
            _submitOrderRequestClient = submitOrderRequestClient; 
        }


        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string custumerNumber)
        {
            var (acepted, rejected) = await _submitOrderRequestClient.GetResponse<OrderSubmitSuccess, OrderSubmitRejected>(new
            {
                id = id,
                TimeStamp = InVar.Timestamp,
                CustomerNumber = custumerNumber
            });

            if (acepted.IsCompletedSuccessfully)
            {
                var response = await acepted;
                return Accepted(response);
            }
            else
            {
                var response = await rejected;
                return BadRequest(response.Message);

            }

        }


























       /* // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
