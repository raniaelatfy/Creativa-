using Creativa.Identity;
using Creativa.Models;
using Creativa.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Repository
{
    public class profileRepository : IIRepository<ModelViewUser>
    {
        ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        public profileRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }



        public async Task Add(ModelViewUser item)
        {
            User e = new User();
            e.Id = item.id;
            //e.img = item.img;
            //e.email = item.mail;
            e.Name = item.Name;
            //e.phone = item.phone;
            e.Reserve = item.reserve;
            //e.user_name = item.user_name;
            db.Add(e);
            db.Database.EnsureCreated();
            await db.SaveChangesAsync();
        }

      

        public async Task Delete(string id)
        {
            User CurrentUser = db.User.Where(n => n.Id == id).FirstOrDefault();
            db.User.Remove(CurrentUser);
            await db.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ModelViewUser> Find(string id)
        {
            User _user = await db.User.Where(x => x.applicationUser.UserName == id).FirstOrDefaultAsync();
            if (_user == null)
                return null;
            else
            {
                ModelViewUser _profile = new ModelViewUser();
                _profile.id = _user.Id;
                
                _profile.age = _user.Age;
                _profile.Name = _user.Name;
                _profile.reserve = _user.Reserve;
                _profile.user_name = _user.applicationUser.UserName;
                _profile.mail = _user.applicationUser.Email;
                _profile.phone = _user.applicationUser.PhoneNumber;


                //_profile.phone = _user.phone;
                //_profile.img = _user.img;
                //_profile.user_name = _user.user_name;


                return _profile;

            }
        }

        public Task<ModelViewUser> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ModelViewUser>> GetAll()
        {

            List<User> users = await db.User.ToListAsync();
            List<ModelViewUser> TheUsers = new List<ModelViewUser>();
            foreach (var item in users)
            {
                ModelViewUser e = new ModelViewUser();
                e.id = item.Id;
                //e.img = item.img;
                //e.mail = item.email;
                e.Name = item.Name;
                //e.phone = item.phone;
                e.reserve = item.Reserve;
                //e.user_name = item.user_name;

                

                TheUsers.Add(e);
            }
            return TheUsers;
        }



        public async Task Update(string username, ModelViewUser item)
        {

            if (item != null)
            {
                User found = db.User.Where(u => u.applicationUser.UserName == username).FirstOrDefault();
                if (found != null)
                {
                    string uniqueFileName = null;
                    if (item.img != null)
                    {
                        string uploadsFolder = Path.Combine("Assets/Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + item.img.FileName;
                        using (var fs = new FileStream(Path.Combine(uploadsFolder, uniqueFileName), FileMode.Create))
                        {
                            await item.img.CopyToAsync(fs);
                        }
                    }
                    else
                    {

                    }
                    found.Name = item.Name;
                    found.Age = item.age;
                    found.Img = uniqueFileName;
                    await db.SaveChangesAsync();
                }

            }


        }
        public async Task<bool> changepass(string username, string oldPass, string newpass)
        {
            var checkOld = await userManager.CheckPasswordAsync
                (await userManager.FindByNameAsync(username), oldPass);
            var user = await userManager.FindByNameAsync(username);
            if (checkOld)
            {
                var taken = await userManager.GeneratePasswordResetTokenAsync(user);
                var result = await userManager.ResetPasswordAsync(user, taken, newpass);
                return true;
            }
            return false;
        }

        public Task Update(int id, ModelViewUser item)
        {
            throw new NotImplementedException();
        }

        public Task Update(string username, UserRegisterModel profile)
        {
            throw new NotImplementedException();
        }

       
    }
}

       
    

