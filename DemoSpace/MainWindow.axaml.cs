using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using DemoSpace.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;

namespace DemoSpace;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Guest_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ModuleWindow moduleWindow = new ModuleWindow();
        moduleWindow.Show();
        this.Close();

    }

    private async void Auth_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using var context = new DiplomContext();
        var login = LoginTextBox.Text;
        var passw = PasswordTextBox.Text;

        var user = context.Users
             .Include(u => u.Role)
            .FirstOrDefault(x => x.Email == login && x.Password == passw);
        if(user != null)
        {
            if(user.RoleId == 1)
            {
                Class1.isAdmin = true;
                Class1._user = user;
            }
            ModuleWindow moduleWindow = new ModuleWindow(user);
            moduleWindow.Show();
            this.Close();
        }
        else
        {
            var message = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Некорректные данные", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            await message.ShowAsync();
        }
    }


}