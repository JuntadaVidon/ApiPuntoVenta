using System;
using System.Collections.Generic;

namespace M4Facturation.Domain.Models;

public partial class Products : IEntityAuditable
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }

    public int? UnitsOnOrder { get; set; }

    public int? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public string? UserIng { get; set; }

    public DateTime? FecIng { get; set; }

    public string? UserMod { get; set; }

    public DateTime? FecMod { get; set; }

    public string? UserBaja { get; set; }

    public DateTime? FecBaja { get; set; }

    public virtual Categories? Category { get; set; }

    public virtual ICollection<SalesDetails> SalesDetails { get; set; } = new List<SalesDetails>();

    public virtual Suppliers? Supplier { get; set; }
}