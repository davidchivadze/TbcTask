using Microsoft.EntityFrameworkCore;
using TbcTask.Domain.Models.Database;

namespace TbcTask.Infrastructure.Store
{
    public class PersonDbContext:DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
        public DbSet<ConnectedPerson> ConnectedPersons { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<PersonConnectionType> PersonConnectionTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<PhysicalPerson> PhysicalPersons { get; set; }

    }
}