using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_BOL;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_UIL.Models.VenteBouquinModel
{
    public class PayeurModel
    {
        public int CodePayeurM { get; set; }
        public string CodeUtilisateurM { get; set; }
        public string LoginM { get; set; }
        public string PasswordM { get; set; }
        public string RoleM { get; set; }
        public PersonneModel PersonneM { get; set; }
        private RepoBOL repo = new RepoBOL();
        #region Constructeur par deffault
        public PayeurModel()
        {

        }
        #endregion
        #region Constructeur par codeUtilisateur
        public PayeurModel(string codeUtilisateur)
        {
            var payeur = repo.GetPayeurDTORepoBol(codeUtilisateur);
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
            var payeur = repo.GetPayeurDTORepoBol(codePayeur);
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
        #region CreatePayeurModel
        public void CreatePayeurModel()
        {
            var payeurDto = new PayeurDTO()
            {
                CodePayeurDto = CodePayeurM,
                CodeUtilisateurDto = CodeUtilisateurM,
                LoginDto = LoginM,
                PasswordDto = PasswordM,
                RoleDto = RoleM,
                PersonneDto = new PersonneDTO()
                {
                    CodePersonneDto = PersonneM.CodePersonneM,
                    NomDto = PersonneM.NomM,
                    PrenomDto = PersonneM.PrenomM,
                    DateNaissanceDto = PersonneM.DateNaissanceM
                }
            };
            repo.CreatePayeurRepoBol(payeurDto);
        }
        #endregion
    }
    public class PayeurModels
    {
        public List<PayeurModel> ListePayeur { get; set; }
        private RepoBOL repo = new RepoBOL();
        #region Constructeur par deffault
        public PayeurModels()
        {
            ListePayeur = new List<PayeurModel>();
            //besoin repodata
            foreach (var item in repo.GetAllPayeurDTORepoData())
            {
                ListePayeur.Add(new PayeurModel
                {
                    CodePayeurM = item.CodePayeurDto,
                    CodeUtilisateurM = item.CodeUtilisateurDto,
                    LoginM = item.LoginDto,
                    PasswordM = item.PasswordDto,
                    RoleM = item.RoleDto,
                    PersonneM = new PersonneModel
                    {
                        CodePersonneM = item.PersonneDto.CodePersonneDto,
                        NomM = item.PersonneDto.NomDto,
                        PrenomM = item.PersonneDto.PrenomDto,
                        DateNaissanceM = item.PersonneDto.DateNaissanceDto
                    }
                });
            }
        }
        #endregion
        
    }
}