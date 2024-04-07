using MicrosAccounting.Api.Models.Transactions;

namespace MicrosAccounting.Api.Services.Transactions;

public interface ITransactionService
{
    ValueTask<Transaction> AddTransactionAsync(Transaction transaction);
    IQueryable<Transaction> RetrieveTransactionsAsync();
    ValueTask<Transaction> ModifyTransactionAsync(Transaction transaction);
    ValueTask<Transaction> RemoveTransactionAsync(Transaction transaction);
}