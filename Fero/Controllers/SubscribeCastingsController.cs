using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/subscribe-castings")]
    public partial class SubscribeCastingsController : ControllerBase
    {
        private readonly ISubscribeCastingService _subscribeCastingService;
        public SubscribeCastingsController(ISubscribeCastingService subscribeCastingService){
            _subscribeCastingService=subscribeCastingService;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_subscribeCastingService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            return Ok(_subscribeCastingService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(SubscribeCasting entity)
        {
            _subscribeCastingService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(string id,SubscribeCasting entity)
        {
            _subscribeCastingService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id,SubscribeCasting entity)
        {
            _subscribeCastingService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_subscribeCastingService.Count());
        }
    }
}
