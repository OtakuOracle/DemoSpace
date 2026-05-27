using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class Alert
{
    public int AlertId { get; set; }

    public int? StationModuleId { get; set; }

    public int? AlertType { get; set; }

    public int? SeverityId { get; set; }

    public DateOnly? CreatedAtDate { get; set; }

    public TimeOnly? CreatedAtTime { get; set; }

    public bool? IsResolved { get; set; }

    public virtual AlertType? AlertTypeNavigation { get; set; }

    public virtual Severity? Severity { get; set; }

    public virtual StationModule? StationModule { get; set; }
}
