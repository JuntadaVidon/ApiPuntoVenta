namespace M4Facturation.Domain.Models;

public partial class Sales :IEntityAuditable
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly SaleDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? UserIng { get; set; }

    public DateTime? FecIng { get; set; }

    public string? UserMod { get; set; }

    public DateTime? FecMod { get; set; }

    public string? UserBaja { get; set; }

    public DateTime? FecBaja { get; set; }

    public virtual Customers? Customer { get; set; }

    public virtual ICollection<SalesDetails> SalesDetails { get; set; } = new List<SalesDetails>();
}
