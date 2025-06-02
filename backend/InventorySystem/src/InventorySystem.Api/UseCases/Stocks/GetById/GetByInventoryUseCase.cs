using InventorySystem.Api.Infrastructure;
using InventorySystem.Communication.Responses;
using Microsoft.EntityFrameworkCore; 

namespace InventorySystem.Api.UseCases.Stocks.GetById;

public class GetByInventoryUseCase
{
    private readonly InventoryDBContext _dbContext;

    public GetByInventoryUseCase(InventoryDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ResponseAllStocksJson> Execute(int id)
    {
        var stock = await _dbContext.Stocks.FirstOrDefaultAsync(s => s.Id == id);

        if (stock == null)
        {
            return new ResponseAllStocksJson
            {
                Stocks = new List<ResponseShortInventoryJson>()
            };
        }

        return new ResponseAllStocksJson
        {
            Stocks = new List<ResponseShortInventoryJson>
            {
                new ResponseShortInventoryJson
                {
                    Id = stock.Id,
                    NameProduct = stock.NameProduct,
                    Amount = stock.Amount,
                    Create_at = stock.Create_at,
                }
            }
        };
    }
}
