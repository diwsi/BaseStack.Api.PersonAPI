using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Person.Domain.Entities.Configuration;

namespace Person.Domain.Entities
{
    public class PersonAppContext : DbContext
    { 
        public DbSet<Person> Person { get; set; }
        public DbSet<Outbox> Outbox { get; set; }
 
  
        public PersonAppContext(DbContextOptions<PersonAppContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new OutboxConfig());
        }

    }
}
