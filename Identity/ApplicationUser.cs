using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Identity
{
    public class ApplicationUser : IdentityUser
    {
    }
}
//Scaffold-DbContext "Server=.;Database=Creativa;Trusted_Connection=True;"Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models