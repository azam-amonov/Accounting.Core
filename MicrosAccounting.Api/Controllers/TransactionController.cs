using MicrosAccounting.Api.Models.Transactions;
using MicrosAccounting.Api.Services.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace MicrosAccounting.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        this.transactionService = transactionService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<Transaction>> PostTransaction(Transaction transaction)
    {
        Transaction addedTransaction = await this.transactionService.AddTransactionAsync(transaction);
        
        return Ok(addedTransaction);
    }

    [HttpGet]
    public ActionResult<IQueryable<Transaction>> GetAllTransactions()
    {
        IQueryable<Transaction> retrievedTransactions = transactionService.RetrieveAllTransactions();
        
        return Ok(retrievedTransactions);
    }

    [HttpGet( "{guid}")]

    public async ValueTask<ActionResult<Transaction>> GetTransactionById(Guid transactionId)
    {
        Transaction maybeTransaction = await transactionService.RetrieveTransactionByIdAsync(transactionId);
        
        return Ok(maybeTransaction);
    }
    
    [HttpPut]
    public async ValueTask<ActionResult<Transaction>> PutTransaction(Transaction transaction)
    {
        Transaction putTransaction = await transactionService.ModifyTransactionAsync(transaction);
        
        return Ok(putTransaction);
    }
    
    [HttpDelete( "{guid}")]
    
    public async ValueTask<ActionResult<Transaction>> DeleteTransactionById(Guid transactionId)
    {
        Transaction deletedTransaction = await transactionService.RemoveTransactionByIdAsync(transactionId);
    
        return Ok(deletedTransaction);
    }
}