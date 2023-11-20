using Microsoft.EntityFrameworkCore;
using TbcTask.Domain.Models.Database;
using TbcTask.Infrastructure.Store.SeedData;

namespace TbcTask.Infrastructure.Store
{
    public class PersonDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-2L4TSA8\\DAVITI;Database=Person;Integrated Security=True;");
        //    }
        //}
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<ConnectedPersons> ConnectedPersons { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<PersonConnectionType> PersonConnectionTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<PhysicalPerson> PhysicalPersons { get; set; }
        public DbSet<City> City { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectedPersons>()
        .HasKey(r => new{r.PhysicialPersonId,r.ConnectedPersonId}).HasName("DualValidation");

            modelBuilder.Entity<ConnectedPersons>()
                .HasOne(r => r.ConnectedPerson)
                .WithMany(p => p.ConnectedPersons)
                .HasForeignKey(r => r.ConnectedPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConnectedPersons>()
                .HasOne(r => r.PhysicialPerson)
                .WithMany()
                .HasForeignKey(r => r.PhysicialPersonId)
                .OnDelete(DeleteBehavior.Restrict);
           SeedPersonHelperInfo.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}