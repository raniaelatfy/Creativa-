using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Models
{
    public class ModelViewUser
    {

        public string id { get; set; }
        public IFormFile img { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public bool reserve { get; set; } = false;
        public int age { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        

    }
}
