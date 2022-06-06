namespace InventoryManager.Application.Contracts.Infrastructure
{
    public interface IProcessingItemExpiredService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}

