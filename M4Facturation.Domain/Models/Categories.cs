namespace M4Facturation.Domain.Models;

public partial class Categories :IEntityAuditable
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public string? UserIng { get; set; }

    public DateTime? FecIng { get; set; }

    public string? UserMod { get; set; }

    public DateTime? FecMod { get; set; }

    public string? UserBaja { get; set; }

    public DateTime? FecBaja { get; set; }

    public virtual ICollection<Products> Products { get; set; } = new List<Products>();
}
