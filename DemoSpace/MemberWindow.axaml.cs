using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoSpace;

public partial class MemberWindow : Window
{
    public MemberWindow()
    {
        InitializeComponent();
        Get();
    }


    private void Get()
    {
        using var context = new DiplomContext();
        var allMembers = context.CrewMembers
                                .Include(x => x.User)
                                .Include(x => x.Specialization)
                                .Include(x => x.CurrentTaskNavigation)
                                .Include(x => x.StationModule)
                                .ToList();

        MembersBox.ItemsSource = allMembers;
    }


    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var moduleWindow = new ModuleWindow();
        moduleWindow.Show();
        this.Close();
    }

}