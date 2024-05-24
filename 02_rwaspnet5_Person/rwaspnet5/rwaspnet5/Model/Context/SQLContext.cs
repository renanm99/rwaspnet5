using Microsoft.EntityFrameworkCore;
using rwaspnet5.Model.Base;
using rwaspnet5.Repository.Generic;

namespace rwaspnet5.Model.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext() { }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
