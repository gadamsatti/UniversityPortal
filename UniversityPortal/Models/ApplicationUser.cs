using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityPortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

    }
}
