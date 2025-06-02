using InventorySystem.Api.Infrastructure;
using InventorySystem.Api.UseCases.Stocks.SharedValidator;
using InventorySystem.Communication.Requests;
using System.Linq;

namespace InventorySystem.Api.UseCases.Stocks.Update;

public class UpdateInventoryUseCase
{
    private readonly InventoryDBContext _dbContext;

    public UpdateInventoryUseCase(InventoryDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Execute(int id, RequestStockJson request)
    {
        Validate(request);

        var entity = _dbContext.Stocks.FirstOrDefault(stock => stock.Id == id);
        if (entity is null)
            throw new Exception("Product not found");

        entity.NameProduct = request.NameProduct;
        entity.Amount = request.Amount;
        entity.Price = request.Price;

        _dbContext.Stocks.Update(entity);
        _dbContext.SaveChanges();
    }

    private void Validate(RequestStockJson request)
    {
        var validator = new RequestStockValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var erros = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            throw new ArgumentException("Validation error: " + string.Join(", ", erros));
        }
    }
}
