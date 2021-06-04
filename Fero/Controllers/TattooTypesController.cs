using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/tattoo-types")]
    public partial class TattooTypesController : ControllerBase
    {
        private readonly ITattooTypeService _tattooTypeService;
        public TattooTypesController(ITattooTypeService tattooTypeService){
            _tattooTypeService=tattooTypeService;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_tattooTypeService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_tattooTypeService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(TattooType entity)
        {
            _tattooTypeService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id,TattooType entity)
        {
            _tattooTypeService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,TattooType entity)
        {
            _tattooTypeService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_tattooTypeService.Count());
        }
    }
}
