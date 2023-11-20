using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;

namespace TbcTask.Infrastructure.Store.SeedData
{
    public static class SeedPersonHelperInfo
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                Id = 1,
                Name = "Male",
            });
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                Id = 2,
                Name="Female"
            });
            modelBuilder.Entity<City>().HasData(new City()
            {
                Id = 1,
                Name = "Tbilisi"
            });
            modelBuilder.Entity<City>().HasData(new City()
            {
                Id = 2,
                Name = "Rustavi"
            });
            modelBuilder.Entity<City>().HasData(new City()
            {
                Id = 3,
                Name = "Batumi"
            });
            modelBuilder.Entity<City>().HasData(new City()
            {
                Id = 4,
                Name = "Kutaisi"
            });
            modelBuilder.Entity<PhoneType>().HasData(new PhoneType()
            {
                Id = 1,
                Name = "Home"
            });
            modelBuilder.Entity<PhoneType>().HasData(new PhoneType()
            {
                Id = 2,
                Name = "Office"
            });
            modelBuilder.Entity<PhoneType>().HasData(new PhoneType()
            {
                Id = 3,
                Name = "Mobile"
            });
            modelBuilder.Entity<PersonConnectionType>().HasData(new PersonConnectionType()
            {
                Id = 1,
                Name = "Collegue",
            });
            modelBuilder.Entity<PersonConnectionType>().HasData(new PersonConnectionType()
            {
                Id = 2,
                Name = "Relative",
            });
            modelBuilder.Entity<PersonConnectionType>().HasData(new PersonConnectionType()
            {
                Id = 3,
                Name = "Familiar",
            });
            modelBuilder.Entity<PersonConnectionType>().HasData(new PersonConnectionType()
            {
                Id = 4,
                Name = "Other",
            });
        }


    }
}
