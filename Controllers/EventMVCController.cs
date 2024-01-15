using Creativa.ModelView;
using Creativa.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class EventMVCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

            IRepository<EventModel> EventRepository;


            public EventMVCController(IRepository<EventModel> Event)
            {
                this.EventRepository = Event;
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

                return View(_Event);
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
