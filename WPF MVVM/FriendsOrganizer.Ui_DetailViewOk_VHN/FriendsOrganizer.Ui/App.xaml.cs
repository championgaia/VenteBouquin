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
using System.Windows.Threading;

namespace FriendsOrganizer.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //var f = new FriendsMemoryRepository();
            //var vm = new MainViewModel(f);
            //var m = new MainWindow(vm);
            //m.Show();

            var boostrapper = new Bootstrapper();
            var container = boostrapper.Bootstrap();

            var mainwindow = container.Resolve<MainWindow>();
           
            mainwindow.Show();
        }
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
        }
    }
}
