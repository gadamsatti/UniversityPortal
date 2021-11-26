using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class Idea
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdeaId { get; set; }


        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }


        [ForeignKey("Club")]
        [Required]
        public int ClubId { get; set; }


        [Required(ErrorMessage = "Please Enter IdeaTitle e.g. Aaron")]
        [DisplayName("IdeaTitle")]
        [StringLength(30, MinimumLength = 5)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string IdeaTitle { get; set; }
       
        [Required(ErrorMessage = "Please Enter Description ")]
        [StringLength(150, MinimumLength = 30)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string Description { get; set; }


        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual Club Club { get; set; }
        public ICollection<UserIdea> UserIdeas { get; set; }

    }
}
