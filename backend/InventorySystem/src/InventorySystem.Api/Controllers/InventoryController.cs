using InventorySystem.Api.UseCases.Stocks.Delete;
using InventorySystem.Api.UseCases.Stocks.GetAll;
using InventorySystem.Api.UseCases.Stocks.Register;
using InventorySystem.Api.UseCases.Stocks.Update;
using InventorySystem.Communication.Requests;
using InventorySystem.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly GetAllInventoryUseCase _getAllUseCase;
    private readonly RegisterInventoryUseCase _registerUseCase;
    private readonly UpdateInventoryUseCase _updateUseCase;
    private readonly DeleteInventoryUseCase _deleteUseCase;

    public InventoryController(
    GetAllInventoryUseCase getAllUseCase,
    RegisterInventoryUseCase registerUseCase,
    UpdateInventoryUseCase updateUseCase,
    DeleteInventoryUseCase deleteUseCase)
    {
        _getAllUseCase = getAllUseCase;
        _registerUseCase = registerUseCase;
        _updateUseCase = updateUseCase;
        _deleteUseCase = deleteUseCase;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _getAllUseCase.Execute();

        if (response.Stocks.Count == 0)
            return NoContent();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortInventoryJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestStockJson request)
    {
        try
        {
            var response = _registerUseCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (Exception ex)
        {
            return Problem(detail: ex.Message, statusCode: 500);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestStockJson request)
    {
        try
        {
            _updateUseCase.Execute(id, request);

            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(detail: ex.Message, statusCode: 500);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _deleteUseCase.Execute(id);

            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(detail: ex.Message, statusCode: 500);
        }
    }
}
