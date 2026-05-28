using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoSpace;

public partial class ModuleWindow : Window
{
    User localUser;
    public ModuleWindow()
    {
        InitializeComponent();
        using var context = new DiplomContext();
        FioTextBlock.Text = "Гость";
        RoleTextBlock.Text = "";
        Get();
    }

    public ModuleWindow(User user)
    {
        InitializeComponent();
        localUser = user;
        using var context = new DiplomContext();
        FioTextBlock.Text = user.FullName;
        RoleTextBlock.Text = user.Role?.RoleName;
        Get();

    }


    private void Get()
    {
        using var context = new DiplomContext();

        var allModules = context.StationModules
                                .Include(x => x.ModuleType)
                                .Include(x => x.Status)
                                .ToList();

        ModulesBox.ItemsSource = allModules;



    }


    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var main = new MainWindow();
        main.Show();
        this.Close();
    }


}