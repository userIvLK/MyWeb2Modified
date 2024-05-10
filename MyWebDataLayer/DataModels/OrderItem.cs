using System;
using System.Collections.Generic;

namespace MyWebDataLayer.DataModels;

public partial class OrderItem
{
    public Guid Id { get; set; }

    public Guid OderId { get; set; }

    public Guid ItemId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Oder { get; set; } = null!;
}
