namespace InventorySystem.Communication.Responses;

public class ResponseAllStocksJson
{
    public List<ResponseShortInventoryJson> Stocks { get; set; } = [];
}
