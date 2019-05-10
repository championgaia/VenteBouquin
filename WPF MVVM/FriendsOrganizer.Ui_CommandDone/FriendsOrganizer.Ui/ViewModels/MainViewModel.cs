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
        public IFriendDetailViewModel FriendDetailVM { get; }
        public MainViewModel(INavigationViewModel navigationViewModel, IFriendDetailViewModel friendViewModel)
        {
            NavigationVM = navigationViewModel;
            FriendDetailVM = friendViewModel;
        }

    }
}
