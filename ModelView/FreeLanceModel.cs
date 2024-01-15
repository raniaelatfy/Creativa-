using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.ModelView
{
    public class FreeLanceModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "*")]
        public int duration { get; set; }
        
        [Required(ErrorMessage = "*")]
        
        public string LinkProfile { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string personality_ID { get; set; }
        
        public string status { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string Type_project { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string Tech_used { get; set; }
        
        [Required(ErrorMessage = "*")]
        public int BranchId { get; set; }
       
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
    }
}
