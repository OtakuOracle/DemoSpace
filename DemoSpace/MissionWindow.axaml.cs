using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoSpace.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;

namespace DemoSpace;

public partial class MissionWindow : Window
{
    User localUser;
    public MissionWindow()
    {
        InitializeComponent();
        Get();
    }


    private void Get()
    {
        using var context = new DiplomContext();
        var allMissions = context.Missions
                                 .Include(x => x.StatusModuleNavigation)
                                 .Include(x => x.Priority)
                                 .ToList();

        MissionsBox.ItemsSource = allMissions;

    }

    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var moduleWindow = new ModuleWindow();
        moduleWindow.Show();
        this.Close();
    }



}