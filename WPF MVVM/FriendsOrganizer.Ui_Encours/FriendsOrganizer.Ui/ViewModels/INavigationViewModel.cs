using DataAccess;
using Model;
using System.Collections.Generic;

namespace FriendsOrganizer.Ui.ViewModels
{
    public interface INavigationViewModel
    {
        List<Friend> Friends { get; set; }
        IFriendRepository _repo { get; set; }
    }
}