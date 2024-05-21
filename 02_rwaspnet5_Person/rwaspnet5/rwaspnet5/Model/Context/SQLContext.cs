using Microsoft.EntityFrameworkCore;

namespace rwaspnet5.Model.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext()
        {
        }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
