using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class Severity
{
    public int SeverityId { get; set; }

    public string? SeverityName { get; set; }

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
}
