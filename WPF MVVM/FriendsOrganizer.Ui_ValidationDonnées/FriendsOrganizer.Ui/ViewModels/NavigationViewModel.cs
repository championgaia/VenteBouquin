using DataAccess;
using FriendsOrganizer.Ui.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class NavigationViewModel :ViewModelBase, INavigationViewModel
    {
        private List<Friend> _friends;
        public List<Friend> Friends
        {
            get { return _friends; }
            set { _friends = value; OnPropertyChanged(); }
        }

        IEventAggregator _aggregator;
        IFriendRepository _repository;
        public NavigationViewModel(IFriendRepository repository, IEventAggregator agg)
        {
            _repository = repository;
            Friends = _repository.GetFriends();
            _aggregator = agg;
            _aggregator.GetEvent<SaveFriendEvent>().Subscribe(OnFriendsSaved);
        }

        private void OnFriendsSaved()
        {
            Friends = _repository.GetFriends();
        }

        private Friend _friend;

        public Friend SelectedFriend
        {
            get { return _friend; }
            set {
                _friend = value;
                if(_friend != null)
                {
                    _aggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(_friend.Id);
                }
            }
        }



    }
}
