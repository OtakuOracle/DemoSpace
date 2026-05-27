using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class ModuleType
{
    public int ModuleTypeId { get; set; }

    public string? ModuleTypeName { get; set; }

    public virtual ICollection<StationModule> StationModules { get; set; } = new List<StationModule>();
}
