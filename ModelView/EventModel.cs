using Creativa.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.ModelView
{
    public class EventModel
    {

        public int id { get; set; }
        [Required(ErrorMessage = "Event Location is required")]
        public string address { get; set; }

        [Required(ErrorMessage = "Event Description is required")]
        public string desc { get; set; }

        public string Img { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime date { get; set; }
     
        public int org_id { get; set; }

        public int branch_id { get; set; }
        
    }
}
