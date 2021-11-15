using Microsoft.AspNetCore.Mvc;
using SC.DevChallenge.Services.Interfaces;
using SC.DevChallenge.Storage.Context;
using SC.DevChallenge.Storage.Shared.Dtos;
using System;

namespace SC.DevChallenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public PricesController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("average")]
        public ActionResult Average([FromQuery] TransactionDto options)
        {
            try
            {
                var result = _transactionService.GetAvaragePrice(options);

                return Ok(new { result, options.Date });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
