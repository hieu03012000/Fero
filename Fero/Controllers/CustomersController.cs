using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fero.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/customers")]
    public partial class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICastingService _castingService;
        public CustomersController(ICustomerService customerService, ICastingService castingService)
        {
            _customerService = customerService;
            _castingService = castingService;
        }

        /// <summary>
        /// Get casting by CusId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}/castings")]
        public async Task<IActionResult> Gets(string id)
        {
            return Ok(await _castingService.GetCasting(id));
        }


        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(string id)
        //{
        //    return Ok(_customerService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(Customer entity)
        //{
        //    _customerService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(string id,Customer entity)
        //{
        //    _customerService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id,Customer entity)
        //{
        //    _customerService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_customerService.Count());
        //}
    }
}
