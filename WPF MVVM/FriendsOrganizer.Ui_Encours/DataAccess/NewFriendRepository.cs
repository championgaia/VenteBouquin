using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public class NewFriendRepository : IFriendRepository
    {
        public List<Friend> GetFriends()
        {
            var context = new NorthWindContext();
            return context.Customers
                .Select(c => new Friend
                {
                    Id = c.CustomerID,
                    FirstName = c.ContactName,
                    LastName = c.CompanyName,
                    Email = c.PostalCode
                })
                .ToList();

        }
    }
}
