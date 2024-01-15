using Creativa.Identity;
using Creativa.Models;
using Creativa.ModelView;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Repository
{
    public class LoginRegisterRepository
    {
        ApplicationDbContext db;
        UserManager<ApplicationUser> userManager;
        public LoginRegisterRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public async Task<bool> loginUser(LoginModel model)
        {
            var user = await userManager.CheckPasswordAsync
                (await userManager.FindByNameAsync(model.Username), model.Password);
          if (user)
            {
                return true;
            }
                
            return false;
        }

        public async Task<bool> register(UserRegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return false;
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            string uniqueFileName = null;
            if (model.img != null)
            {
                string uploadsFolder = Path.Combine("Assets/Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.img.FileName;
                using (var fs = new FileStream(Path.Combine(uploadsFolder, uniqueFileName), FileMode.Create))
                {
                    await model.img.CopyToAsync(fs);
                }
            }
            else
            {

            }
            User u = new User()
            {
                Id = user.Id,
                Age = model.age,
                Img = uniqueFileName,
                Name = model.Name,
                Reserve = false,

            };
            db.User.Add(u);
            db.SaveChanges();
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                return true;
            }
            return false;
        }



        public void setEvent(string userName, int? id)
        {
            var user = db.User.Where(a => a.Name == userName).FirstOrDefault();
            var eve = db.Events.Where(a => a.Id == id).FirstOrDefault();
            user.Event.Add(eve);
            
            db.SaveChanges();
        }
    }
}
