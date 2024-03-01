using System;
using System.Collections.Generic;

namespace Ecommerce.Models.Domain;

public partial class RefundDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string RefundStatus { get; set; } = null!;

    public decimal RefundAmount { get; set; }

    public virtual OrderDetail Order { get; set; } = null!;
}
