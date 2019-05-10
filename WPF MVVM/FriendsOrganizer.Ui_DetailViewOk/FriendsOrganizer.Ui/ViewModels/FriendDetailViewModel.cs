using DataAccess;
using FriendsOrganizer.Ui.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class FriendDetailViewModel : ViewModelBase,IFriendDetailViewModel
    {
        Friend _currentFriend;
        IFriendRepository _repository { get; set; }
        IEventAggregator _aggregator;
        public FriendDetailViewModel(IFriendRepository repo, IEventAggregator agg)
        {
            _repository = repo;
            _aggregator = agg;
            _aggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriend);
        }
        public Friend CurrentFriend
        {
            get { return _currentFriend; }
            set {
                _currentFriend = value;
                OnPropertyChanged();
            }
        }
        private void OnOpenFriend(int friendId)
        {
            Load(friendId);
        }

        public void Load(int friendId)
        {
            CurrentFriend= _repository.GetFriend(friendId);
        }

    }
}
