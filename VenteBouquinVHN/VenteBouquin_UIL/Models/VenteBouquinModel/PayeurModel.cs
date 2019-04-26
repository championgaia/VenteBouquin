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
            CodePayeurM = payeur.CodePayeurDto;
            CodeUtilisateurM = payeur.CodeUtilisateurDto;
            PersonneM = new PersonneModel
            {
                CodePersonneM = payeur.PersonneDto.CodePersonneDto,
                NomM = payeur.PersonneDto.NomDto,
                PrenomM = payeur.PersonneDto.PrenomDto,
                DateNaissanceM = payeur.PersonneDto.DateNaissanceDto
            };
        }
        #endregion
        #region Constructeur par codePayeur
        public PayeurModel(int codePayeur)
        {
            var payeur = repo.GetPayeurDTORepoBol(codePayeur);
            CodePayeurM = payeur.CodePayeurDto;
            CodeUtilisateurM = payeur.CodeUtilisateurDto;
            PersonneM = new PersonneModel
            {
                CodePersonneM = payeur.PersonneDto.CodePersonneDto,
                NomM = payeur.PersonneDto.NomDto,
                PrenomM = payeur.PersonneDto.PrenomDto,
                DateNaissanceM = payeur.PersonneDto.DateNaissanceDto
            };
        }
        #endregion
        #region CreatePayeurModel
        public void CreatePayeurModel(PayeurModel payeurM)
        {
            var payeurDto = new PayeurDTO()
            {
                CodePayeurDto = payeurM.CodePayeurM,
                CodeUtilisateurDto = payeurM.CodeUtilisateurM,
                PersonneDto = new PersonneDTO()
                {
                    CodePersonneDto = payeurM.PersonneM.CodePersonneM,
                    NomDto = payeurM.PersonneM.NomM,
                    PrenomDto = payeurM.PersonneM.PrenomM,
                    DateNaissanceDto = payeurM.PersonneM.DateNaissanceM
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