using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Cosmos;
using StartingProjectDemo.Models;



namespace StartingProjectDemo.Persistence
{
    public class Data : DbContext
    {
        //creating Dbsets
        public DbSet<Programs>? Programs { get; set; }

        //onconfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseCosmos(
                "https://startingproject.documents.azure.com:443/",
                "yAyuBZtR0DLQiaxYOBbLYGRss85RFRcsRKS1I2zBUgKUsEbTKqO7IFMLMm9Oyz20u4dtOulOCytyACDbRSXArw==",
                "startingproject-db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuring Programs
            modelBuilder.Entity<Programs>()
                    .ToContainer("Programs")
                    .HasPartitionKey(e => e.Id);

            //    // configuring Customers
            //    modelBuilder.Entity<Customer>()
            //        .ToContainer("Customers") // ToContainer
            //        .HasPartitionKey(c => c.Id); // Partition Key

            modelBuilder.Entity<Programs>().OwnsMany(p => p.Skills);
        }
    }
}