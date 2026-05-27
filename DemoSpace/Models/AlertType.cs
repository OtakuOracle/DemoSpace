using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class AlertType
{
    public int AlertTypeId { get; set; }

    public string? AlertTypeName { get; set; }

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
}
