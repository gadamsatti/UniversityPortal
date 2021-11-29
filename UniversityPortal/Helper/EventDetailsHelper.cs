using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityPortal.Models;
namespace UniversityPortal.Helper
{
    public class EventDetailsHelper
    {
        public Event Event { get; set; }

        public List<Event> SimilarEvents { get; set; }

        public List<User> AllUserRegister { get; set; }
    }
}
