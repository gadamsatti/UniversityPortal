using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class UserEvent
    {

        public int UserEventID { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }


        [ForeignKey("Events")]
        [Required]
        public int EventId { get; set; }
        

        public bool Attendence { get; set; }


        
        public bool LikesOrDislike { get; set; }

       
        [StringLength(150, MinimumLength = 30)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string Suggestion { get; set; }


        public virtual User User { get; set; }
        public virtual Event Events { get; set; }
    }
}
