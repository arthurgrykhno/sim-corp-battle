using System;

namespace SC.DevChallenge.Storage.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Portfolio { get; set; }
        public string InstrumentOwner { get; set; }
        public string Instrument { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
