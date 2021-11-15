using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.DevChallenge.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.DevChallenge.Storage.Configurations
{
    public class TransactionsConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(transaction => transaction.Id);
            builder.Property(transaction => transaction.Instrument).IsRequired();
            builder.Property(transaction => transaction.InstrumentOwner).IsRequired();
            builder.Property(transaction => transaction.Portfolio).IsRequired();
            builder.Property(transaction => transaction.Price).IsRequired();
            builder.Property(transaction => transaction.Date).IsRequired();
        }
    }
}
