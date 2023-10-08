using Microsoft.EntityFrameworkCore;
using Starting_Project.Models;




namespace Starting_Project.Persistence
{
    public class Data : DbContext
    {
        //creating Dbsets
        public DbSet<Programs>? Programs { get; set; }
        public DbSet<ApplicationForm>? ApplicationForm { get; set; }

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
                    .HasPartitionKey(p => p.Id);

            // configuring ApplicationForm
            modelBuilder.Entity<ApplicationForm>()
                .ToContainer("ApplicationForm") // ToContainer
                .HasPartitionKey(a=> a.Id); // Partition Key

            modelBuilder.Entity<Programs>().OwnsMany(p => p.Skills);
            modelBuilder.Entity<ApplicationForm>().OwnsMany(p => p.experience);
            modelBuilder.Entity<ApplicationForm>().OwnsMany(p => p.education);
        }
    }
}