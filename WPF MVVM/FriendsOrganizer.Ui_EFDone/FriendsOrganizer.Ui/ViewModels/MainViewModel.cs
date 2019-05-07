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
        IFriendRepository _repository;
        public MainViewModel(IFriendRepository repository)
        {
            _repository = repository;
            Friends = _repository.GetFriends();
        }

        public List<Friend> Friends { get; set; }
        private Friend _selectedFriend;
        public Friend SelectedFriend {
            get
            {
                return _selectedFriend;
            }
            set
            {
                _selectedFriend = value;
            }
        }


      

    }
}
