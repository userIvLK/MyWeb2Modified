using System;
using System.Collections.Generic;

namespace MyWebDataLayer.DataModels;

public partial class Order
{
    public Guid Id { get; set; }

    public string Customer { get; set; } = null!;

    public DateTime Orderdate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
