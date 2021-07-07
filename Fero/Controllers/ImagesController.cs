using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Fero.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/images")]
    public partial class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService){
            _imageService=imageService;
        }

        /// <summary>
        /// Get Image in collection
        /// </summary>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        [HttpGet("{collectionId}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetImage(int collectionId)
        {
            return Ok(await _imageService.GetImage(collectionId));
        }

        //[HttpGet]
        //public IActionResult Gets()
        //{
        //    return Ok(_imageService.Get().ToList());
        //}
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_imageService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(Image entity)
        //{
        //    _imageService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,Image entity)
        //{
        //    _imageService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,Image entity)
        //{
        //    _imageService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_imageService.Count());
        //}
    }
}
