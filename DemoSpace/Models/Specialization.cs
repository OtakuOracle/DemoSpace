using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class Specialization
{
    public int SpecializationId { get; set; }

    public string? SpecializationName { get; set; }

    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();
}
