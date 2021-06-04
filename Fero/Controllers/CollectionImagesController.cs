using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Fero.Controllers
{
    [ApiController]
    [Route("api/collection-images")]
    public partial class CollectionImagesController : ControllerBase
    {
        private readonly ICollectionImageService _collectionImageService;
        public CollectionImagesController(ICollectionImageService collectionImageService){
            _collectionImageService=collectionImageService;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_collectionImageService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_collectionImageService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(CollectionImage entity)
        {
            _collectionImageService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id,CollectionImage entity)
        {
            _collectionImageService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,CollectionImage entity)
        {
            _collectionImageService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_collectionImageService.Count());
        }
    }
}
