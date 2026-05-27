using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class StationModule
{
    public int StationModuleId { get; set; }

    public string? StationModuleName { get; set; }

    public int? ModuleTypeId { get; set; }

    public int? EnergyLevel { get; set; }

    public int? OxygenLevel { get; set; }

    public int? Temperature { get; set; }

    public int? DamageLevel { get; set; }

    public int? StatusId { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();

    public virtual ICollection<EventLog> EventLogs { get; set; } = new List<EventLog>();

    public virtual ModuleType? ModuleType { get; set; }

    public virtual Status? Status { get; set; }
}
