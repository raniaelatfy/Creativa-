using Creativa.Identity;
using Creativa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Controllers
{
    [Route("[controller]/[Action]")]


    public class GraduatesController : Controller
    {
        ApplicationDbContext db;
        public GraduatesController(ApplicationDbContext d)
        {
            db = d;
        }
        public async Task<ActionResult> Graduate()
        {
            //get the tracks in viewbag
            ViewBag.tracks = new SelectList(db.Tracks.ToList(), "Id", "Name");
            return View();
        }

        [HttpGet("{trackId}")]
        public ActionResult GraduateFrom(int? trackId)
        {
            ViewBag.graduateUser = null;
            //ViewBag.graduateUser = null;
            if (trackId != null)
            {
                /*
                    select * 
                    from UserTable u
                    where u.Id = (select id from Graduate_Froms g where g.trackId = 2)
                 */
                List<string> lis = db.Graduate_Froms.Where(x => x.trackId == trackId).Select(x => x.Id).ToList();
                List<User> lUser = new List<User>();
                foreach (var item in lis)
                {
                    User u = new User();
                    u = db.User.Where(c => c.Id == item).FirstOrDefault();
                    lUser.Add(u);
                }
                ViewBag.graduateUser = lUser;
                return PartialView("PartialViewGraduate");
            }
            else
            {
                return PartialView();

            }
        }
    }
}