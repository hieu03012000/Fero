using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/apply-castings")]
    public partial class ApplyCastingsController : ControllerBase
    {
        private readonly IApplyCastingService _applyCastingService;
        public ApplyCastingsController(IApplyCastingService applyCastingService){
            _applyCastingService=applyCastingService;
        }
        /// <summary>
        /// ahihi
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_applyCastingService.Get().ToList());
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            return Ok(_applyCastingService.Get(id));
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(ApplyCasting entity)
        {
            _applyCastingService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(string id,ApplyCasting entity)
        {
            _applyCastingService.Update(entity);
            return Ok();
        }
        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id,ApplyCasting entity)
        {
            _applyCastingService.Delete(entity);
            return Ok();
        }
        [MapToApiVersion("1.0")]
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_applyCastingService.Count());
        }
    }
}
