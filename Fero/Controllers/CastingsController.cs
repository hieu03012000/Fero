using Fero.Data.Models;
using Fero.Data.Services;
using Fero.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fero.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/castings")]
    public partial class CastingsController : ControllerBase
    {
        private readonly ICastingService _castingService;
        private readonly IThreadService _threadService;
        public CastingsController(ICastingService castingService, IThreadService threadService) {
            _castingService = castingService;
            _threadService = threadService;
        }

        /// <summary>
        /// casting model apply
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{modelId}/apply")]
        [Authorize]
        public async Task<IActionResult> GetCastingModelApply(string modelId)
        {
            return Ok(await _castingService.GetCastingModelApply(modelId));
        }

        /// <summary>
        /// casting model apply
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{modelId}/thread")]
        public async Task<IActionResult> StartThread(string modelId)
        {
            return Ok(_threadService.CheckCasting(modelId));
        }

        /// <summary>
        /// casting model apply
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetCastingByIds(CastingListIds castingIds)
        {
            return Ok(await _castingService.GetCastingListByIds(castingIds.CastingIds));
        }

        /// <summary>
        /// get all casting
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _castingService.GetCastingList());
        }
        
        /// <summary>
        /// incoming casting 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{modelId}/incoming")]
        [Authorize]
        public async Task<IActionResult> Gets(string modelId)
        {
            return Ok(await _castingService.GetCastingHaveTask(modelId));
        }

        /// <summary>
        /// search casting
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> SearchCasting([FromQuery]SearchValue value)
        {
            return Ok(await _castingService.SearchCasting(value));
        }

        /// <summary>
        /// Get casting by CusId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> CastingDetail(int id)
        {
            return Ok(await _castingService.ShowDetailCasting(id));
        }

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
