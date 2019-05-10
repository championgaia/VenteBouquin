using DataAccess;
using FriendsOrganizer.Ui.Events;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class FriendDetailViewModel : ViewModelBase,IFriendDetailViewModel
    {
        FriendWrapper _currentFriend;
        IFriendRepository _repository { get; set; }
        IEventAggregator _aggregator;
        public FriendDetailViewModel(IFriendRepository repo, IEventAggregator agg)
        {
            _repository = repo;
            _aggregator = agg;
            _aggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriend);

            SaveCommand = new DelegateCommand(OnSaveExecute,OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private void OnSaveExecute()
        {
            _repository.Save(_currentFriend.Model);
            _aggregator.GetEvent<SaveFriendEvent>().Publish();
        }

        public ICommand SaveCommand { get; set; }
        public FriendWrapper CurrentFriend
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
            CurrentFriend= new FriendWrapper( _repository.GetFriend(friendId));
        }

    }
}
