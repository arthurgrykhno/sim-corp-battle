using SC.DevChallenge.Storage.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.DevChallenge.Storage.Shared.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddRange(List<TransactionDto> transactionDtos);
        Task SaveChanges();
        decimal GetAvaragePrice(DateTime startDate, DateTime stopDate, TransactionDto options);
    }
}
