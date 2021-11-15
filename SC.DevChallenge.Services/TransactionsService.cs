using SC.DevChallenge.Services.Interfaces;
using SC.DevChallenge.Storage.Shared.Dtos;
using SC.DevChallenge.Storage.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.DevChallenge.Services
{
    public class TransactionsService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private const int additionalSeconds = 10000;

        public TransactionsService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task AddRange (List<TransactionDto> transactionDtos)
        {
            await _transactionRepository.AddRange(transactionDtos);
        }

        public decimal GetAvaragePrice(TransactionDto options)
        {
            var startDate = options.Date;
            var stopDate = options.Date.AddSeconds(additionalSeconds);

            var result = Decimal.Round(_transactionRepository.GetAvaragePrice(startDate, stopDate, options), 2);

            return result;
        }
    }
}
