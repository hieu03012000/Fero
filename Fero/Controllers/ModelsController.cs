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
    [Route("api/v{version:apiVersion}/models")]
    public partial class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;
        public ModelsController(IModelService modelService){
            _modelService=modelService;
        }
       
        /// <summary>
        /// Get all model list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _modelService.GetAllModel());
        }

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
        /// Get all image of model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{id}/images")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetModelImage(string id)
        {
            return Ok(await _modelService.GetAllModelImage(id));
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
        /// Update model status 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{id}/status/{status}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStatus(string id, int status)
        {
            return Ok(await _modelService.ChangeStatus(id, status));
        }

        /// <summary>
        /// Update profile model
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{id}/profile")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody]UpdateModelProfileViewModel entity)
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

        /// <summary>
        /// Delete model image
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{id}/image")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteImage(string id, DeleteImageViewModel entity)
        {
            return Ok(await _modelService.DeleteImage(id, entity));
        }
        
        /// <summary>
        /// Delete model image
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost("{id}/{collectionId}/image")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddImage(string id, int collectionId, AddImageViewModel entity)
        {
            return Ok(await _modelService.AddImage(id, collectionId, entity));
        }
        
        /// <summary>
        /// update avt
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{id}/avatar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAvatar(string id, UpdateAvatarViewModel entity)
        {
            return Ok(await _modelService.UpdateAvatar(entity));
        }
        
        /// <summary>
        /// Get task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{id}/tasks")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTask(string id)
        {
            return Ok(await _modelService.GetModelTask(id));
        }
        
        /// <summary>
        /// get model by mail
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{mail}/model")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetModelByMail(string mail)
        {
            return Ok(await _modelService.GetModelTaskByMail(mail));
        }
        
        ///// <summary>
        ///// Add model image
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //[MapToApiVersion("1.0")]
        //[HttpPost("{id}/image")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> AddImage(string id, AddImage entity)
        //{
        //    return Ok(await _modelService.(id, entity));
        //}


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
