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
    [Route("api/v{version:apiVersion}/body-attributes")]
    public partial class BodyAttributesController : ControllerBase
    {
        private readonly IBodyAttributeService _bodyAttributeService;
        public BodyAttributesController(IBodyAttributeService bodyAttributeService){
            _bodyAttributeService=bodyAttributeService;
        }

        /// <summary>
        /// get measure list
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet("{modelId}/{type}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetMeasure(string modelId, string type)
        {
            return Ok(await _bodyAttributeService.GetMeasure(modelId, type));
        }

        /// <summary>
        /// Update measure
        /// </summary>
        /// <param name="viewModels"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateMeasure(ICollection<UpdateMeasureViewModel> viewModels)
        {
            return Ok(await _bodyAttributeService.UpdateMeasures(viewModels));
        }

        /// <summary>
        /// Update measure
        /// </summary>
        /// <param name="bodyPartId"></param>
        /// <returns></returns>
        [HttpGet("{bodyPartId}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<IActionResult> UpdateMeasure(int bodyPartId)
        {
            return Ok(await _bodyAttributeService.GetMeasuresByBodyPart(bodyPartId));
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_bodyAttributeService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(BodyAttribute entity)
        //{
        //    _bodyAttributeService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,BodyAttribute entity)
        //{
        //    _bodyAttributeService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,BodyAttribute entity)
        //{
        //    _bodyAttributeService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_bodyAttributeService.Count());
        //}
    }
}
