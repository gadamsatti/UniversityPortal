using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityPortal.Models
{
    public class Service
    {
       
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Please ServiceName e.g. Hawkins")]
        [DisplayName("ServiceName")]
        [StringLength(30, MinimumLength = 5)]
        public string ServiceName { get; set; }


        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Description { get; set; }



        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]

        public DateTime BeginDate { get; set; }



        [Required]
        public int VolunteerCount { get; set; }


    }
}
