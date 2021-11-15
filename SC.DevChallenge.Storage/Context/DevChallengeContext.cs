using Microsoft.EntityFrameworkCore;
using SC.DevChallenge.Storage.Configurations;
using SC.DevChallenge.Storage.Models;

namespace SC.DevChallenge.Storage.Context
{
    public class DevChallengeContext : DbContext
    {
        public  DevChallengeContext(DbContextOptions options)
            : base (options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionsConfiguration());
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
