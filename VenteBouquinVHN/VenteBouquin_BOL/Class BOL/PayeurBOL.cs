using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class PayeurBOL
    {
        public int CodePayeur { get; set; }
        public string CodeUtilisateur { get; set; }
        public PersonneBOL Personne { get; set; }
    }
    internal class PayeurBOLs
    {
        public List<PayeurBOL> ListePayeur { get; set; }
        private RepoData repo = new RepoData();
        #region Constructeur par deffault
        public PayeurBOLs()
        {

        }
        #endregion
        #region Constructeur par codePayeur
        public PayeurBOLs(string codePayeur)
        {
            ListePayeur = new List<PayeurBOL>();
            //besoin repodata
            foreach (var item in repo.GetPayeurDTORepoData(codePayeur))
            {
                ListePayeur.Add(new PayeurBOL
                {
                    CodePayeur = item.CodePayeurDto,
                    CodeUtilisateur = item.CodeUtilisateurDto,
                    Personne = new PersonneBOL
                    {
                        CodePersonne = item.PersonneDto.CodePersonneDto,
                        Nom = item.PersonneDto.NomDto,
                        Prenom = item.PersonneDto.PrenomDto,
                        DateNaissance = item.PersonneDto.DateNaissanceDto
                    }
                });
            }
        }
        #endregion
    }
}
