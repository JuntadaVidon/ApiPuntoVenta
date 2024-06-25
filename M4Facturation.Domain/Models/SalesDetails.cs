using System;
using System.Collections.Generic;

namespace M4Facturation.Domain.Models;

public partial class SalesDetails :IEntityAuditable
{
    public int Id { get; set; }

    public int? SaleId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? Discount { get; set; }

    public string? UserIng { get; set; }

    public DateTime? FecIng { get; set; }

    public string? UserMod { get; set; }

    public DateTime? FecMod { get; set; }

    public string? UserBaja { get; set; }

    public DateTime? FecBaja { get; set; }

    public virtual Products? Product { get; set; }

    public virtual Sales? Sale { get; set; }
}
