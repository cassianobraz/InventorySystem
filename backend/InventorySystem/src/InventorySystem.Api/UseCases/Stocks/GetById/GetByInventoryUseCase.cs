using InventorySystem.Api.Infrastructure;
using InventorySystem.Communication.Responses;

namespace InventorySystem.Api.UseCases.Stocks.GetById;

public class GetByInventoryUseCase
{
    private readonly InventoryDBContext _dbContext;
    public GetByInventoryUseCase(InventoryDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public ResponseAllStocksJson Execute(int id)
    {
        var stock = _dbContext.Stocks.FirstOrDefault(s => s.Id == id);
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
