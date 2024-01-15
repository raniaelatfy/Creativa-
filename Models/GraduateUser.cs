using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace Creativa.Models
{
    public partial class GraduateUser
    {
        public GraduateUser()
        {
            GraduateFroms = new HashSet<GraduateFrom>();
            SocialAccounts = new HashSet<SocialAccount>();
        }

        [Key]
        [ForeignKey("IdNavigation")]
        public string Id { get; set; }
        public virtual User IdNavigation { get; set; }

        public DateTime GradYeear { get; set; }
        public string SuccessHistory { get; set; }
        public string Desc { get; set; }

        
        public virtual ICollection<GraduateFrom> GraduateFroms { get; set; }
        public virtual ICollection<SocialAccount> SocialAccounts { get; set; }
    }
}
