using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Creativa.Models
{
    public partial class SocialAccount
    {
        [Key]
        public string Id { get; set; }

        [Key]
        [ForeignKey("GraduateUser")]
        public string GraduateUserid { get; set; }
        public virtual GraduateUser GraduateUser { get; set; }

        public string Name { get; set; }
        public string Link { get; set; }

        
    }
}
