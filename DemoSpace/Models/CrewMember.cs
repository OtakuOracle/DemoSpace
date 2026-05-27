using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class CrewMember
{
    public int CrewMemberId { get; set; }

    public int? UserId { get; set; }

    public int? SpecializationId { get; set; }

    public int? FatigueLevel { get; set; }

    public int? CurrentTask { get; set; }

    public int? StationModuleId { get; set; }

    public virtual CurrentTask? CurrentTaskNavigation { get; set; }

    public virtual Specialization? Specialization { get; set; }

    public virtual StationModule? StationModule { get; set; }

    public virtual User? User { get; set; }
}
