using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<StationModule> StationModules { get; set; } = new List<StationModule>();
}
