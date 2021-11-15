using Microsoft.VisualBasic.FileIO;
using SC.DevChallenge.Services.Extensions;
using SC.DevChallenge.Services.Interfaces;
using SC.DevChallenge.Storage.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SC.DevChallenge.Services
{
    public class CSVParseService : ICSVParseService
    {
        private readonly string path = @"Input/data.csv";
        private readonly ITransactionService _transactionService;

        public CSVParseService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public void Parse()
        {
            var transactionDtos = new List<TransactionDto>();

            using var parser = new TextFieldParser(path);

            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            parser.SkipCSVHeaders();

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();

                transactionDtos.Add(new TransactionDto
                {
                    Portfolio = fields[0],
                    InstrumentOwner = fields[1],
                    Instrument = fields[2],
                    Date = DateTime.ParseExact(fields[3],"dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    Price = Convert.ToDecimal(fields[4], new CultureInfo("en-US"))
                });
            }
            _transactionService.AddRange(transactionDtos);
        }
    }
}
