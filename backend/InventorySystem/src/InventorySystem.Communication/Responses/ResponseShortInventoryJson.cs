namespace InventorySystem.Communication.Responses;

public class ResponseShortInventoryJson
{
    public int Id { get; set; }
    public string NameProduct { get; set; } = string.Empty;
    public int Amount { get; set; }
    public DateTime Create_at { get; set; } = DateTime.UtcNow;
}
