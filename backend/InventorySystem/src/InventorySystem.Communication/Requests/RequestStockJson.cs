namespace InventorySystem.Communication.Requests;

public class RequestStockJson
{
    public string NameProduct { get; set; } = string.Empty;
    public int Amount { get; set; }
    public decimal Price { get; set; }
}
