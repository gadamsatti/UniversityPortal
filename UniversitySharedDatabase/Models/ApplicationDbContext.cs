using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySharedDatabase.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
                
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }



        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<UserClub> UserClubs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<UserService> UserServices { get; set; }
        public DbSet<Grievance> Grievances { get; set; }
        public DbSet<StatusFeild> StatusFeilds { get; set; }
        public DbSet<UserGrievance> UserGrievances { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<UserIdea> UserIdeas { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DesignationCouncil> DesignationCouncils { get; set; }

        //public DbSet<SecurityQuestion> SecurityQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLOcalDB ; Database=UniversityDb;integrated security=true");
            }
        }
    }
}
