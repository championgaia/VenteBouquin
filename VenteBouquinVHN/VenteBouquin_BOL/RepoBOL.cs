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
        private LivreBOLs livres;
        #region GetLivreCategoryDTOs
        public List<LivreCategoryDTO> GetLivreCategoryDTOsRepoBol()
        {
            List<LivreCategoryDTO> livreCategoryDTOs = new List<LivreCategoryDTO>();
            var livreCategories = new LivreCategoryBOLs();
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
        #region Livre  RepoBOL
        #region GetAllLivreDTORepoData
        public List<LivreDTO> GetAllLivreDTORepoData()
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreBOLs();
            foreach (var item in livres.ListeLivre)
            {
                listeLivreDTO.Add(new LivreDTO
                {
                    CodeLivreDto = item.CodeLivre,
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
        #region GetLivreParCategoryDTORepoBol
        public List<LivreDTO> GetLivreParCategoryDTORepoBol(int codeCategory)
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreBOLs(codeCategory);
            foreach (var item in livres.ListeLivre)
            {
                listeLivreDTO.Add(new LivreDTO
                {
                    CodeLivreDto = item.CodeLivre,
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
        public LivreDTO GetLivreParCodeISBNDTORepoBol(string codeISBN)
        {
            var livre = new LivreBOL(codeISBN);
            var LivreDTO = new LivreDTO
            {
                CodeLivreDto = livre.CodeLivre,
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
            return LivreDTO;
        }
        #endregion
        #endregion
        #region Payeur  RepoBOL
        #region GetAllPayeurDTORepoData
        public List<PayeurDTO> GetAllPayeurDTORepoData()
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            var payeurs = new PayeurBOLs();
            foreach (var item in payeurs.ListePayeur)
            {
                monListePayeurDto.Add(new PayeurDTO()
                {
                    CodePayeurDto = item.CodePayeur,
                    CodeUtilisateurDto = item.CodeUtilisateur,
                    LoginDto = item.Login,
                    PasswordDto = item.Password,
                    RoleDto = item.Role,
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
            return monListePayeurDto;
        }
        #endregion
        #region GetPayeurDTORepoBol par codePayeur
        public PayeurDTO GetPayeurDTORepoBol(int codePayeur)
        {
            var payeur = new PayeurBOL(codePayeur);
            if (payeur.CodeUtilisateur != null)
            {
                PayeurDTO payeurDto = new PayeurDTO
                {
                    CodePayeurDto = payeur.CodePayeur,
                    CodeUtilisateurDto = payeur.CodeUtilisateur,
                    LoginDto = payeur.Login,
                    PasswordDto = payeur.Password,
                    RoleDto = payeur.Role,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = payeur.Personne.CodePersonne,
                        NomDto = payeur.Personne.Nom,
                        PrenomDto = payeur.Personne.Prenom,
                        DateNaissanceDto = payeur.Personne.DateNaissance
                    }
                };
                //manque liste d'adresse
                return payeurDto;
            }
            return null;
        }
        #endregion
        #region GetPayeurDTORepoBol par codeUtilisateur
        public PayeurDTO GetPayeurDTORepoBol(string codeUtilisateur)
        {
            var payeur = new PayeurBOL(codeUtilisateur);
            if (payeur.CodeUtilisateur != null)
            {
                PayeurDTO payeurDto = new PayeurDTO
                {
                    CodePayeurDto = payeur.CodePayeur,
                    CodeUtilisateurDto = payeur.CodeUtilisateur,
                    LoginDto = payeur.Login,
                    PasswordDto = payeur.Password,
                    RoleDto = payeur.Role,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = payeur.Personne.CodePersonne,
                        NomDto = payeur.Personne.Nom,
                        PrenomDto = payeur.Personne.Prenom,
                        DateNaissanceDto = payeur.Personne.DateNaissance
                    }
                };
                //manque liste d'adresse
                return payeurDto;
            }
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
                Login = payeurDto.LoginDto,
                Password = payeurDto.PasswordDto,
                Role = payeurDto.RoleDto,
                Personne = new PersonneBOL()
                {
                    CodePersonne = payeurDto.PersonneDto.CodePersonneDto,
                    Nom = payeurDto.PersonneDto.NomDto,
                    Prenom = payeurDto.PersonneDto.PrenomDto,
                    DateNaissance = payeurDto.PersonneDto.DateNaissanceDto
                }
            };
            payeurBol.CreatePayeurBol();
        }
        #endregion
        #endregion
        #region Commande RepoBOL
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
                    QuantiteDto = ligneCommande.Quantite,
                    LeLivreDto = new LivreDTO
                    {
                        CodeLivreDto = ligneCommande.LeLivre.CodeLivre,
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
        #region GetAllCommandeDTORepoData
        public List<CommandeDTO> GetAllCommandeDTORepoData()
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            foreach (var commande in new CommandeBOLs().LesCommandes)
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
        #region CreateCommande RepoBOL
        public void CreateCommande(CommandeDTO commandeDto)
        {
            //a ajouter
            CommandeBOL commande = new CommandeBOL
            {
                CodeCommande = commandeDto.CodeCommandeDto,
                PrixTotal = commandeDto.PrixTotalDto,
                LePayeur = new PayeurBOL
                {
                    CodePayeur = commandeDto.LePayeurDto.CodePayeurDto,
                    CodeUtilisateur = commandeDto.LePayeurDto.CodeUtilisateurDto,
                    Personne = new PersonneBOL
                    {
                        CodePersonne = commandeDto.LePayeurDto.PersonneDto.CodePersonneDto,
                        Nom = commandeDto.LePayeurDto.PersonneDto.NomDto,
                        Prenom = commandeDto.LePayeurDto.PersonneDto.PrenomDto,
                        DateNaissance = commandeDto.LePayeurDto.PersonneDto.DateNaissanceDto
                    }
                }
            };
            //manque liste de ligne de commande
            commande.LesLignes = new List<LigneDeCommandeBOL>();
            foreach (var ligneCommande in commandeDto.LesLignesDto)
            {
                commande.LesLignes.Add(new LigneDeCommandeBOL
                {
                    Quantite = ligneCommande.QuantiteDto,
                    LeLivre = new LivreBOL
                    {
                        CodeLivre = ligneCommande.LeLivreDto.CodeLivreDto,
                        CodeISBN = ligneCommande.LeLivreDto.CodeISBNDto
                    }
                });
            }
            commande.CreateCommande();
        }
        #endregion
        #endregion
    }
}
