using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Creativa.Models
{
    public partial class Track
    {
        public Track()
        {
            BranchTracks = new HashSet<Branch>();
            GraduateFroms = new HashSet<GraduateFrom>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        [ForeignKey("Pro")]
        public int ProId { get; set; }
        public virtual ProgramTable Pro { get; set; }

        public virtual ICollection<Branch> BranchTracks { get; set; }
        public virtual ICollection<GraduateFrom> GraduateFroms { get; set; }
    }
}
