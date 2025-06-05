using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("stocks")]
public class Stock
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name_product")]
    [MaxLength(255)]
    public string NameProduct { get; set; } = string.Empty;

    [Column("amount")]
    public int Amount { get; set; }

    [Column("price", TypeName = "numeric(10,2)")]
    public decimal Price { get; set; }

    [Column("create_at")]
    public DateTime Create_at { get; set; } = DateTime.UtcNow;
}
