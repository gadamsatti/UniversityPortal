using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityPortal.Models
{
    public class SuggestionsModel
    {

        [Key]
        public int ReferenceId { get; set; }



        [Required]
        public int GrievanceId { get; set; }



        [Required]
        public int StatusId { get; set; }


 
        [Required]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Please Enter Problem ")]
        public string Problem { get; set; }


        [Required(ErrorMessage = "Please Enter Description ")]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime ResolutionDate { get; set; }

        public string Reply { get; set; }
    }
}
