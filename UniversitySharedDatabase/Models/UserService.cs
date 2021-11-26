using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class UserService
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
