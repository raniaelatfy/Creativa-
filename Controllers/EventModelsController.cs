
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Creativa.Identity;
using Creativa.ModelView;
using Creativa.Repository;
using Microsoft.AspNetCore.Authorization;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Creativa.Models;

namespace Creativa.Controllers
{
    
   // [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class EventModelsController : ControllerBase
    {
        IRepository<EventModel> EventRepository;
        IWebHostEnvironment _environment;
        private readonly ILogger _logger;
       

        public EventModelsController(IRepository<EventModel> Event, IWebHostEnvironment env, ILogger<EventModel> logger)
        {
            this.EventRepository = Event;
            this._environment = env;
            this._logger = logger;
        }
        // GET: api/EventModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventModel>>> GetEventModel()
        {
            return await EventRepository.GetAll();
        }

        


        // GET: api/EventModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel>> GetEventModel(int id)
        {
            var _Event = await EventRepository.Find(id);

            if (_Event == null)
            {
                return NotFound();
            }

            return _Event;
        }

        // PUT: api/EventModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventModel(int id, EventModel eventModel)
        {
            if (id != eventModel.id)
            {
                return BadRequest();
            }
            try
            {
                await EventRepository.Update(id, eventModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/EventModels
        [HttpPost]

        public async Task<ActionResult<EventModel>> PostEventModel(EventModel eventModel)
        {
            await EventRepository.Add(eventModel);
            return CreatedAtAction("GetEventModel", new { id = eventModel.id }, eventModel);
        }

        // DELETE: api/EventModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventModel(int id)
        {
            var Event = await EventRepository.Find(id);
            if (Event == null)
            {
                return NotFound();
            }
            await EventRepository.Delete(id);
            return NoContent();
        }
    
        private bool EventModelExists(int id)
        {
        return EventRepository.Find(id) != null;
        }
    }
}
