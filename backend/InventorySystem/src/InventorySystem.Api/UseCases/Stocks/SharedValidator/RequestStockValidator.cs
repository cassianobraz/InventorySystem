using FluentValidation;
using InventorySystem.Communication.Requests;

namespace InventorySystem.Api.UseCases.Stocks.SharedValidator;

public class RequestStockValidator : AbstractValidator<RequestStockJson>
{
    public RequestStockValidator()
    {
        RuleFor(stock => stock.NameProduct).NotEmpty().WithMessage("NameProduct is required");
        RuleFor(stock => stock.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero");
    }
}
