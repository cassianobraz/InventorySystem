using InventorySystem.Api.Entities;
using InventorySystem.Api.Infrastructure;
using InventorySystem.Api.UseCases.Stocks.SharedValidator;
using InventorySystem.Communication.Requests;
using InventorySystem.Communication.Responses;
using System.Linq;

namespace InventorySystem.Api.UseCases.Stocks.Register;

public class RegisterInventoryUseCase
{
    private readonly InventoryDBContext _dbContext;

    public RegisterInventoryUseCase(InventoryDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ResponseShortInventoryJson Execute(RequestStockJson request)
    {
        Validate(request);

        var entity = new Stock
        {
            NameProduct = request.NameProduct,
            Amount = request.Amount,
            Price = request.Price,
        };

        _dbContext.Stocks.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseShortInventoryJson
        {
            Id = entity.Id,
            NameProduct = entity.NameProduct,
            Amount = entity.Amount,
            Price = entity.Price,
            Create_at = entity.Create_at
        };
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
