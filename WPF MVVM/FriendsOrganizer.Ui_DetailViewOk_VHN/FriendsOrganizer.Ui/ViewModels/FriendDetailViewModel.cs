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
        public ICommand SaveCommande { get; set; }
        public FriendDetailViewModel(IFriendRepository repo, IEventAggregator agg)
        {
            _repository = repo;
            _aggregator = agg;
            _aggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);
            SaveCommande = new DelegateCommand(OnSaveExecute, CanExecuteMethod);
        }
        private bool CanExecuteMethod()
        {
            return true;
        }
        private void OnSaveExecute()
        {
            _repository.Save(_currentFriend._model);
            _aggregator.GetEvent<MajFriendDetailViewEvent>().Publish();
        }
        public FriendWrapper CurrentFriend
        {
            get { return _currentFriend; }
            set {
                _currentFriend = value;
                OnPropertyChanged();
            }
        }
        private void OnOpenFriendDetailView(int friendId)
        {
            Load(friendId);
        }
        public void Load(int friendId)
        {
            CurrentFriend= new FriendWrapper(_repository.GetFriend(friendId));
        }
    }
}
