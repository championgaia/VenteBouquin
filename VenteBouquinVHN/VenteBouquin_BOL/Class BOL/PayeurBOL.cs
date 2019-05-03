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
        #region CreatePayeurRepoBol
        public void CreatePayeurBol()
        {
            var payeurDto = new PayeurDTO()
            {
                CodePayeurDto = CodePayeur,
                CodeUtilisateurDto = CodeUtilisateur,
                LoginDto = Login,
                PasswordDto = Password,
                RoleDto = Role,
                PersonneDto = new PersonneDTO()
                {
                    CodePersonneDto = Personne.CodePersonne,
                    NomDto = Personne.Nom,
                    PrenomDto = Personne.Prenom,
                    DateNaissanceDto = Personne.DateNaissance
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
                    Login = item.LoginDto,
                    Password = item.PasswordDto,
                    Role = item.RoleDto,
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
