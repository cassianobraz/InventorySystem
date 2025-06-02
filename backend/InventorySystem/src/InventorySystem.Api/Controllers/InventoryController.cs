using InventorySystem.Api.UseCases.Stocks.Delete;
using InventorySystem.Api.UseCases.Stocks.GetAll;
using InventorySystem.Api.UseCases.Stocks.GetById;
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
    private readonly GetAllInventoryUseCase _getAllUseCase;
    private readonly RegisterInventoryUseCase _registerUseCase;
    private readonly UpdateInventoryUseCase _updateUseCase;
    private readonly DeleteInventoryUseCase _deleteUseCase;
    private readonly GetByInventoryUseCase _getByIdUseCase;

    public InventoryController(
    GetAllInventoryUseCase getAllUseCase,
    RegisterInventoryUseCase registerUseCase,
    UpdateInventoryUseCase updateUseCase,
    DeleteInventoryUseCase deleteUseCase,
    GetByInventoryUseCase getByIdUseCase)
    {
        _getAllUseCase = getAllUseCase;
        _registerUseCase = registerUseCase;
        _updateUseCase = updateUseCase;
        _deleteUseCase = deleteUseCase;
        _getByIdUseCase = getByIdUseCase;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllStocksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        try
        {
            var response = _getAllUseCase.Execute();

            if (response.Stocks.Count == 0)
                return NoContent();

            return Ok(response);
        }
        catch (Exception ex)
        {
            return Problem(detail: ex.Message, statusCode: 500);
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ResponseAllStocksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            var response = _getByIdUseCase.Execute(id);

            if (response.Stocks.Count == 0)
                return NoContent();

            return Ok(response);
        }
        catch (Exception ex)
        {
            return Problem(detail: ex.Message, statusCode: 500);
        }
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
