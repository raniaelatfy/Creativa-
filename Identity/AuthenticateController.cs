using Creativa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Creativa.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController:ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext db;
        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration , ApplicationDbContext db
            , IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }


        //public async Task<string> CreateToken(ApplicationUser user)
        //{
            
        //}

        [HttpPost]
        [Route("login")]
        public  async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                //HttpContext.Session.SetString("userid", user.Id);
                var authClaims = new List<Claim>
                {
                    new Claim("UserID", user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(30),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Register([FromForm] ModelViewUser model )
        {
      //Add Rule
      var role = new IdentityRole();
      role.Name = "User";
      await roleManager.CreateAsync(role);

      var userExists = await userManager.FindByNameAsync(model.user_name);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.mail,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.user_name
            };
            var result = await userManager.CreateAsync(user, model.password);
            string user_id = user.Id;
            string uniqueFileName = null;
            if (model.img != null)
            {
                string uploadsFolder = Path.Combine("images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.img.FileName;
                using (var fs = new FileStream(Path.Combine(uploadsFolder, uniqueFileName), FileMode.Create))
                {
                    await model.img.CopyToAsync(fs);
                }
            }
            else
            {

            }

            if (ModelState.IsValid)
            {
                User u = new User()
                {
                    Id = user_id,
                    Age = model.age,
                    Img = uniqueFileName,
                    Name = model.Name,
                    Reserve = model.reserve,
                   
                };
                db.User.Add(u);
                db.SaveChanges();
            }

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            await userManager.AddToRoleAsync(user, "User");
            //return into the response  between {VERB, any obj u want }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            //var role = new IdentityRole();
            //role.Name = "Admin";
            //await roleManager.CreateAsync(role);

            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username

            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPut]
        public async Task<IActionResult> changepass(string newpass)
        {
            var id = HttpContext.Session.GetString("userid");
            var user = await userManager.FindByIdAsync(id);
            var taken = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, taken, newpass);
            return Ok();
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> getData()
        {
            var currentUserName = User.FindFirst("UserID").Value;
            ApplicationUser user = await userManager.FindByNameAsync(currentUserName);
            return Ok(new
            {
                user.UserName,
                user.Email,
                user.Id
            });
        }

    }
}
