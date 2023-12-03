using CleverAuto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverAuto.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

            Database.EnsureCreated();
        }
        public AppDbContext(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceList> ServiceLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For AutoGenarated ID
            modelBuilder.Entity<Customer>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Car>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Service>().Property(e => e.Id).ValueGeneratedOnAdd();


            // Seed the database with initial data
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John Dohe",
                    Email = "jondohe@gmail.com",
                    Phone = "0550553344",
                },
                 new Customer
                 {
                     Id = 2,
                     Name = "Bruce Willis",
                     Email = "BruceWillis.com",
                     Phone = "0660006660",
                 } ,
                 new Customer
                 {
                     Id = 3,
                     Name = "John Dohe",
                     Email = "jondohe@gmail.com",
                     Phone = "0550553344",
                 },
                  new Customer
                  {
                      Id = 4,
                      Name = "John Dohe",
                      Email = "jondohe@gmail.com",
                      Phone = "0550553344",
                  }, new Customer
                  {
                      Id = 5,
                      Name = "John Dohe",
                      Email = "jondohe@gmail.com",
                      Phone = "0550553344",
                  }, new Customer
                  {
                      Id = 6,
                      Name = "John Dohe",
                      Email = "jondohe@gmail.com",
                      Phone = "0550553344",
                  });

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id=1,
                    CustomerId = 1,
                    Make = "Honda",
                    Model = "Civic",
                    PlateNumber = "1111-118-16",
                    VIN = "VDFGGGGGFDSSS",
                },
                 new Car
                 {
                     Id = 2,
                     CustomerId = 1,
                     Make = "BMW",
                     Model = "X6",
                     PlateNumber = "1111-118-16",
                     VIN = "VDFGGGGGFDSSS",
                 });

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id=1,
                    CarId= 1,
                    DateOfService=DateTime.UtcNow,
                    Type="Freins et Suspention",
                    ReminderSent=false
                } ,
                 new Service
                 {
                     Id = 2,
                     CarId = 1,
                     DateOfService = DateTime.UtcNow,
                     Type = "Vidange Moteur",
                     ReminderSent = false
                 },
                 new Service
                 {
                     Id = 3,
                     CarId = 1,
                     DateOfService = DateTime.UtcNow,
                     Type = "Plaquette De Frein",
                     ReminderSent = false
                 },
                   new Service
                   {
                       Id = 4,
                       CarId = 2,
                       DateOfService = DateTime.UtcNow,
                       Type = "Freins et Suspention",
                       ReminderSent = false
                   },
                 new Service
                 {
                     Id = 5,
                     CarId = 2,
                     DateOfService = DateTime.UtcNow,
                     Type = "Vidange Moteur",
                     ReminderSent = false
                 },
                 new Service
                 {
                     Id = 6,
                     CarId = 2,
                     DateOfService = DateTime.UtcNow,
                     Type = "Plaquette De Frein",
                     ReminderSent = false
                 }
                );


        }
    }




}