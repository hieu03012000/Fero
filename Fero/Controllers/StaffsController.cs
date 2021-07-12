using Fero.Data.ViewModels;
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
    [Route("api/v{version:apiVersion}/staffs")]
    public partial class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IModelService _modelService;
        public StaffsController(IStaffService staffService,
            IModelService modelService){
            _modelService = modelService;
            _staffService=staffService;
        }


        /// <summary>
        /// get staff
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoginStaff(StaffLoginViewModel viewModel)
        {
            return Ok(await _staffService.LoginStaff(viewModel.Email, viewModel.Password));
        }


        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(Staff entity)
        //{
        //    _staffService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(string id,Staff entity)
        //{
        //    _staffService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id,Staff entity)
        //{
        //    _staffService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_staffService.Count());
        //}
    }
}
