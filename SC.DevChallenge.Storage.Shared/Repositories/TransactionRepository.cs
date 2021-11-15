using SC.DevChallenge.Storage.Context;
using SC.DevChallenge.Storage.Models;
using SC.DevChallenge.Storage.Shared.Dtos;
using SC.DevChallenge.Storage.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.DevChallenge.Storage.Shared.Repositories
{
   public class TransactionRepository : ITransactionRepository
    {
        private readonly DevChallengeContext _context;

        public TransactionRepository(DevChallengeContext context)
        {
            _context = context;
        }

        public async Task AddRange(List<TransactionDto> transactionDtos)
        {
            var transactions = MapTransaction(transactionDtos);

            _context.Transactions.AddRange(transactions);

            await SaveChanges();
        }

        public decimal GetAvaragePrice(DateTime startDate, DateTime stopDate, TransactionDto options)
        {
            var transactions = _context.Transactions
                .Where(transaction => transaction.Date >= startDate && transaction.Date <= stopDate);

            if (!(string.IsNullOrEmpty(options.Instrument)))
                transactions = transactions.Where(transaction => transaction.Instrument == options.Instrument);

            if (!(string.IsNullOrEmpty(options.InstrumentOwner)))
                transactions = transactions.Where(transaction => transaction.InstrumentOwner == options.InstrumentOwner);

            if (!(string.IsNullOrEmpty(options.Portfolio)))
                transactions = transactions.Where(transaction => transaction.Portfolio == options.Portfolio);

            return transactions.Average(transaction => transaction.Price);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        private IEnumerable<Transaction> MapTransaction(List<TransactionDto> transactionDtos)
        {
            foreach (var transactionDto in transactionDtos)
            {
                yield return new Transaction
                {
                    Instrument = transactionDto.Instrument,
                    Date = transactionDto.Date,
                    InstrumentOwner = transactionDto.InstrumentOwner,
                    Portfolio = transactionDto.Portfolio,
                    Price = transactionDto.Price
                };
            }
        }
    }
}
