using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;

namespace DemoSpace.Models;

public partial class StationModule
{
    public int StationModuleId { get; set; }

    public string? StationModuleName { get; set; }

    public int? ModuleTypeId { get; set; }

    public int? EnergyLevel { get; set; }

    public string ColourEnergyLevel
    {
        get
        {
            if (EnergyLevel < 40)
            {
                return "#4DA6FF";
            }
            else
            {
                return "";
            }

        }
    }


    public int? OxygenLevel { get; set; }
    public string ColourOxygenLevel
    {
        get
        {
            if (OxygenLevel < 40)
            {
                return "#4DA6FF";
            }
            else
            {
                return "";
            }

        }
    }


    public int? Temperature { get; set; }
    public string ColourTemperature
    {
        get
        {
            if (Temperature > 60)
            {
                return "#4DA6FF";
            }
            else
            {
                return "";
            }

        }
    }

    public int? DamageLevel { get; set; }

    public int? StatusId { get; set; }

    public string? Photo { get; set; }
    public Bitmap GetPhoto
    {
        get
        {
            if (Photo != null && Photo != "")
            {
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "/" + Photo);
            }
            else
            {
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "/images/not.png");
            }

        }
    }

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();

    public virtual ICollection<EventLog> EventLogs { get; set; } = new List<EventLog>();

    public virtual ModuleType? ModuleType { get; set; }

    public virtual Status? Status { get; set; }
}
