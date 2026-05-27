using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class Mission
{
    public int MissionId { get; set; }

    public string? MissionName { get; set; }

    public string? Description { get; set; }

    public int? PriorityId { get; set; }

    public DateOnly? StartDate { get; set; }

    public int? StatusModule { get; set; }

    public virtual Priority? Priority { get; set; }

    public virtual StatusMission? StatusModuleNavigation { get; set; }
}
