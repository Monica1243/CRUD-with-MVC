using System;
using System.Collections.Generic;
using Ecommerce.Models.Domain;

namespace WebAPI.Models;

public partial class Discount
{
    public bool MembershipType { get; set; }

    public bool Active { get; set; }

    public decimal Discount1 { get; set; }

    public DateTime ModifiedAt { get; set; }

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
