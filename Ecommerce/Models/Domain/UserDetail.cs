using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebAPI.Models;

namespace Ecommerce.Models.Domain;

public partial class UserDetail
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool? MembershipType { get; set; }

    public string Role { get; set; } = null!;

    public string? Address { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    [JsonIgnore]
    public virtual Discount? MembershipTypeNavigation { get; set; }
}
