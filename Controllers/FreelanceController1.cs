using Creativa.Identity;
using Creativa.Models;
using Creativa.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Controllers
{
    [Route("[controller]/[Action]")]


    public class FreelanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FreelanceController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public ActionResult Add() 
        {
            ViewBag.Branche = new SelectList(_context.Branches.ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Add(FreeLanceModel FM) 
        {
            if (ModelState.IsValid)
            {
                FreeLance F = new FreeLance();
                F.Name = FM.Name;
                F.LinkProfile = FM.LinkProfile;
                F.personality_ID = FM.personality_ID;
                F.Tech_used = FM.Tech_used;
                F.Type_project = FM.Type_project;
                F.duration = FM.duration;
                F.BranchId = FM.BranchId;
                F.Id = HttpContext.Session.GetString("username");
                _context.Add(F);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ViewBag.Branche = new SelectList(_context.Branches.ToList(), "Id", "Name");
                return View(FM);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
