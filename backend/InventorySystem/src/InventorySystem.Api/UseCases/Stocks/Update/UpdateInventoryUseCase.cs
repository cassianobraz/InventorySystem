using InventorySystem.Api.Infrastructure;
using InventorySystem.Api.UseCases.Stocks.SharedValidator;
using InventorySystem.Communication.Requests;

namespace InventorySystem.Api.UseCases.Stocks.Update;

public class UpdateInventoryUseCase
{
    public void Execute(int id, RequestStockJson request)
    {
        Validate(request);

        var dbContext = new InventoryDBContext();

        var entity = dbContext.Stocks.FirstOrDefault(stock => stock.Id == id);
        if (entity is null)
            throw new Exception("Product not found");

        entity.NameProduct = request.NameProduct;
        entity.Amount = request.Amount;

        dbContext.Stocks.Update(entity);
        dbContext.SaveChanges();
    }

    private void Validate(RequestStockJson request)
    {
        var validator = new RequestStockValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var erros = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ArgumentException("Validation error", string.Join(", ", erros));
        }
    }
}
