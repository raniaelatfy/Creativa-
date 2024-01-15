using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Creativa.Identity;

#nullable disable

namespace Creativa.Models
{
    public partial class User
    {
        public User()
        {
            Event = new HashSet<Event>();
            FreeLances = new HashSet<FreeLance>();
            ProgramsUsers = new HashSet<ProgramTable>();
        }

        [Key]
        [ForeignKey("applicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }

        public string Img { get; set; }
        public string Name { get; set; }
        public bool Reserve { get; set; }
        public int Age { get; set; }

        public virtual GraduateUser GraduateUser { get; set; }

        public virtual ICollection<ProgramTable> ProgramsUsers { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<FreeLance> FreeLances { get; set; }
        

        
    }
}
