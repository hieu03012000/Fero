using Fero.Data.Services;
using Fero.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fero.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/models")]
    public partial class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;
        public ModelsController(IModelService modelService){
            _modelService=modelService;
        }
        //[MapToApiVersion("1.0")]
        //[HttpGet]
        //public IActionResult Gets()
        //{
        //    return Ok(_modelService.Get().ToList());
        //} 

        /// <summary>
        /// Find model by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _modelService.GetModelById(id));
        }

        /// <summary>
        /// Create model account
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateModelAccountViewModel entity)
        {
            return Ok(await _modelService.CreateModelAccount(entity));
        }

        /// <summary>
        /// Update profile model
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{id}/profile")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateModelProfileViewModel entity)
        {
            return Ok(await _modelService.UpdateProfileModel(entity));
        }

        /// <summary>
        /// Update model style
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{id}/style")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateModelStyle(string id, UpdateModelStyleViewModel entity)
        {
            return Ok(await _modelService.UpdateModelStyle(id, entity));
        }

        //[MapToApiVersion("1.0")]
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id,Model entity)
        //{
        //    _modelService.DeleteAsync(entity);
        //    return Ok();
        //}
        //[MapToApiVersion("1.0")]
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_modelService.Count());
        //}
    }
}
