using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityPortal.Models
{
    public class UserEventModel
    {
        public int UserEventID { get; set; }

        public int UserId { get; set; }


        public int EventId { get; set; }


        public bool Attendence { get; set; }


        public bool LikesOrDislike { get; set; }

        public string Suggestion { get; set; }

    }
}
