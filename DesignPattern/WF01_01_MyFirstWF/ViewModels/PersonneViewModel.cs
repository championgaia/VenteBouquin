using ClassDto.ClassDTO;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WF01_01_MyFirstWF.Models;

namespace WF01_01_MyFirstWF.ViewModels
{
    public class PersonneViewModel
    {
        RepoData repo = new RepoData();
        public List<PersonneModel> ListPeople { get; set; }
        public PersonneViewModel()
        {
            ListPeople = new List<PersonneModel>();
            foreach (var personne in repo.GetAllPeople())
            {
                ListPeople.Add(new PersonneModel
                {
                    NomM = personne.NomDto,
                    PrenomM = personne.PrenomDto,
                    DateNaissanceM = personne.DateNaissanceDto
                });
            }
        }
        public void CreatePersonne(PersonneModel personneM)
        {
            repo.CreatePersonne(new PersonneDto
            {
                NomDto = personneM.NomM,
                PrenomDto = personneM.PrenomM,
                DateNaissanceDto = personneM.DateNaissanceM
            });
        }
    }
}