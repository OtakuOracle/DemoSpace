using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoSpace.Models;

public partial class DiplomContext : DbContext
{
    public DiplomContext()
    {
    }

    public DiplomContext(DbContextOptions<DiplomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<AlertType> AlertTypes { get; set; }

    public virtual DbSet<CrewMember> CrewMembers { get; set; }

    public virtual DbSet<CurrentTask> CurrentTasks { get; set; }

    public virtual DbSet<DangerLevel> DangerLevels { get; set; }

    public virtual DbSet<EventLog> EventLogs { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Mission> Missions { get; set; }

    public virtual DbSet<ModuleType> ModuleTypes { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Severity> Severities { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<StationModule> StationModules { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusMission> StatusMissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=213.171.24.157;Username=nastya;Password=123;Port=5432;Database=diplom");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.AlertId).HasName("alert_pkey");

            entity.ToTable("alert", "space");

            entity.Property(e => e.AlertId).HasColumnName("alert_id");
            entity.Property(e => e.AlertType).HasColumnName("alert_type");
            entity.Property(e => e.CreatedAtDate).HasColumnName("created_at_date");
            entity.Property(e => e.CreatedAtTime).HasColumnName("created_at_time");
            entity.Property(e => e.IsResolved).HasColumnName("is_resolved");
            entity.Property(e => e.SeverityId).HasColumnName("severity_id");
            entity.Property(e => e.StationModuleId).HasColumnName("station_module_id");

            entity.HasOne(d => d.AlertTypeNavigation).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.AlertType)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("alert_alert_type_fkey");

            entity.HasOne(d => d.Severity).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.SeverityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("alert_severity_id_fkey");

            entity.HasOne(d => d.StationModule).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.StationModuleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("alert_station_module_id_fkey");
        });

        modelBuilder.Entity<AlertType>(entity =>
        {
            entity.HasKey(e => e.AlertTypeId).HasName("alert_type_pkey");

            entity.ToTable("alert_type", "space");

            entity.Property(e => e.AlertTypeId).HasColumnName("alert_type_id");
            entity.Property(e => e.AlertTypeName)
                .HasColumnType("character varying")
                .HasColumnName("alert_type_name");
        });

        modelBuilder.Entity<CrewMember>(entity =>
        {
            entity.HasKey(e => e.CrewMemberId).HasName("crew_member_pkey");

            entity.ToTable("crew_member", "space");

            entity.Property(e => e.CrewMemberId).HasColumnName("crew_member_id");
            entity.Property(e => e.CurrentTask).HasColumnName("current_task");
            entity.Property(e => e.FatigueLevel).HasColumnName("fatigue_level");
            entity.Property(e => e.SpecializationId).HasColumnName("specialization_id");
            entity.Property(e => e.StationModuleId).HasColumnName("station_module_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CurrentTaskNavigation).WithMany(p => p.CrewMembers)
                .HasForeignKey(d => d.CurrentTask)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("crew_member_current_task_fkey");

            entity.HasOne(d => d.Specialization).WithMany(p => p.CrewMembers)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("crew_member_specialization_id_fkey");

            entity.HasOne(d => d.StationModule).WithMany(p => p.CrewMembers)
                .HasForeignKey(d => d.StationModuleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("crew_member_station_module_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.CrewMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("crew_member_user_id_fkey");
        });

        modelBuilder.Entity<CurrentTask>(entity =>
        {
            entity.HasKey(e => e.CurrentTaskId).HasName("current_task_pkey");

            entity.ToTable("current_task", "space");

            entity.Property(e => e.CurrentTaskId).HasColumnName("current_task_id");
            entity.Property(e => e.CurrentTaskName)
                .HasColumnType("character varying")
                .HasColumnName("current_task_name");
        });

        modelBuilder.Entity<DangerLevel>(entity =>
        {
            entity.HasKey(e => e.DangerLevelId).HasName("danger_level_pkey");

            entity.ToTable("danger_level", "space");

            entity.Property(e => e.DangerLevelId).HasColumnName("danger_level_id");
            entity.Property(e => e.DangerLevelName)
                .HasColumnType("character varying")
                .HasColumnName("danger_level_name");
        });

        modelBuilder.Entity<EventLog>(entity =>
        {
            entity.HasKey(e => e.EventLogId).HasName("event_log_pkey");

            entity.ToTable("event_log", "space");

            entity.Property(e => e.EventLogId).HasColumnName("event_log_id");
            entity.Property(e => e.CreatedAtDate).HasColumnName("created_at_date");
            entity.Property(e => e.CreatedAtTime).HasColumnName("created_at_time");
            entity.Property(e => e.DangerLevelId).HasColumnName("danger_level_id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.StationModuleId).HasColumnName("station_module_id");

            entity.HasOne(d => d.DangerLevel).WithMany(p => p.EventLogs)
                .HasForeignKey(d => d.DangerLevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_log_danger_level_id_fkey");

            entity.HasOne(d => d.EventType).WithMany(p => p.EventLogs)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_log_event_type_id_fkey");

            entity.HasOne(d => d.StationModule).WithMany(p => p.EventLogs)
                .HasForeignKey(d => d.StationModuleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_log_station_module_id_fkey");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("event_type_pkey");

            entity.ToTable("event_type", "space");

            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.EventTypeName)
                .HasColumnType("character varying")
                .HasColumnName("event_type_name");
        });

        modelBuilder.Entity<Mission>(entity =>
        {
            entity.HasKey(e => e.MissionId).HasName("mission_pkey");

            entity.ToTable("mission", "space");

            entity.Property(e => e.MissionId).HasColumnName("mission_id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.MissionName)
                .HasColumnType("character varying")
                .HasColumnName("mission_name");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusModule).HasColumnName("status_module");

            entity.HasOne(d => d.Priority).WithMany(p => p.Missions)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mission_priority_id_fkey");

            entity.HasOne(d => d.StatusModuleNavigation).WithMany(p => p.Missions)
                .HasForeignKey(d => d.StatusModule)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mission_status_module_fkey");
        });

        modelBuilder.Entity<ModuleType>(entity =>
        {
            entity.HasKey(e => e.ModuleTypeId).HasName("module_type_pkey");

            entity.ToTable("module_type", "space");

            entity.Property(e => e.ModuleTypeId).HasColumnName("module_type_id");
            entity.Property(e => e.ModuleTypeName)
                .HasColumnType("character varying")
                .HasColumnName("module_type_name");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.PriorityId).HasName("priority_pkey");

            entity.ToTable("priority", "space");

            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.PriorityName)
                .HasColumnType("character varying")
                .HasColumnName("priority_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pkey");

            entity.ToTable("role", "space");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Severity>(entity =>
        {
            entity.HasKey(e => e.SeverityId).HasName("severity_pkey");

            entity.ToTable("severity", "space");

            entity.Property(e => e.SeverityId).HasColumnName("severity_id");
            entity.Property(e => e.SeverityName)
                .HasColumnType("character varying")
                .HasColumnName("severity_name");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecializationId).HasName("specialization_pkey");

            entity.ToTable("specialization", "space");

            entity.Property(e => e.SpecializationId).HasColumnName("specialization_id");
            entity.Property(e => e.SpecializationName)
                .HasColumnType("character varying")
                .HasColumnName("specialization_name");
        });

        modelBuilder.Entity<StationModule>(entity =>
        {
            entity.HasKey(e => e.StationModuleId).HasName("station_module_pkey");

            entity.ToTable("station_module", "space");

            entity.Property(e => e.StationModuleId).HasColumnName("station_module_id");
            entity.Property(e => e.DamageLevel).HasColumnName("damage_level");
            entity.Property(e => e.EnergyLevel).HasColumnName("energy_level");
            entity.Property(e => e.ModuleTypeId).HasColumnName("module_type_id");
            entity.Property(e => e.OxygenLevel).HasColumnName("oxygen_level");
            entity.Property(e => e.Photo)
                .HasColumnType("character varying")
                .HasColumnName("photo");
            entity.Property(e => e.StationModuleName)
                .HasColumnType("character varying")
                .HasColumnName("station_module_name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Temperature).HasColumnName("temperature");

            entity.HasOne(d => d.ModuleType).WithMany(p => p.StationModules)
                .HasForeignKey(d => d.ModuleTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("station_module_module_type_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.StationModules)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("station_module_status_id_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("status_pkey");

            entity.ToTable("status", "space");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasColumnType("character varying")
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<StatusMission>(entity =>
        {
            entity.HasKey(e => e.StatusMissionId).HasName("status_module_pkey");

            entity.ToTable("status_mission", "space");

            entity.Property(e => e.StatusMissionId)
                .HasDefaultValueSql("nextval('space.status_module_status_module_id_seq'::regclass)")
                .HasColumnName("status_mission_id");
            entity.Property(e => e.StatusMissionName)
                .HasColumnType("character varying")
                .HasColumnName("status_mission_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pkey");

            entity.ToTable("user", "space");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasColumnType("character varying")
                .HasColumnName("full_name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
