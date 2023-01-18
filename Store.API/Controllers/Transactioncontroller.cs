using Microsoft.AspNetCore.Mvc;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Transactioncontroller : ControllerBase
    {
        private ITransactionService _transService;

        public Transactioncontroller(ITransactionService transService)
        {
            _transService = transService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transactions = await _transService.GetTransactions();

            return Ok(transactions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var transaction = await _transService.GetTransaction(id);
            if (transaction is null) return NotFound();
            return Ok(transaction);
        }
        [HttpPost]
        public async Task<IActionResult> Post(TransactionCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _transService.AddTransaction(model))
                return Ok("Success");
            else
                return UnprocessableEntity();
        }
    }
}