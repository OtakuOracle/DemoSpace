using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class Priority
{
    public int PriorityId { get; set; }

    public string? PriorityName { get; set; }

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
