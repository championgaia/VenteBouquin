using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class FriendDetailViewModel : IFriendDetailViewModel
    {
        IFriendRepository _repo { get; set; }
        public FriendDetailViewModel(IFriendRepository repo)
        {
            _repo = repo;
        }
        public Friend CurrentFriend { get; set; }
        public void Load(string idPersonne)
        {
            CurrentFriend = _repo.GetFriends().FirstOrDefault(c => c.Id == idPersonne);
        }
    }
}
