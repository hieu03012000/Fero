using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/payment-types")]
    public partial class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;
        public PaymentTypesController(IPaymentTypeService paymentTypeService){
            _paymentTypeService=paymentTypeService;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_paymentTypeService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_paymentTypeService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(PaymentType entity)
        {
            _paymentTypeService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id,PaymentType entity)
        {
            _paymentTypeService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,PaymentType entity)
        {
            _paymentTypeService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_paymentTypeService.Count());
        }
    }
}
