using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class DesignationCouncil
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesgId { get; set; }
        [Required]
        public string Designation { get; set; }

        public ICollection<UserClub> UserClubs { get; set; }

    }
}
