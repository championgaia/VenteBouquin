using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        public NavigationViewModel()
        {

        }
        public NavigationViewModel(IFriendRepository repo)
        {
            _repo = repo;
            Friends = _repo.GetFriends();
        }
        public List<Friend> Friends { get ; set ; }
        public IFriendRepository _repo { get; set ; }
    }
}
