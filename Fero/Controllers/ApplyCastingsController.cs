using Fero.Data.Models;
using Fero.Data.Services;
using Fero.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Fero.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/apply-castings")]
    public partial class ApplyCastingsController : ControllerBase
    {
        private readonly IApplyCastingService _applyCastingService;
        public ApplyCastingsController(IApplyCastingService applyCastingService){
            _applyCastingService=applyCastingService;
        }

        /// <summary>
        /// model apply casting
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateApplyCastingViewModel entity)
        {
            return Ok(await _applyCastingService.ApplyCasting(entity));
        }

        /// <summary>
        /// check is aplly casting
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("check")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CkeckApplyCasting(string modelId, int castingId)
        {
            return Ok(await _applyCastingService.CheckApplyCasting(modelId, castingId));
        }

        /// <summary>
        /// cancel cassting
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="castingId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpDelete("cancel")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteApplyCasting(string modelId, int castingId)
        {
            return Ok(await _applyCastingService.CancelApplyCasting(modelId, castingId));
        }

        //[MapToApiVersion("1.0")]
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(string id)
        //{
        //    return Ok(_applyCastingService.Get(id));
        //}

        //[MapToApiVersion("1.0")]
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(string id,ApplyCasting entity)
        //{
        //    _applyCastingService.Update(entity);
        //    return Ok();
        //}
        //[MapToApiVersion("1.0")]
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id,ApplyCasting entity)
        //{
        //    _applyCastingService.Delete(entity);
        //    return Ok();
        //}
        //[MapToApiVersion("1.0")]
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_applyCastingService.Count());
        //}
    }
}
