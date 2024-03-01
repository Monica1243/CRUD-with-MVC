using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace Ecommerce.Models.Domain;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public string ProductImage { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public decimal Rating { get; set; }

    public bool Active { get; set; }

    public int AvailableQuantity { get; set; }

    public DateTime ModifiedAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
