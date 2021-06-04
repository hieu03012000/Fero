using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/payment-accounts")]
    public partial class PaymentAccountsController : ControllerBase
    {
        private readonly IPaymentAccountService _paymentAccountService;
        public PaymentAccountsController(IPaymentAccountService paymentAccountService){
            _paymentAccountService=paymentAccountService;
        }
        //[HttpGet]
        //public IActionResult Gets()
        //{
        //    return Ok(_paymentAccountService.Get().ToList());
        //}
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_paymentAccountService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(PaymentAccount entity)
        //{
        //    _paymentAccountService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,PaymentAccount entity)
        //{
        //    _paymentAccountService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,PaymentAccount entity)
        //{
        //    _paymentAccountService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_paymentAccountService.Count());
        //}
    }
}
