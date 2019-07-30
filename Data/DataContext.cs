using causal.api.Models;
using Microsoft.EntityFrameworkCore;

namespace causal.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
    }
}