using MenuAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuAssignment.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<MenuItem> MenuItems { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=root;database=menuDb;");
        }
    }
}
