using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/body-part-types")]
    public partial class BodyPartTypesController : ControllerBase
    {
        private readonly IBodyPartTypeService _bodyPartTypeService;
        public BodyPartTypesController(IBodyPartTypeService bodyPartTypeService){
            _bodyPartTypeService=bodyPartTypeService;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_bodyPartTypeService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_bodyPartTypeService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(BodyPartType entity)
        {
            _bodyPartTypeService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id,BodyPartType entity)
        {
            _bodyPartTypeService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,BodyPartType entity)
        {
            _bodyPartTypeService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_bodyPartTypeService.Count());
        }
    }
}
