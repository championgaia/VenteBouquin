using ClassDto.ClassDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ClassData
{
    class PersonneData
    {
        private VenteBouquinContext context = new VenteBouquinContext();
        public List<PersonneDto> GetAllPeople()
        {
            List<PersonneDto> maListPeople = new List<PersonneDto>();
            foreach (var personne in context.Personnes)
            {
                maListPeople.Add(new PersonneDto
                {
                    NomDto = personne.Nom,
                    PrenomDto = personne.Prenom,
                    DateNaissanceDto = personne.DateNaissance.ToShortDateString()
                });
            }
            return maListPeople;
        }
    }
}
