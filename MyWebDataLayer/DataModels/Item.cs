using System;
using System.Collections.Generic;

namespace MyWebDataLayer.DataModels;

public partial class Item
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<PurchasePrice> PurchasePrices { get; set; } = new List<PurchasePrice>();
}
