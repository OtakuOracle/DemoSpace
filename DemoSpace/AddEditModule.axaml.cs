using System;
using System.IO;
using System.Linq;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using DemoSpace.Models;
using MsBox.Avalonia;

namespace DemoSpace;

public partial class AddEditModule : Window
{

    User localUser;
    private string ImageName;
    private string current_photo;
    private StationModule updatestationModule;

    public AddEditModule() //add
    {
        InitializeComponent();
        DataContext = new StationModule();
        LoadStatus();
        LoadModuleType();
        EditBut.IsVisible = false;
        DeleteBut.IsVisible = false;
        AddBut.IsVisible = true;
    }


    public AddEditModule(User user)
    {
        localUser = user;
    }

    public AddEditModule(User user, StationModule module) //edit
    {
        InitializeComponent();
        using var context = new DiplomContext();
        updatestationModule = module;
        DataContext = updatestationModule;
        localUser = user;
        LoadStatus();
        LoadModuleType();
        ImageBox.Source = updatestationModule.GetPhoto;
        EditBut.IsVisible = true;
        DeleteBut.IsVisible = true;
        AddBut.IsVisible = false;

        Status.SelectedItem = updatestationModule?.Status?.StatusName;
        ModuleType.SelectedItem = updatestationModule?.ModuleType?.ModuleTypeName;
    }

    private void LoadStatus()
    {
        using var context = new DiplomContext();
        Status.ItemsSource = context.Statuses.Select(x => x.StatusName).ToList();
    }


    private void LoadModuleType()
    {
        using var context = new DiplomContext();
        ModuleType.ItemsSource = context.ModuleTypes.Select(x => x.ModuleTypeName).ToList();
    }

    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Class1.isAdmin == true)
        {
            var catalogWindow = new ModuleWindow(Class1._user);
            catalogWindow.Show();
            this.Close();
        }
        else
        {
            var catalogWindow = new ModuleWindow();
            catalogWindow.Show();
            this.Close();
        }
    }

    private async void Add_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            using var context = new DiplomContext();
            var newStationModule = DataContext as StationModule;

            


            if (Status.SelectedItem != null && ModuleType.SelectedItem != null)
            {
                newStationModule?.Status = context.Statuses.FirstOrDefault(x => x.StatusName == Status.SelectedItem!.ToString())!;
                newStationModule?.ModuleType = context.ModuleTypes.FirstOrDefault(x => x.ModuleTypeName == ModuleType.SelectedItem!.ToString())!;

                newStationModule?.Photo = "images/" + ImageName;


                context.StationModules.Add(newStationModule);
                await context.SaveChangesAsync();

                var message = MessageBoxManager.GetMessageBoxStandard("Успех", "Модуль создан", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Success);
                await message.ShowAsync();

                if (Class1.isAdmin == true)
                {
                    var moduleWindow = new ModuleWindow(Class1._user);
                    moduleWindow.Show();
                    this.Close();
                }
                else
                {
                    var moduleWindow = new ModuleWindow();
                    moduleWindow.Show();
                    this.Close();
                }
            }
            else
            {
                var error = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Пожалуйста, заполните все поля", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                await error.ShowAsync();
            }
        }
        catch (Exception ex)
        {
            var excep = ex.ToString();
            var error = MessageBoxManager.GetMessageBoxStandard("Ошибка", excep, MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            await error.ShowAsync();
        }
    }

    private async void AddImage_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);

        var file = await topLevel.StorageProvider.SaveFilePickerAsync(new Avalonia.Platform.Storage.FilePickerSaveOptions
        {
            Title = "Добавить изображение",
            FileTypeChoices = new[]
            {
            FilePickerFileTypes.All
        }
        });

        if (file != null)
        {
            ImageBox.Source = new Bitmap(file.Path.LocalPath);
            ImageName = Guid.NewGuid().ToString() + ".png";
            var targetPath = AppDomain.CurrentDomain.BaseDirectory + "/images/" + ImageName;
            File.Copy(file.Path.LocalPath, targetPath);

        }
    }

    private async void Delete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using var context = new DiplomContext();

        var moduleId = updatestationModule.StationModuleId;

        var moduleToDelete = context.StationModules.Where(x => x.StationModuleId == moduleId).FirstOrDefault();

        context.StationModules.Remove(moduleToDelete!);
        context.SaveChanges();

        var message = MessageBoxManager.GetMessageBoxStandard("Успех", "Модуль удален", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Success);
        await message.ShowAsync();

        if (Class1.isAdmin == true)
        {
            var moduleWindow = new ModuleWindow(Class1._user);
            moduleWindow.Show();
            this.Close();
        }
        else
        {
            var moduleWindow = new ModuleWindow();
            moduleWindow.Show();
            this.Close();
        }
    }


  

    private async void Edit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using var context = new DiplomContext();
        var updatestationModule = DataContext as StationModule;

        try
        {

            updatestationModule?.Status = context.Statuses.FirstOrDefault(x => x.StatusName == Status.SelectedItem!.ToString())!;
            updatestationModule?.ModuleType = context.ModuleTypes.FirstOrDefault(x => x.ModuleTypeName == ModuleType.SelectedItem!.ToString())!;



            if (!string.IsNullOrEmpty(ImageName))
            {
                updatestationModule?.Photo = "images/" + ImageName;
            }
            else if (!string.IsNullOrEmpty(current_photo))
            {
                updatestationModule?.Photo = current_photo;
            }

     

            context.StationModules.Update(updatestationModule);
            context.SaveChanges();



            var message = MessageBoxManager.GetMessageBoxStandard("Успех", "Модуль изменен", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Success);
            await message.ShowAsync();

            if (Class1.isAdmin == true)
            {
                var catalogWindow = new ModuleWindow(Class1._user);
                catalogWindow.Show();
                this.Close();
            }
            else
            {
                var catalogWindow = new ModuleWindow();
                catalogWindow.Show();
                this.Close();
            }

        }
        catch (Exception ex)
        {
            var exec = ex.ToString();
            var error = MessageBoxManager.GetMessageBoxStandard("Ошибка", exec, MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            await error.ShowAsync();
        }

    }


}