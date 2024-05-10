using System;
using System.Collections.Generic;

namespace MyWebDataLayer.DataModels;

public partial class PurchasePrice
{
    public Guid Id { get; set; }

    public Guid ItemId { get; set; }

    public DateTime PriceDate { get; set; }

    public decimal Price { get; set; }

    public virtual Item Item { get; set; } = null!;
}
