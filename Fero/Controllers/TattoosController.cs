using Fero.Data.Services;
using FirebaseAdmin.Messaging;
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
    [Route("api/v{version:apiVersion}/tattoos")]
    public partial class TattoosController : ControllerBase
    {
        private readonly ITattooService _tattooService;
        public TattoosController(ITattooService tattooService){
            _tattooService=tattooService;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Gets()
        {
            // The topic name can be optionally prefixed with "/topics/".
            var topic = "MD0021";

            var incoming = new List<int>();
            incoming.Add(1);
            incoming.Add(2);
            incoming.Add(3);
            incoming.Add(4);
            // See documentation on defining a message payload.
            string listId = "";
            foreach (var casting in incoming)
            {
                listId += casting.ToString() + ",";
            }
            // See documentation on defining a message payload.
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "You have a message",
                    Body = "Some casting will close tomorrow"
                },
                Data = new Dictionary<string, string>()
                        {
                            { "castingId", listId },
                        },
                Topic = topic,
            };

            // Send a message to the devices subscribed to the provided topic.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_tattooService.Get(id));
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Create(Tattoo entity)
        //{
        //    _tattooService.Create(entity);
        //    return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        //}
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Update(int id,Tattoo entity)
        //{
        //    _tattooService.Update(entity);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,Tattoo entity)
        //{
        //    _tattooService.Delete(entity);
        //    return Ok();
        //}
        //[HttpGet("count")]
        //public IActionResult Count()
        //{
        //    return Ok(_tattooService.Count());
        //}
    }
}
