using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
                return context.Friend.FirstOrDefault(f=>f.Id == friendId);
            }
        }

        public List<Friend> GetFriends()
        {
            using (var context = new FriendOrganizerDbEntities())
            {
               return context.Friend.ToList();
            }
        }

        public void Save(Friend f)
        {
            if (f!=null)
            {
                using (var context = new FriendOrganizerDbEntities())
                {
                    //var friendAModif = GetFriend(f.Id);
                    //friendAModif.FirstName = f.FirstName;
                    //friendAModif.LastName = f.LastName;

                    //friendAModif.Email = f.Email;
                    context.Friend.AddOrUpdate(f);
                    //context.Friend.Attach(f);
                    //context.Entry(f).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            
        }
    }
}
