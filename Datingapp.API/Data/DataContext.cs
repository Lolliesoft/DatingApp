using Datingapp.API.Models; //where Value.cs is located
using Microsoft.EntityFrameworkCore;

namespace Datingapp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //in order to tell entityframework about our entities we need to give it properties of Type DbSet
        //Values will be the table name in SQL.
        // after need to tell application startup.cs about it (inject as a service addDbContext)
        public DbSet<Value> Values { get; set; }

    }
}
