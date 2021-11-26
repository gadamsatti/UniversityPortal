using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UniversitySharedDatabase.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SecurityQuestion>().HasData(
            new SecurityQuestion() { QuId = 1, Question = "What is your mother's maiden name?" },
            new SecurityQuestion() { QuId = 2, Question = "What is the name of your first pet?" },
            new SecurityQuestion() { QuId = 3, Question = "What was your first car?" },
            new SecurityQuestion() { QuId = 4, Question = "What elementary school did you attend?" },
            new SecurityQuestion() { QuId = 5, Question = "What is the name of the town where you were born?" },
            new SecurityQuestion() { QuId = 6, Question = "When you were young, what did you want to be when you grew up?" },
            new SecurityQuestion() { QuId = 7, Question = "Who was your childhood hero?" },
            new SecurityQuestion() { QuId = 8, Question = "Where was your best family vacation as a kid?" }
            );
            modelBuilder.Entity<DesignationCouncil>().HasData(
                new DesignationCouncil() { DesgId = 1, Designation = "NA" },
                new DesignationCouncil() { DesgId = 2, Designation = "President" },
                new DesignationCouncil() { DesgId = 3, Designation = "Vice-president" },
                new DesignationCouncil() { DesgId = 4, Designation = "Treasurer" },
                new DesignationCouncil() { DesgId = 5, Designation = "Executive member" },
                new DesignationCouncil() { DesgId = 6, Designation = "Associate co-ordinator" },
                new DesignationCouncil() { DesgId = 7, Designation = "Secretary " }
                );
            modelBuilder.Entity<Grievance>().HasData(
               new Grievance() { GrievanceId = 1, Type = "Complaint" },
               new Grievance() { GrievanceId = 2, Type = "Suggestion" },
               new Grievance() { GrievanceId = 3, Type = "Technical Problem" }
              
               );
            modelBuilder.Entity<StatusFeild>().HasData(
               new StatusFeild() { StatusId = 1, Status = "Pending /Open" },
               new StatusFeild() { StatusId = 2, Status = "InProgress" },
               new StatusFeild() { StatusId = 3, Status = "Closed" }

               );

        }
    }
}