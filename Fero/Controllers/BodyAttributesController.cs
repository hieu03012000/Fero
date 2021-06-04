using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/body-attributes")]
    public partial class BodyAttributesController : ControllerBase
    {
        private readonly IBodyAttributeService _bodyAttributeService;
        public BodyAttributesController(IBodyAttributeService bodyAttributeService){
            _bodyAttributeService=bodyAttributeService;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_bodyAttributeService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_bodyAttributeService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(BodyAttribute entity)
        {
            _bodyAttributeService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id,BodyAttribute entity)
        {
            _bodyAttributeService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,BodyAttribute entity)
        {
            _bodyAttributeService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_bodyAttributeService.Count());
        }
    }
}
