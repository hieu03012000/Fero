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
    [Route("api/v{version:apiVersion}/styles")]
    public partial class StylesController : ControllerBase
    {
        private readonly IStyleService _styleService;
        public StylesController(IStyleService styleService){
            _styleService=styleService;
        }

        /// <summary>
        /// Get all style
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_styleService.Get().ToList());
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_styleService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(Style entity)
        //{
        //    _styleService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,Style entity)
        //{
        //    _styleService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,Style entity)
        //{
        //    _styleService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_styleService.Count());
        //}
    }
}
