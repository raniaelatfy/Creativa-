using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Creativa.Models
{
    public partial class Branch
    {
        public Branch()
        {
            BranchPrograms = new HashSet<ProgramTable>();
            BranchTracks = new HashSet<Track>();
            Events = new HashSet<Event>();
            FreeLances = new HashSet<FreeLance>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("organization")]
        public int? Organizationid { get; set; }
        public virtual Organization organization { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProgramTable> BranchPrograms { get; set; }
        [JsonIgnore]
        public virtual ICollection<Track> BranchTracks { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event> Events { get; set; }
        [JsonIgnore]
        public virtual ICollection<FreeLance> FreeLances { get; set; }
    }
}
