using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/body-attribute-types")]
    public partial class BodyAttributeTypesController : ControllerBase
    {
        private readonly IBodyAttributeTypeService _bodyAttributeTypeService;
        public BodyAttributeTypesController(IBodyAttributeTypeService bodyAttributeTypeService){
            _bodyAttributeTypeService=bodyAttributeTypeService;
        }
        //[HttpGet]
        //public IActionResult Gets()
        //{
        //    return Ok(_bodyAttributeTypeService.Get().ToList());
        //}
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_bodyAttributeTypeService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(BodyAttributeType entity)
        //{
        //    _bodyAttributeTypeService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,BodyAttributeType entity)
        //{
        //    _bodyAttributeTypeService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,BodyAttributeType entity)
        //{
        //    _bodyAttributeTypeService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_bodyAttributeTypeService.Count());
        //}
    }
}
