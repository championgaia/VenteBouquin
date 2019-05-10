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
    public class NavigationViewModel : INavigationViewModel
    {
        public List<Friend> Friends { get; set; }

        IEventAggregator _aggregator;
        IFriendRepository _repository;
        public NavigationViewModel(IFriendRepository repository, IEventAggregator agg)
        {
            _repository = repository;
            Friends = _repository.GetFriends();
            _aggregator = agg;
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
