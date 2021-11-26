using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class UserGrievance
    {
        [Key]
        public int ReferenceId { get; set; }


        [ForeignKey("Grievance")]
        [Required]
        public int GrievanceId { get; set; }


        [ForeignKey("StatusFeild")]
        [Required]
        public int StatusId { get; set; }


        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Please Enter Problem ")]
        [StringLength(150, MinimumLength = 30)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string Problem { get; set; }


        [Required(ErrorMessage = "Please Enter Description ")]
        [StringLength(150, MinimumLength = 30)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime ResolutionDate { get; set; }

        public string Reply { get; set; }

        public virtual User User { get; set; }
        public virtual Grievance Grievance { get; set; }
        public virtual StatusFeild StatusFeild { get; set; }

    }
}
