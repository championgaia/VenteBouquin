using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        public List<Friend> Friends { get; set; }

        public IFriendRepository _repository;
        public NavigationViewModel(IFriendRepository repository)
        {
            _repository = repository;
            Friends = _repository.GetFriends();
        }

    }
}
