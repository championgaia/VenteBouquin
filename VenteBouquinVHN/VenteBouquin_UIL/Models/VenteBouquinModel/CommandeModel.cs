using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_BOL;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_UIL.Models.VenteBouquinModel
{
    public class CommandeModel
    {
        public int CodeCommandeM { get; set; }
        public double PrixTotalM { get; set; }
        public PayeurModel LePayeurM { get; set; }
        public List<LigneDeCommandeModel> LesLignesM { get; set; }
        private RepoBOL repo = new RepoBOL();
        #region constructeur
        #region constructeur par deffaut
        public CommandeModel() { }
        #endregion
        #region constructeur par codeCommande
        public CommandeModel(int codeCommande)
        {
            var leCommande = repo.GetCommandeDTORepoBol(codeCommande);
            CodeCommandeM = leCommande.CodeCommandeDto;
            PrixTotalM = leCommande.PrixTotalDto;
            LePayeurM = new PayeurModel
            {
                CodePayeurM = leCommande.LePayeurDto.CodePayeurDto,
                CodeUtilisateurM = leCommande.LePayeurDto.CodeUtilisateurDto,
                PersonneM = new PersonneModel
                {
                    CodePersonneM = leCommande.LePayeurDto.PersonneDto.CodePersonneDto,
                    NomM = leCommande.LePayeurDto.PersonneDto.NomDto,
                    PrenomM = leCommande.LePayeurDto.PersonneDto.PrenomDto,
                    DateNaissanceM = leCommande.LePayeurDto.PersonneDto.DateNaissanceDto
                }
            };
            LesLignesM = new List<LigneDeCommandeModel>();
            foreach (var ligneCommande in leCommande.LesLignesDto)
            {
                LesLignesM.Add(new LigneDeCommandeModel
                {
                    CodeLigneCommandeM = ligneCommande.CodeLigneCommandeDto,
                    QuantiteM = ligneCommande.QuantiteDto,
                    LeLivreM = new LivreModel(ligneCommande.LeLivreDto.CodeISBNDto)
                });
            }
        }
        #endregion
        #endregion
        #region CreateCommande CommandeModel
        public void CreateCommande()
        {
            CommandeDTO commandeDto = new CommandeDTO
            {
                CodeCommandeDto = CodeCommandeM,
                PrixTotalDto = PrixTotalM,
                LePayeurDto = new PayeurDTO
                {
                    CodePayeurDto = LePayeurM.CodePayeurM,
                    CodeUtilisateurDto = LePayeurM.CodeUtilisateurM,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = LePayeurM.PersonneM.CodePersonneM,
                        NomDto = LePayeurM.PersonneM.NomM,
                        PrenomDto = LePayeurM.PersonneM.PrenomM,
                        DateNaissanceDto = LePayeurM.PersonneM.DateNaissanceM
                    }
                }
            };
            //manque liste de ligne de commande
            commandeDto.LesLignesDto = new List<LigneDeCommandeDTO>();
            foreach (var ligneCommande in LesLignesM)
            {
                commandeDto.LesLignesDto.Add(new LigneDeCommandeDTO
                {
                    QuantiteDto = ligneCommande.QuantiteM,
                    LeLivreDto = new LivreDTO
                    {
                        CodeLivreDto = ligneCommande.LeLivreM.CodeLivreM,
                        CodeISBNDto = ligneCommande.LeLivreM.CodeISBNM
                    }
                });
            }
            repo.CreateCommande(commandeDto);
        }
        #endregion
    }
    public class CommandeModels
    {
        public List<CommandeModel> LesCommandes { get; set; }
        private RepoBOL repo = new RepoBOL();
        #region constructeur
        #region constructeur par deffaut
        public CommandeModels()
        {
            var lesCommande = repo.GetAllCommandeDTORepoData();
            foreach (var leCommande in lesCommande)
            {
                LesCommandes.Add(new CommandeModel
                {
                    CodeCommandeM = leCommande.CodeCommandeDto,
                    PrixTotalM = leCommande.PrixTotalDto,
                    LePayeurM = new PayeurModel(leCommande.LePayeurDto.CodePayeurDto),
                    LesLignesM = new LigneDeCommandeModels(leCommande.CodeCommandeDto).ListeLigneCommande
                });
            }
        }
        #endregion
        #region constructeur par codePayeur
        public CommandeModels(int codePayeur)
        {
            var lesCommande = repo.GetListCommandeDTORepoBol(codePayeur);
            foreach (var leCommande in lesCommande)
            {
                LesCommandes.Add(new CommandeModel
                {
                    CodeCommandeM = leCommande.CodeCommandeDto,
                    PrixTotalM = leCommande.PrixTotalDto,
                    LePayeurM = new PayeurModel(leCommande.LePayeurDto.CodePayeurDto),
                    LesLignesM = new LigneDeCommandeModels(leCommande.CodeCommandeDto).ListeLigneCommande
                });
            }
        }
        #endregion
        #endregion
    }
}