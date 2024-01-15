using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Creativa.Models
{
    public partial class ProgramTable
    {
        public ProgramTable()
        {
            BranchPrograms = new HashSet<Branch>();
            ProgramsUsers = new HashSet<User>();
            Tracks = new HashSet<Track>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        [ForeignKey("IdOrgNavigation")]
        public int IdOrg { get; set; }
        public virtual Organization IdOrgNavigation { get; set; }


        public virtual ICollection<Branch> BranchPrograms { get; set; }
        public virtual ICollection<User> ProgramsUsers { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
