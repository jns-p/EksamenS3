using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenS3
{
    public class Model : DbContext
    {
        public DbSet<Bog> Bøger { get; set; }
        public DbSet<Låner> Lånere { get; set; }
        public DbSet<Udlån> Udlånere { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Bibliotek; Trusted_Connection = True; ");
        }
    }
}
