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
        public ObservableCollection<Friend> Friends { get; set; }/// <summary>
        /// ////////////////
        /// </summary>
        IEventAggregator _aggregator;
        IFriendRepository _repository;
        public ICommand SaveCommande { get; set; }
        public NavigationViewModel(IFriendRepository repository, IEventAggregator agg)
        {
            _repository = repository;
            _aggregator = agg;
            _aggregator.GetEvent<MajFriendDetailViewEvent>().Subscribe(OnUpdateFriendDetailView);
            SaveCommande = new DelegateCommand(OnSaveExecute, CanExecuteMethod);
            Load();
        }

        private bool CanExecuteMethod()
        {
            return true;
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
