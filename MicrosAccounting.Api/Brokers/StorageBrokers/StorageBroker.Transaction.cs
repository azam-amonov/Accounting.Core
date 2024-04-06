using MicrosAccounting.Api.Models.Transactions;

namespace MicrosAccounting.Api.Brokers.StorageBrokers;

public partial class StorageBroker
{
    public async ValueTask<Transaction> 
        InsertTransactionAsync(Transaction transaction) =>
        await this.InsertAsync(transaction);

    public IQueryable<Transaction> SelectAllTransaction() =>
        this.SelectAll<Transaction>();

    public async ValueTask<Transaction>
        UpdateTransactionAsync(Transaction transaction) =>
        await this.UpdateAsync(transaction);
    
    public async ValueTask<Transaction> 
        DeleteTransactionAsync(Transaction transaction) =>
        await this.DeleteAsync(transaction);
}