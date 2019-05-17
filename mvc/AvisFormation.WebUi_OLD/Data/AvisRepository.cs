using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AvisRepository
    {
        public void AddAvis(Avis a)
        {
            using (var context = new AfDbEntities())
            {
                context.Avis.Add(a);
                context.SaveChanges();
            }
        }
    }
}
