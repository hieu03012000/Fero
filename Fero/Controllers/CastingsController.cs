using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/castings")]
    public partial class CastingsController : ControllerBase
    {
        private readonly ICastingService _castingService;
        public CastingsController(ICastingService castingService){
            _castingService=castingService;
        }
        //[HttpGet]
        //public IActionResult Gets()
        //{
        //    return Ok(_castingService.Get().ToList());
        //}
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_castingService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(Casting entity)
        //{
        //    _castingService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,Casting entity)
        //{
        //    _castingService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,Casting entity)
        //{
        //    _castingService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_castingService.Count());
        //}
    }
}
