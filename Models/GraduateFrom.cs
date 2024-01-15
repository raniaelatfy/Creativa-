using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Creativa.Models
{
    public partial class GraduateFrom
    {
        [Key]
        [ForeignKey("IdNavigation")]
        public string Id { get; set; }
        public virtual GraduateUser IdNavigation { get; set; }

        [Key]
        [ForeignKey("trID")]
        public int trackId { get; set; }
        public virtual Track trID { get; set; }

        public string Comment { get; set; }
        public DateTime Time { get; set; }

        
       
    }
}
