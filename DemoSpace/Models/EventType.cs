using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class EventType
{
    public int EventTypeId { get; set; }

    public string? EventTypeName { get; set; }

    public virtual ICollection<EventLog> EventLogs { get; set; } = new List<EventLog>();
}
