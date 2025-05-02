using InventorySystem.Api.UseCases.Stocks.GetAll;
using InventorySystem.Api.UseCases.Stocks.Register;
using InventorySystem.Api.UseCases.Stocks.Update;
using InventorySystem.Communication.Requests;
using InventorySystem.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllStocksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        try
        {
            var useCase = new GetAllInventoryUseCase();

            var response = useCase.Execute();

            if (response.Stocks.Count == 0)
                return NoContent();

            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error searching for stock", ex);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortInventoryJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestStockJson request)
    {
        try
        {
            var useCase = new RegisterInventoryUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error creating new item", ex);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestStockJson request)
    {
        try
        {
            var useCase = new UpdateInventoryUseCase();

            useCase.Execute(id, request);

            return NoContent();
        }
        catch (Exception ex)
        {
            throw new ArgumentException("error updating item", ex);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        return NoContent();
    }
}

