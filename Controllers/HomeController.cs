using Castle.Core.Configuration;
using Creativa.Identity;
using Creativa.ModelView;
using Creativa.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Creativa.Controllers
{
    [Route("[controller]/[Action]")]


    public class HomeController : Controller
    {
        LoginRegisterRepository loginRegister;
        IRepository<EventModel> ev;
        public HomeController(IRepository<EventModel> e, LoginRegisterRepository login)
        {
            ev = e;
            this.loginRegister = login;
        }

        public async Task<ActionResult> Index()
        {
            List<EventModel> lis = await ev.GetAll();
            ViewBag.session = HttpContext.Session.GetString("username");
            return View(lis);
        }
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (await loginRegister.loginUser(model))
                {
                    HttpContext.Session.SetString("username", model.Username);
                    return RedirectToAction("Index");
                }
                ViewBag.valid = "UserName Or Password Not Correct";
                return View(model);
            }
            ViewBag.enterdata = "Should Enter username and Password";
            return View(model);

        }


        public ActionResult logout()
        {
            HttpContext.Session.SetString("username", "");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> register(UserRegisterModel model)
        {

            if (ModelState.IsValid)
            {
                if (await loginRegister.register(model))
                {
                    HttpContext.Session.SetString("username", model.Username);
                    return RedirectToAction("Index");
                }
                ViewBag.valid = "you should enter real data";
                return View(model);
            }
            ViewBag.enterdata = "Should Enter All Data";
            return View(model);
        }




        [HttpGet("{id}")]
        public ActionResult subscribe(int id)
        {
            string username = HttpContext.Session.GetString("username");

            if (username == null || username == "")
            {
                return RedirectToAction("login");
            }

            loginRegister.setEvent(username, id);
            return View();
        }



    }
}
