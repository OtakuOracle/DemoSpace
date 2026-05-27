using System;
using System.Collections.Generic;

namespace DemoSpace.Models;

public partial class StatusMission
{
    public int StatusMissionId { get; set; }

    public string? StatusMissionName { get; set; }

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
