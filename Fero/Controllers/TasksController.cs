using Fero.Data.Services;
using Fero.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fero.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/tasks")]
    public partial class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService){
            _taskService=taskService;
        }

        /// <summary>
        /// check time to create task
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [HttpGet("check")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CheckTime(string modelId, DateTime begin, DateTime end)
        {
            return Ok(await _taskService.CheckValidTaskTime(modelId, begin,end));
        }

        /// <summary>
        /// Create free time for model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("free-time")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateFreeTime(CreateFreeTimeViewModel model)
        {
            return Ok(await _taskService.CreateFreeTime(model));
        }
        
        /// <summary>
        /// Create free time for model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("task")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateTask(CreateTaskViewModel model)
        {
            return Ok(await _taskService.CreateTask(model));
        }
        
        /// <summary>
        /// Task in casting
        /// </summary>
        /// <param name="castingId"></param>
        /// <returns></returns>
        [HttpGet("{modelId}/{castingId}/task")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetTaskByCasting(string modelId,int castingId)
        {
            return Ok(await _taskService.IncomingTaskByCasting(castingId, modelId));
        }


        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_taskService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(Task entity)
        //{
        //    _taskService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,Task entity)
        //{
        //    _taskService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,Task entity)
        //{
        //    _taskService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_taskService.Count());
        //}
    }
}
