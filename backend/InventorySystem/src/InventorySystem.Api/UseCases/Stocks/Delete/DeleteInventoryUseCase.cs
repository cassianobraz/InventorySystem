using InventorySystem.Api.Infrastructure;

namespace InventorySystem.Api.UseCases.Stocks.Delete;

public class DeleteInventoryUseCase
{
    private readonly InventoryDBContext _dbContext;

    public DeleteInventoryUseCase(InventoryDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Execute(int id)
    {
        var entity = _dbContext.Stocks.FirstOrDefault(stock => stock.Id == id);
        if (entity is null)
            throw new Exception("Product not found");

        _dbContext.Stocks.Remove(entity);
        _dbContext.SaveChanges();
    }
}
