using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class MainViewModelNew
    {
        public List<Friend> Friends { get; set; }
        private Friend _selectedFriend;
        public Friend SelectedFriend
        {
            get
            {
                return _selectedFriend;
            }
            set
            {
                _selectedFriend = value;
            }
        }

        IFriendRepository _repo;
        public MainViewModelNew()
        {

        }
        public MainViewModelNew(IFriendRepository repo)
        {
            _repo = repo;
            Friends = _repo.GetFriends();
        }
    }
}
