using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class UserClub
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserClubRegId { get; set; }


        [Required(ErrorMessage = "ClubId should not be blank")]
        [ForeignKey("Club")]
        public int ClubId { get; set; }


        [Required(ErrorMessage = "UserId should not be blank")]
        [ForeignKey("User")]
        public int UserId { get; set; }


        [ForeignKey("DesignationCouncils")]
        public int DesgId { get; set; }

        public virtual DesignationCouncil DesignationCouncils { get; set; }
        public virtual User User { get; set; }
        public virtual Club Club { get; set; }

 

    }
}
