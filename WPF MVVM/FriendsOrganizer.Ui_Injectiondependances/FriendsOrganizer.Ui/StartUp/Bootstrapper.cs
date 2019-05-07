using Autofac;
using DataAccess;
using FriendsOrganizer.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.StartUp
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FriendsMemoryRepository>().As<IFriendRepository>();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            return builder.Build();

        }


    }
}
