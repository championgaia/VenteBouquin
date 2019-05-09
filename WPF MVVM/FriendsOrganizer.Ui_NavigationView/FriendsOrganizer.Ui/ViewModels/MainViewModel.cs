using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class MainViewModel
    {
        public INavigationViewModel NavigationVM { get; }
        public MainViewModel(INavigationViewModel navigationViewModel)
        {
            NavigationVM = navigationViewModel;
        }

    }
}
