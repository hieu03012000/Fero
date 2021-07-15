using Fero.Data.Models;
using Fero.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Fero.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/body-parts")]
    public partial class BodyPartsController : ControllerBase
    {
        private readonly IBodyPartService _bodyPartService;
        public BodyPartsController(IBodyPartService bodyPartService) {
            _bodyPartService = bodyPartService;
        }

        /// <summary>
        /// get model body part
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpGet("{modelId}")]
        [Authorize]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetModelBodyPart(string modelId)
        {
            return Ok(await _bodyPartService.GetModelBodyPart(modelId));
        }


        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_bodyPartService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(BodyPart entity)
        //{
        //    _bodyPartService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,BodyPart entity)
        //{
        //    _bodyPartService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,BodyPart entity)
        //{
        //    _bodyPartService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_bodyPartService.Count());
        //}
    }
}
