using System;
using System.Collections.Generic;

namespace Ecommerce.Models.Domain;

public partial class OrderSummary
{
    public int OrderId { get; set; }

    public Guid UserId { get; set; }

    public decimal InvoiceAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal Discount { get; set; }

    public decimal? TotalAmount { get; set; }

    public string PaymentType { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    public virtual OrderDetail Order { get; set; } = null!;

    public virtual UserDetail User { get; set; } = null!;
}
