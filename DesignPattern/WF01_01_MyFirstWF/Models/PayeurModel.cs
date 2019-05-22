using ClassDto.ClassDTO;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WF01_01_MyFirstWF.Models
{
    public class PayeurModel
    {
        public int CodePayeurM { get; set; }
        public string CodeUtilisateurM { get; set; }
        public string LoginM { get; set; }
        public string PasswordM { get; set; }
        public string RoleM { get; set; }
        public PersonneModel PersonneM { get; set; }
        private RepoData repo = new RepoData();
        #region Constructeur par deffault
        public PayeurModel()
        {

        }
        #endregion
        #region Constructeur par codeUtilisateur
        public PayeurModel(string codeUtilisateur)
        {
            var payeur = repo.GetPeopleById(codeUtilisateur);
            if (payeur != null)
            {
                CodePayeurM = payeur.CodePayeurDto;
                CodeUtilisateurM = payeur.CodeUtilisateurDto;
                LoginM = payeur.LoginDto;
                PasswordM = payeur.PasswordDto;
                RoleM = payeur.RoleDto;
                PersonneM = new PersonneModel
                {
                    CodePersonneM = payeur.PersonneDto.CodePersonneDto,
                    NomM = payeur.PersonneDto.NomDto,
                    PrenomM = payeur.PersonneDto.PrenomDto,
                    DateNaissanceM = payeur.PersonneDto.DateNaissanceDto
                };
            }
        }
        #endregion
        #region Constructeur par codePayeur
        public PayeurModel(int codePayeur)
        {
            var payeur = repo.GetPeopleById(codePayeur);
            if (payeur != null)
            {
                CodePayeurM = payeur.CodePayeurDto;
                CodeUtilisateurM = payeur.CodeUtilisateurDto;
                LoginM = payeur.LoginDto;
                PasswordM = payeur.PasswordDto;
                RoleM = payeur.RoleDto;
                PersonneM = new PersonneModel
                {
                    CodePersonneM = payeur.PersonneDto.CodePersonneDto,
                    NomM = payeur.PersonneDto.NomDto,
                    PrenomM = payeur.PersonneDto.PrenomDto,
                    DateNaissanceM = payeur.PersonneDto.DateNaissanceDto
                };
            }
        }
        #endregion
    }
}