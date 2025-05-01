using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    [HttpGet]
    public IActionResult GetInventory()
    {
        var inventory = new List<string> { "Item1", "Item2", "Item3" };
        return Ok(inventory);
    }

    [HttpPost]
    public IActionResult AddItem([FromBody] string item)
    {
        return Created();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateItem([FromRoute] int id, [FromBody] string item)
    {
        return Ok(item);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteItem([FromRoute] int id)
    {
        return NoContent();
    }
}

