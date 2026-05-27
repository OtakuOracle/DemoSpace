using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class EventLog
{
    public int EventLogId { get; set; }

    public int? EventTypeId { get; set; }

    public string? Description { get; set; }

    public int? StationModuleId { get; set; }

    public int? DangerLevelId { get; set; }

    public DateOnly? CreatedAtDate { get; set; }

    public TimeOnly? CreatedAtTime { get; set; }

    public virtual DangerLevel? DangerLevel { get; set; }

    public virtual EventType? EventType { get; set; }

    public virtual StationModule? StationModule { get; set; }
}
