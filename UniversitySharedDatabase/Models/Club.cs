using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class Club
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }


        [Required(ErrorMessage = "Please Enter ClubName e.g. Aaron")]
        [DisplayName("Club Name")]
        [StringLength(30, MinimumLength = 5)]
        /*[RegularExpression("^[A-Za-z]{4,30}$")]*/
        public string ClubName { get; set; }


        [Required(ErrorMessage = "Please Enter Details e.g. Aaron")]
        [DisplayName("Details")]
        [StringLength(150, MinimumLength = 5)]
        /*[RegularExpression("^[A-Za-z]{4,30}$")]*/
        public string Details { get; set; }


        [Required]
        public String Eligibility { get; set; }


        /*public ICollection<Idea> Ideas { get; set; }
        public ICollection<UserClub> UserClubs { get; set; }

        public ICollection<Event> Events { get; set; }*/
    }
}
