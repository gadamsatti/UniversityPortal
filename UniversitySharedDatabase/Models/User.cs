using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySharedDatabase.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
      
        [Required(ErrorMessage = "Please Enter Name e.g. Aaron")]
        [DisplayName("First Name")]
        [StringLength(30, MinimumLength = 5)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Please Enter Name e.g. Hawkins")]
        [DisplayName("Last Name")]
        [StringLength(30, MinimumLength = 5)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string LastName { get; set; }




        [Required(ErrorMessage = "Please Enter Name e.g. Aaronkins12345")]
        [DisplayName("User Name")]
        [StringLength(30, MinimumLength = 8)]
        [RegularExpression("^[A-Za-z1-9]{8,30}$")]
        public string UserName { get; set; }


        public DateTime Dob { get; set; }



        
        public string PhoneNo { get; set; }



        [DisplayName("Email")]
        [Required(ErrorMessage = "Enter Email Address")]
        public string Email { get; set; }



        [DisplayName("Password")]
        [Required(ErrorMessage = "Password should not be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



       /* [Required(ErrorMessage = "Question should not be blank")]
        [ForeignKey("SecurityQuestion")]
        public int QuId { get; set; }*/

        
       /* public string Role { get; set; }*/


        /*[DisplayName("Security Answer")]
        [Required(ErrorMessage = "Security should not be blank")]
        public string SecurityAns { get; set; }*/

       /* public ICollection<Idea> Ideas { get; set; }

        public ICollection<UserClub> UserClubs { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; }

        public ICollection<UserGrievance> UserGrievances { get; set; }

        public ICollection<UserIdea> UserIdeas { get; set; }

        public ICollection<UserService> UserServices { get; set; }*/

       /* public virtual SecurityQuestion SecurityQuestion { get; set; }*/

    }
}
