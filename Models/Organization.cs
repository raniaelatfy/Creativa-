using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Creativa.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Branches = new HashSet<Branch>();
            Events = new HashSet<Event>();
            ProgramTables = new HashSet<ProgramTable>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Desc { get; set; }
        [JsonIgnore]
        public virtual ICollection<Branch> Branches { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event> Events { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProgramTable> ProgramTables { get; set; }
    }
}
