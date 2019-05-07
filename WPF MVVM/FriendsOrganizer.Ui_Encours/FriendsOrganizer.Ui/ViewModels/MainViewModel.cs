using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class MainViewModel
    {
        public IFriendDetailViewModel DetailVM { get; set; }
        public INavigationViewModel NavigationVM { get; set; }
        public MainViewModel(INavigationViewModel naviVM, IFriendDetailViewModel detailVM)
        {
            NavigationVM = naviVM;
            DetailVM = detailVM;
        }
    }
}
