using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Creativa.Models
{
    public partial class FreeLance
    {
        [Key]
        [ForeignKey("IdNavigation")]
        public string Id { get; set; }
        public virtual User IdNavigation { get; set; }


        [ForeignKey("branch")]
        public int BranchId { get; set; }
        [JsonIgnore]
        public virtual Branch branch { get; set; }

        public string Name { get; set; }
        public int duration { get; set; }
        public string LinkProfile { get; set; }
        public string personality_ID { get; set; }
        public string status { get; set; }
        public string Type_project { get; set; }
        public string Tech_used { get; set; }
    }
}
