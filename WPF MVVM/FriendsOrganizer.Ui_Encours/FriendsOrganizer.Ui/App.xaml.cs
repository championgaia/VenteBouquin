using Autofac;
using DataAccess;
using FriendsOrganizer.Ui.StartUp;
using FriendsOrganizer.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FriendsOrganizer.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_StartUp(object sender, StartupEventArgs arg)
        {
            //var mainWindow = new MainWindow(new MainViewModel(new FriendsMemoryRepository()));
            var container = new Bootstrapper().Boostrap();
            var mainWindow = container.Resolve<MainWindow>();


            mainWindow.Show();
        }
        
    }
}
