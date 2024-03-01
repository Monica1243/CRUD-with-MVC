using System;
using System.Collections.Generic;

namespace Ecommerce.Models.Domain;

public partial class Sale
{
    public DateTime Month { get; set; }

    public DateTime Year { get; set; }

    public decimal SalesAmount { get; set; }
}
