using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/brand-categories")]
    public partial class BrandCategoriesController : ControllerBase
    {
        private readonly IBrandCategoryService _brandCategoryService;
        public BrandCategoriesController(IBrandCategoryService brandCategoryService){
            _brandCategoryService=brandCategoryService;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_brandCategoryService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_brandCategoryService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(BrandCategory entity)
        {
            _brandCategoryService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id,BrandCategory entity)
        {
            _brandCategoryService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,BrandCategory entity)
        {
            _brandCategoryService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_brandCategoryService.Count());
        }
    }
}
