﻿namespace InventorySystem.Api.Entities;

public class Stock
{
    public int Id { get; set; }
    public string NameProduct { get; set; } = string.Empty;
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public DateTime Create_at { get; set; } = DateTime.UtcNow;
}
