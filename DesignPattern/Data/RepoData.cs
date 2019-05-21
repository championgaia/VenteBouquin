using ClassDto.ClassDTO;
using Data.ClassData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RepoData
    {
        PersonneData perso = new PersonneData();
        public List<PersonneDto> GetAllPeople()
        {
            return perso.GetAllPeople();
        }

        public void CreatePersonne(PersonneDto personneDto)
        {
            perso.CreatePersonne(personneDto);
        }
    }
}
