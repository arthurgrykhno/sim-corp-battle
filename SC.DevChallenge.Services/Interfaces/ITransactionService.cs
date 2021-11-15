using SC.DevChallenge.Storage.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.DevChallenge.Services.Interfaces
{
    public interface ITransactionService
    {
        Task AddRange(List<TransactionDto> transactionDtos);
        decimal GetAvaragePrice(TransactionDto options);
    }
}
