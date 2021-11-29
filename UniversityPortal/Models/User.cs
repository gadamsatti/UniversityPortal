﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityPortal.Models
{
    public class User
    {
        
        public int UserId { get; set; }
      
      
        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string UserName { get; set; }


        public DateTime Dob { get; set; }



        
        public string PhoneNo { get; set; }

        public string Email { get; set; }


        public string Password { get; set; }



    }
}