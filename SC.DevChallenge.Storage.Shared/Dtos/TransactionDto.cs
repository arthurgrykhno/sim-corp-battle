using System;

namespace SC.DevChallenge.Storage.Shared.Dtos
{
    public class TransactionDto
    {
        public string Portfolio { get; set; }
        public string InstrumentOwner { get; set; }
        public string Instrument { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
