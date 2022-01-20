using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digital_Partners.Models;

namespace Digital_Partners.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       
        public DbSet<Medarbejder> Medarbejdere { get; set;}
        public DbSet<Opgave> Opgaver { get; set; }
    }

}
