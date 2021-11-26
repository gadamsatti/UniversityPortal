using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class UserIdea
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Idea")]
        [Required]
        public int IdeaId { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool LikeStatus { get; set; }
        [Required(ErrorMessage = "Please Enter Comments ")]
        [StringLength(150, MinimumLength = 2)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string Comments { get; set; }
        public virtual User User { get; set; }
        public virtual Idea Idea { get; set; }
    }
}
