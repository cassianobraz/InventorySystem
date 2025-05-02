using InventorySystem.Api.Infrastructure;
using InventorySystem.Communication.Responses;

namespace InventorySystem.Api.UseCases.Stocks.GetAll;

public class GetAllInventoryUseCase
{
    public ResponseAllStocksJson Execute()
    {
        var dbContext = new InventoryDBContext();

        var stocks = dbContext.Stocks.ToList();

        return new ResponseAllStocksJson
        {
            Stocks = stocks.Select(stock => new ResponseShortInventoryJson
            {
                Id = stock.Id,
                NameProduct = stock.NameProduct,
                Amount = stock.Amount,
                Create_at = stock.Create_at,
            }).ToList(),
        };       
    }
}
