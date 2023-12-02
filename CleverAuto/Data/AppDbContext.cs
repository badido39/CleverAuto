using CleverAuto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverAuto.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            Database.EnsureCreated();   
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<Car> Cars{ get; set; }
        public DbSet<ServiceList> ServiceLists{ get; set; }


    }
}
