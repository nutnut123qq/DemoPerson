using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoPerson.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
