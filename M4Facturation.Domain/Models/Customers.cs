﻿namespace M4Facturation.Domain.Models;

public partial class Customers :IEntityAuditable
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? UserIng { get; set; }

    public DateTime? FecIng { get; set; }

    public string? UserMod { get; set; }

    public DateTime? FecMod { get; set; }

    public string? UserBaja { get; set; }

    public DateTime? FecBaja { get; set; }

    public virtual ICollection<Sales> Sales { get; set; } = new List<Sales>();
}
