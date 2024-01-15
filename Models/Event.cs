using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Creativa.Models
{
    public partial class Event
    {
        public Event()
        {
            EventUsers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<User> EventUsers { get; set; }

        [ForeignKey("organization")]
        public int Organizationid { get; set; }
        public virtual Organization organization { get; set; }
        
    }
}
