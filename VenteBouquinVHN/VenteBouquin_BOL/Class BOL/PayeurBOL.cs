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
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public PersonneBOL Personne { get; set; }
        private RepoData repo = new RepoData();
        #region Constructeur par deffault
        public PayeurBOL() { }
        #endregion
        #region Constructeur par codePayeur
        public PayeurBOL(int codePayeur)
        {
            var payeur = repo.GetPayeurDTORepoData(codePayeur);
            if (payeur != null)
            {
                CodePayeur = payeur.CodePayeurDto;
                CodeUtilisateur = payeur.CodeUtilisateurDto;
                Login = payeur.LoginDto;
                Password = payeur.PasswordDto;
                Role = payeur.RoleDto;
                Personne = new PersonneBOL
                {
                    CodePersonne = payeur.PersonneDto.CodePersonneDto,
                    Nom = payeur.PersonneDto.NomDto,
                    Prenom = payeur.PersonneDto.PrenomDto,
                    DateNaissance = payeur.PersonneDto.DateNaissanceDto,
                };
            }
        }
        #endregion
        #region Constructeur par codeUtilisateur
        public PayeurBOL(string codeUtilisateur)
        {
            var payeur = repo.GetPayeurDTORepoData(codeUtilisateur);
            if (payeur != null)
            {
                CodePayeur = payeur.CodePayeurDto;
                CodeUtilisateur = payeur.CodeUtilisateurDto;
                Login = payeur.LoginDto;
                Password = payeur.PasswordDto;
                Role = payeur.RoleDto;
                Personne = new PersonneBOL
                {
                    CodePersonne = payeur.PersonneDto.CodePersonneDto,
                    Nom = payeur.PersonneDto.NomDto,
                    Prenom = payeur.PersonneDto.PrenomDto,
                    DateNaissance = payeur.PersonneDto.DateNaissanceDto,
                };
            }
        }
        #endregion
    }
}
