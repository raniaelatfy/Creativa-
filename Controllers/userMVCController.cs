using Creativa.Identity;
using Creativa.Models;
using Creativa.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Controllers
{
    [Route("[controller]/[Action]")]
    public class UserMVCController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        /*
         ApplicationDbContext db;
        public GraduatesController(ApplicationDbContext d)
        {
            db = d;
        }
         */
        profileRepository profileRepository;
        public UserMVCController(profileRepository User)
        {
            this.profileRepository = User;

        }

        public async Task<ActionResult<IEnumerable<ModelViewUser>>> Getprofile()
        {
            return View(await profileRepository.GetAll());
        }


        //get profile
        public async Task<ActionResult<ModelViewUser>> GetUserProfile()
        {
            
            var _Profile = await profileRepository.Find(HttpContext.Session.GetString("username"));

            if (_Profile == null)
            {
                return NotFound();
            }
            ViewBag.id = _Profile.id;
            return View(_Profile);
        }




        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProfile(string id, ModelViewUser profile)
        //{
        //    if (id != profile.id)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        await profileRepository.Update(id, profile);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ModelViewUser(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}




        [HttpPost]
        public async Task<IActionResult> PutProfile(ModelViewUser profile)
        {
            var username = HttpContext.Session.GetString("username");

            if (username != profile.user_name)
            {
                return BadRequest();
            }
            try
            {
                await profileRepository.Update(username, profile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelViewUser(username))
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
        [HttpPost]
        public async Task<IActionResult> changePass(string oldPass, ModelViewUser profile)
        {
            if (oldPass != null && profile != null)
            {
                var username = HttpContext.Session.GetString("username");
                bool result = await profileRepository.changepass(username, oldPass, profile.password);
                ViewBag.result = result;
            }
            return NoContent();
        }


        private bool ModelViewUser(string username)
        {
            return profileRepository.Find(username) != null;
        }
    }
}
