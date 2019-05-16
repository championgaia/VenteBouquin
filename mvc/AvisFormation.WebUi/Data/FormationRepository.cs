using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FormationRepository
    {
        public List<Formation> GetFormations()
        {
            using (var context = new AfDbEntities())
            {
                return context.Formation.ToList();
            }
        }

        public Formation GetFormation(int idFormation)
        {
            using (var context = new AfDbEntities())
            {
                return context.Formation.Include("Avis").FirstOrDefault(f=>f.Id == idFormation);
            }
        }

        public Formation GetFormationByNomSeo(string nomSeo)
        {
            using (var context = new AfDbEntities())
            {
                return context.Formation.Include("Avis").FirstOrDefault(f => f.NomSeo == nomSeo);
            }
        }
    }
}
