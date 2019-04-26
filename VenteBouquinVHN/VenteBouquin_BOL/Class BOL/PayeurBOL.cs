using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class PayeurBOL
    {
        public int CodePayeur { get; set; }
        public string CodeUtilisateur { get; set; }
        public PersonneBOL Personne { get; set; }
        private RepoData repo = new RepoData();
        #region Constructeur par deffault
        public PayeurBOL() { }
        #endregion
        #region Constructeur par codePayeur
        public PayeurBOL(int codePayeur)
        {
            var payeur = repo.GetPayeurDTORepoData(codePayeur);
            CodePayeur = payeur.CodePayeurDto;
            CodeUtilisateur = payeur.CodeUtilisateurDto;
            Personne = new PersonneBOL
            {
                CodePersonne = payeur.PersonneDto.CodePersonneDto,
                Nom = payeur.PersonneDto.NomDto,
                Prenom = payeur.PersonneDto.PrenomDto,
                DateNaissance = payeur.PersonneDto.DateNaissanceDto,
            };
        }
        #endregion
        #region Constructeur par codeUtilisateur
        public PayeurBOL(string codeUtilisateur)
        {
            var payeur = repo.GetPayeurDTORepoData(codeUtilisateur);
            CodePayeur = payeur.CodePayeurDto;
            CodeUtilisateur = payeur.CodeUtilisateurDto;
            Personne = new PersonneBOL
            {
                CodePersonne = payeur.PersonneDto.CodePersonneDto,
                Nom = payeur.PersonneDto.NomDto,
                Prenom = payeur.PersonneDto.PrenomDto,
                DateNaissance = payeur.PersonneDto.DateNaissanceDto,
            };
        }
        #endregion
        #region CreatePayeurRepoBol
        public void CreatePayeurBol(PayeurBOL payeurBol)
        {
            var payeurDto = new PayeurDTO()
            {
                CodePayeurDto = payeurBol.CodePayeur,
                CodeUtilisateurDto = payeurBol.CodeUtilisateur,
                PersonneDto = new PersonneDTO()
                {
                    CodePersonneDto = payeurBol.Personne.CodePersonne,
                    NomDto = payeurBol.Personne.Nom,
                    PrenomDto = payeurBol.Personne.Prenom,
                    DateNaissanceDto = payeurBol.Personne.DateNaissance
                }
            };
            repo.CreatePayeurRepoData(payeurDto);
        }
        #endregion
    }
    internal class PayeurBOLs
    {
        public List<PayeurBOL> ListePayeur { get; set; }
        private RepoData repo = new RepoData();
        #region Constructeur par deffault
        public PayeurBOLs()
        {
            ListePayeur = new List<PayeurBOL>();
            //besoin repodata
            foreach (var item in repo.GetAllPayeurDTORepoData())
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
