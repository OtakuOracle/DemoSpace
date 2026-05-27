using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();

    public virtual Role? Role { get; set; }
}
