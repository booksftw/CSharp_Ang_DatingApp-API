using DatingApp.API.Models; // the namespace I can bring <Value> generic type in.
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    // We're inheriting from DbContext
    public class DataContext : DbContext
    {   
        // ctor 
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Value> Values { get; set; }
    }
}