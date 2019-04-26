using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_BOL.Class_BOL;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL
{
    public class RepoBOL
    {
        private LivreCategoryBOLs livreCategories;
        private LivreBOLs livres;
        private PayeurBOLs payeurs;
        #region GetLivreCategoryDTOs
        public List<LivreCategoryDTO> GetLivreCategoryDTOsRepoBol(int codeCategory)
        {
            List<LivreCategoryDTO> livreCategoryDTOs = new List<LivreCategoryDTO>();
            livreCategories = new LivreCategoryBOLs(codeCategory);
            foreach (var item in livreCategories.ListeCategory)
            {
                livreCategoryDTOs.Add(new LivreCategoryDTO
                {
                    CodeCategoryDto = item.CodeCategory,
                    NomCategoryDto = item.NomCategory
                });
            }
            return livreCategoryDTOs;
        }
        #endregion
        #region GetLivreParCategoryDTORepoBol
        public List<LivreDTO> GetLivreParCategoryDTORepoBol(int codeCategory)
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreBOLs(codeCategory);
            foreach (var item in livres.ListeLivre)
            {
                listeLivreDTO.Add(new LivreDTO
                {
                    CodeISBNDto = item.CodeISBN,
                    NomLivreDto = item.NomLivre,
                    AuteurDto = item.Auteur,
                    EditeurDto = item.Editeur,
                    CoverImageDto = item.CoverImage,
                    PrixDto = item.Prix,
                    DescriptionDto = new DescriptionDTO
                    {
                        CodeDescriptionDto = item.Description.CodeDescription,
                        CodeISBNDto = item.Description.CodeISBN,
                        DetailDto = item.Description.Detail
                    },
                    LaCategoryDto = new LivreCategoryDTO
                    {
                        CodeCategoryDto = item.LaCategory.CodeCategory,
                        NomCategoryDto = item.LaCategory.NomCategory
                    }
                });
            }
            return listeLivreDTO;
        }
        #endregion
        #region GetLivreParCodeISBNDTORepoBol
        public List<LivreDTO> GetLivreParCodeISBNDTORepoBol(string codeISBN)
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreBOLs(codeISBN);
            foreach (var item in livres.ListeLivre)
            {
                listeLivreDTO.Add(new LivreDTO
                {
                    CodeISBNDto = item.CodeISBN,
                    NomLivreDto = item.NomLivre,
                    AuteurDto = item.Auteur,
                    EditeurDto = item.Editeur,
                    PrixDto = item.Prix,
                    DescriptionDto = new DescriptionDTO
                    {
                        CodeDescriptionDto = item.Description.CodeDescription,
                        CodeISBNDto = item.Description.CodeISBN,
                        DetailDto = item.Description.Detail
                    },
                    LaCategoryDto = new LivreCategoryDTO
                    {
                        CodeCategoryDto = item.LaCategory.CodeCategory,
                        NomCategoryDto = item.LaCategory.NomCategory
                    }
                });
            }
            return listeLivreDTO;
        }
        #endregion
        #region GetPayeurDTORepoBol
        public List<PayeurDTO> GetPayeurDTORepoBol(int codePayeur)
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            payeurs = new PayeurBOLs(codePayeur);
            foreach (var item in payeurs.ListePayeur)
            {
                monListePayeurDto.Add(new PayeurDTO()
                {
                    CodePayeurDto = item.CodePayeur,
                    CodeUtilisateurDto = item.CodeUtilisateur,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = item.Personne.CodePersonne,
                        NomDto = item.Personne.Nom,
                        PrenomDto = item.Personne.Prenom,
                        DateNaissanceDto = item.Personne.DateNaissance
                    }
                });
            }
            //manque liste d'adresse
            return null;
        }
        #endregion
        #region CreatePayeurRepoBol
        public void CreatePayeurRepoBol(PayeurDTO payeurDto)
        {
            var payeurBol = new PayeurBOL()
            {
                CodePayeur = payeurDto.CodePayeurDto,
                CodeUtilisateur = payeurDto.CodeUtilisateurDto,
                Personne = new PersonneBOL()
                {
                    CodePersonne = payeurDto.PersonneDto.CodePersonneDto,
                    Nom = payeurDto.PersonneDto.NomDto,
                    Prenom = payeurDto.PersonneDto.PrenomDto,
                    DateNaissance = payeurDto.PersonneDto.DateNaissanceDto
                }
            };
            payeurBol.CreatePayeurBol(payeurBol);
        }
        #endregion
        #region GetCommandeDTORepoBol
        #region GetCommandeDTORepoBol par codeCommande
        public CommandeDTO GetCommandeDTORepoBol(int codeCommande)
        {
            CommandeBOL commande = new CommandeBOL(codeCommande);
            CommandeDTO commandeDto = new CommandeDTO
            {
                CodeCommandeDto = commande.CodeCommande,
                PrixTotalDto = commande.PrixTotal,
                LePayeurDto = new PayeurDTO
                {
                    CodePayeurDto = commande.LePayeur.CodePayeur,
                    CodeUtilisateurDto = commande.LePayeur.CodeUtilisateur,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = commande.LePayeur.Personne.CodePersonne,
                        NomDto = commande.LePayeur.Personne.Nom,
                        PrenomDto = commande.LePayeur.Personne.Prenom,
                        DateNaissanceDto = commande.LePayeur.Personne.DateNaissance
                    }
                }
            };
            foreach (var ligneCommande in commande.LesLignes)
            {
                commandeDto.LesLignesDto.Add(new LigneDeCommandeDTO
                {
                    CodeLigneCommandeDto = ligneCommande.CodeLigneCommande,
                    QuantiteDto = ligneCommande.Quantite
                });
            }
            return commandeDto;
        }
        #endregion
        #region GetListCommandeDTORepoBol par codePayeur
        public List<CommandeDTO> GetListCommandeDTORepoBol(int codePayeur)
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            foreach (var commande in new CommandeBOLs(codePayeur).LesCommandes)
            {
                maListe.Add(new CommandeDTO
                {
                    CodeCommandeDto = commande.CodeCommande,
                    PrixTotalDto = commande.PrixTotal,
                    LePayeurDto = new PayeurDTO
                    {
                        CodePayeurDto = commande.LePayeur.CodePayeur,
                        CodeUtilisateurDto = commande.LePayeur.CodeUtilisateur,
                        PersonneDto = new PersonneDTO
                        {
                            CodePersonneDto = commande.LePayeur.Personne.CodePersonne,
                            NomDto = commande.LePayeur.Personne.Nom,
                            PrenomDto = commande.LePayeur.Personne.Prenom,
                            DateNaissanceDto = commande.LePayeur.Personne.DateNaissance
                        }
                    }
                });
            }
            return maListe;
        }
        #endregion
        #endregion
    }
}
