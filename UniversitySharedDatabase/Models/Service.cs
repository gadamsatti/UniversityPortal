using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class Service
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Please ServiceName e.g. Hawkins")]
        [DisplayName("ServiceName")]
        public string ServiceName { get; set; }


        [Required]
        public string Description { get; set; }



        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }
        [Required]
        public int VolunteerCount { get; set; }

        //public ICollection<UserService> UserServices { get; set; }

    }
}
