using System;
using System.Collections.Generic;

namespace Ecommerce.Models.Domain;

public partial class TaxCalculation
{
    public decimal Amount { get; set; }

    public decimal Tax { get; set; }
}
