using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA.Class_DATA;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA
{
    public class RepoData
    {
        private LivreCategoryDatas livreCategoryDatas;
        private LivreDatas livres;
        private PayeurDatas payeurs;
        #region GetLivreCategoryDTOsRepoData
        public List<LivreCategoryDTO> GetLivreCategoryDTOsRepoData(int codeCategory)
        {
            List<LivreCategoryDTO> livreCategoryDTOs = new List<LivreCategoryDTO>();
            livreCategoryDatas = new LivreCategoryDatas(codeCategory);
            foreach (var item in livreCategoryDatas.ListeCategory)
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
        #region GetLivreParCategoryDTORepoData
        public List<LivreDTO> GetLivreParCategoryDTORepoData(int codeCategory)
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreDatas(codeCategory);
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
        #region GetLivreParCodeISBNDTORepoData
        public LivreDTO GetLivreParCodeISBNDTORepoData(string codeISBN)
        {
            var livre = new LivreDatas(codeISBN).ListeLivre.FirstOrDefault();
            var livreDTO = new LivreDTO
            {
                CodeISBNDto = livre.CodeISBN,
                NomLivreDto = livre.NomLivre,
                AuteurDto = livre.Auteur,
                EditeurDto = livre.Editeur,
                PrixDto = livre.Prix,
                DescriptionDto = new DescriptionDTO
                {
                    CodeDescriptionDto = livre.Description.CodeDescription,
                    CodeISBNDto = livre.Description.CodeISBN,
                    DetailDto = livre.Description.Detail
                },
                LaCategoryDto = new LivreCategoryDTO
                {
                    CodeCategoryDto = livre.LaCategory.CodeCategory,
                    NomCategoryDto = livre.LaCategory.NomCategory
                }
            };
            return livreDTO;
        }
        #endregion
        #region GetPayeurDTORepoData
        public List<PayeurDTO> GetPayeurDTORepoData(int codePayeur)
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            payeurs = new PayeurDatas(codePayeur);
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
        #region CreatePayeurRepoData
        public void CreatePayeurRepoData(PayeurDTO payeurDto)
        {
            var payeurdata = new PayeurData()
            {
                CodePayeur = payeurDto.CodePayeurDto,
                CodeUtilisateur = payeurDto.CodeUtilisateurDto,
                Personne = new PersonneData()
                {
                    CodePersonne = payeurDto.PersonneDto.CodePersonneDto,
                    Nom = payeurDto.PersonneDto.NomDto,
                    Prenom = payeurDto.PersonneDto.PrenomDto,
                    DateNaissance = payeurDto.PersonneDto.DateNaissanceDto
                }
            };
            payeurdata.CreatePayeurData(payeurdata);
        }
        #endregion
        #region GetCommandeDTORepoData
        #region GetCommandeDTORepoData par codeCommande
        public CommandeDTO GetCommandeDTORepoData(int codeCommande)
        {
            CommandeData commande = new CommandeData(codeCommande);
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
                    QuantiteDto = ligneCommande.Quantite,
                    LeLivreDto = new LivreDTO
                    {
                        CodeISBNDto = ligneCommande.LeLivre.CodeISBN,
                        NomLivreDto = ligneCommande.LeLivre.NomLivre,
                        AuteurDto = ligneCommande.LeLivre.Auteur,
                        EditeurDto = ligneCommande.LeLivre.Editeur,
                        PrixDto = ligneCommande.LeLivre.Prix,
                        DescriptionDto = new DescriptionDTO
                        {
                            CodeDescriptionDto = ligneCommande.LeLivre.Description.CodeDescription,
                            CodeISBNDto = ligneCommande.LeLivre.Description.CodeISBN,
                            DetailDto = ligneCommande.LeLivre.Description.Detail
                        }
                    }
                });
            }
            return commandeDto;
        }
        #endregion
        #region GetListCommandeDTORepoData par codePayeur
        public List<CommandeDTO> GetListCommandeDTORepoData(int codePayeur)
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            foreach (var commande in new CommandeDatas(codePayeur).LesCommandes)
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
