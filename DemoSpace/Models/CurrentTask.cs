using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class CurrentTask
{
    public int CurrentTaskId { get; set; }

    public string? CurrentTaskName { get; set; }

    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();
}
