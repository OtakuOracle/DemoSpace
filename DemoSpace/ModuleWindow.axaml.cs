using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoSpace.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;

namespace DemoSpace;

public partial class ModuleWindow : Window
{
    User localUser;
    public ModuleWindow()
    {
        InitializeComponent();
        using var context = new DiplomContext();
        Visibility(3);
        FioTextBlock.Text = "Гость";
        RoleTextBlock.Text = "";
        Get();
    }

    public ModuleWindow(User user)
    {
        InitializeComponent();
        localUser = user;
        Visibility(user.RoleId);
        using var context = new DiplomContext();
        FioTextBlock.Text = user.FullName;
        RoleTextBlock.Text = user.Role?.RoleName;
        Get();

    }

    public void Visibility(int roleId)
    {
        switch (roleId)
        {
            case 1: AddButton.IsVisible = true; break;
           
        }
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

    private void ModulesBox_SelectionChanged(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ModulesBox.SelectedItem is StationModule module)
        {
            if (Class1.isAdmin == true)
            {
                var addedit = new AddEditModule(localUser, module);
                addedit.Show();
                this.Close();

            }

            else
            {
                var mess = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Войдите чтобы редактировать", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                mess.ShowAsync();

            }
        }

    }

    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        var add = new AddEditModule();
        add.Show();
        this.Close();


    }


}