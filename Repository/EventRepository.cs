using Creativa.Identity;
using Creativa.Models;
using Creativa.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Repository
{
    public class EventRepository : IRepository<EventModel>
    {
        ApplicationDbContext db;
        public EventRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<EventModel>> GetAll()
        {
            List<Event> Events = await db.Events.ToListAsync();
            List<EventModel> TheEvents = new List<EventModel>();
            foreach (var item in Events)
            {
                EventModel e = new EventModel();
                e.id = item.Id;
                e.Img = item.Img;
                e.desc = item.Desc;
                e.address = item.Address;
                e.date = item.Date;
                e.branch_id = item.BranchId;

                //e.img.Equals(item.img);
                // e.img = " ";
                e.org_id = item.Organizationid;
                TheEvents.Add(e);
            }
            return TheEvents;
        }



        public async Task<List<Organization>> GetAllOrg()
        {
            return await db.Organizations.ToListAsync();
        }

        public async Task Add(EventModel item)
        {
            Event e = new Event();
            e.Address = item.address;
            e.Date = item.date;
            e.Desc = item.desc;
            //e.id = item.id;
            e.Organizationid = item.org_id;
            e.BranchId = item.branch_id;
            db.Add(e);
            db.Database.EnsureCreated();
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Event CurrentEvent = db.Events.Where(n => n.Id == id).FirstOrDefault();
            db.Events.Remove(CurrentEvent);
            await db.SaveChangesAsync();
        }

        public async Task Update(int id, EventModel item)
        {
            Event found = db.Events.Find(id);
            found.Address = item.address;
            found.Date = item.date;
            found.Desc = item.desc;
            found.Organizationid = item.org_id;
            found.BranchId = item.branch_id;

            await db.SaveChangesAsync();
        }
        public async Task<EventModel> Find(int id)
        {
            Event _event = await db.Events.FindAsync(id);
            if (_event == null)
                return null;
            else
            {
                EventModel _EventModel = new EventModel();
                _EventModel.id = _event.Id;
                _EventModel.address = _event.Address;
                _EventModel.date = _event.Date;
                _EventModel.desc = _event.Desc;
                _EventModel.org_id = _event.Organizationid;
                _EventModel.branch_id = _event.BranchId;
                return _EventModel;
            }


        }

       

    }

}
