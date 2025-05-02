using InventorySystem.Api.Infrastructure;

namespace InventorySystem.Api.UseCases.Stocks.Delete;

public class DeleteInventoryUseCase
{
    public void Execute(int id)
    {
        var dbContext = new InventoryDBContext();

        var entity = dbContext.Stocks.FirstOrDefault(stock => stock.Id == id);
        if (entity is null)
            throw new Exception("Product not found");

        dbContext.Stocks.Remove(entity);
        dbContext.SaveChanges();
    }
}
