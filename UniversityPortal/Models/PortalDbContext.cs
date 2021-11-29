using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityPortal.Models
{
    public class PortalDbContext:IdentityDbContext<ApplicationUser>
    {

        public PortalDbContext(DbContextOptions<PortalDbContext> options)
            :base(options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AspNetUsers>()
                .HasIndex(u => u.UserId)
                .IsUnique();
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLOcalDB ; Database=PoratlDb; integrated security=true");

            
        }
    }
}
