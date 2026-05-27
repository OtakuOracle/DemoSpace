using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class DangerLevel
{
    public int DangerLevelId { get; set; }

    public string? DangerLevelName { get; set; }

    public virtual ICollection<EventLog> EventLogs { get; set; } = new List<EventLog>();
}
