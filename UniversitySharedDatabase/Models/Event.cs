using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }


        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string Category { get; set; }


        [Required(ErrorMessage = "UserClubRegId should not be blank")]
        [ForeignKey("Club")]
        public int ClubId { get; set; }

        public int TotalAttendedStudents { get; set; }

       /* public ICollection<UserEvent> UserEvents { get; set; }
        public virtual Club Club { get; set; }*/


    }
}
