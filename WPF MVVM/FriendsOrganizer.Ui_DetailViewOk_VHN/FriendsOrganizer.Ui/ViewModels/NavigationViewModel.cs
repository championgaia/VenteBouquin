using DataAccess;
using FriendsOrganizer.Ui.Events;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private ObservableCollection<Friend> _Friends;
        public ObservableCollection<Friend> Friends
        { get { return _Friends; }
            set
            {
                _Friends = value;
                OnPropertyChanged();
            }
        }
        IEventAggregator _aggregator;
        IFriendRepository _repository;
        public ICommand SaveCommande { get; set; }
        public ICommand DeleteCommande { get; set; } //a Faire
        public ICommand InsertCommande { get; set; } // a faire
        public NavigationViewModel(IFriendRepository repository, IEventAggregator agg)
        {
            _repository = repository;
            _aggregator = agg;
            //a ajouter
            if (1==2)
            {
                _aggregator.GetEvent<MajFriendDetailViewEvent>().Subscribe(OnUpdateFriendDetailView);
                SaveCommande = new DelegateCommand(OnSaveExecute, CanExecuteMethod);
            }
            else if (2==2)
            {
                _aggregator.GetEvent<DeleteFriendDetailViewEvent>().Subscribe(OnUpdateFriendDetailView);
                SaveCommande = new DelegateCommand(OnDeleteExecute, CanExecuteMethod);
            }
            else
            {
                _aggregator.GetEvent<NewFriendDetailViewEvent>().Subscribe(OnUpdateFriendDetailView);
                SaveCommande = new DelegateCommand(OnNewExecute, CanExecuteMethod);
            }
            Load();
        }
        private bool CanExecuteMethod()
        {
            return true;
        }
        private void OnNewExecute()
        {
            _repository.Ajouter(_friend);
        }

        private void OnDeleteExecute()
        {
            _repository.Delete(_friend);
        }
        private void OnSaveExecute()
        {
            _repository.Save(_friend);
        }

        private Friend _friend;
        public void Load()
        {
            Friends = new ObservableCollection<Friend>(_repository.GetFriends());
        }
        private void OnUpdateFriendDetailView()
        {
            Load();
        }
        public Friend SelectedFriend
        {
            get { return _friend; }
            set
            {
                _friend = value;
                if (_friend != null)
                {
                    _aggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(_friend.Id);
                }
            }
        }
    }
}
