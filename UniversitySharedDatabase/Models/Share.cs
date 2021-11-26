using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySharedDatabase.Models
{
   public class Share
    {
        public int ShareId { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string EventOrIdea { get; set; }

        public int  RelatedId { get; set; }

    }
}
