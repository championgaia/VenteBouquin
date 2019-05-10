using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EntityFrameworkRepository : IFriendRepository
    {
        public Friend GetFriend(int friendId)
        {
            using (var context = new FriendOrganizerDbEntities())
            {
                return context.Friends.FirstOrDefault(f=>f.Id == friendId);
            }
        }

        public List<Friend> GetFriends()
        {
            using (var context = new FriendOrganizerDbEntities())
            {
               return context.Friends.ToList();
            }
        }
    }
}
