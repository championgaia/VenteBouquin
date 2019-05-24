﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess
{
    public interface IFriendRepository
    {   
        List<Friend> GetFriends();
        Friend GetFriend(int friendId);
        void Save(Friend currentFriend);
    }
}