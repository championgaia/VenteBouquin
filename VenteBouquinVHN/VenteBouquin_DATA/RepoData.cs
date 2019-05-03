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
        #region GetLivreCategoryDTOsRepoData all category
        public List<LivreCategoryDTO> GetLivreCategoryDTOsRepoData()
        {
            List<LivreCategoryDTO> livreCategoryDTOs = new List<LivreCategoryDTO>();
            livreCategoryDatas = new LivreCategoryDatas();
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
        #region GetLivreCategoryDTOsRepoData par codeCategory
        public LivreCategoryDTO GetLivreCategoryDTOsRepoData(int codeCategory)
        {
            var livreCategoryData = new LivreCategoryData(codeCategory);
            LivreCategoryDTO livreCategoryDTO = new LivreCategoryDTO
            {

                CodeCategoryDto = livreCategoryData.CodeCategory,
                NomCategoryDto = livreCategoryData.NomCategory
            };
            return livreCategoryDTO;
        }
        #endregion
        #endregion
        #region Livre repoData
        #region GetAllLivreDTORepoData
        public List<LivreDTO> GetAllLivreDTORepoData()
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreDatas();
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
        #region GetLivreParCategoryDTORepoData
        public List<LivreDTO> GetLivreParCategoryDTORepoData(int codeCategory)
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreDatas(codeCategory);
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
        #region GetLivreParCodeISBNDTORepoData
        public LivreDTO GetLivreParCodeISBNDTORepoData(string codeISBN)
        {
            var livre = new LivreData(codeISBN);
            var livreDTO = new LivreDTO
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
            return livreDTO;
        }
        #endregion
        #endregion
        #region Payeur
        #region GetPayeurDTORepoData par codePayeur
        public PayeurDTO GetPayeurDTORepoData(int codePayeur)
        {
            var payeur = new PayeurData(codePayeur);
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
        #region GetPayeurDTORepoData par codeUtilisateur
        public PayeurDTO GetPayeurDTORepoData(string codeUtilisateur)
        {
            var payeur = new PayeurData(codeUtilisateur);
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
        #region GetAllPayeurDTORepoData
        public List<PayeurDTO> GetAllPayeurDTORepoData()
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            payeurs = new PayeurDatas();
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
        #region CreatePayeurRepoData
        public void CreatePayeurRepoData(PayeurDTO payeurDto)
        {
            var payeurdata = new PayeurData()
            {
                CodePayeur = payeurDto.CodePayeurDto,
                CodeUtilisateur = payeurDto.CodeUtilisateurDto,
                Login = payeurDto.LoginDto,
                Password = payeurDto.PasswordDto,
                Role = payeurDto.RoleDto,
                Personne = new PersonneData()
                {
                    CodePersonne = payeurDto.PersonneDto.CodePersonneDto,
                    Nom = payeurDto.PersonneDto.NomDto,
                    Prenom = payeurDto.PersonneDto.PrenomDto,
                    DateNaissance = payeurDto.PersonneDto.DateNaissanceDto
                }
            };
            payeurdata.CreatePayeurData();
        }
        #endregion
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
        #region GetAllCommandeDTORepoData
        public List<CommandeDTO> GetAllCommandeDTORepoData()
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            foreach (var commande in new CommandeDatas().LesCommandes)
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
        #region CreateCommande repoData
        public void CreateCommande(CommandeDTO commandeDto)
        {
            //a ajouter
            CommandeData commande = new CommandeData
            {
                CodeCommande = commandeDto.CodeCommandeDto,
                PrixTotal = commandeDto.PrixTotalDto,
                LePayeur = new PayeurData
                {
                    CodePayeur = commandeDto.LePayeurDto.CodePayeurDto,
                    CodeUtilisateur = commandeDto.LePayeurDto.CodeUtilisateurDto,
                    Personne = new PersonneData
                    {
                        CodePersonne = commandeDto.LePayeurDto.PersonneDto.CodePersonneDto,
                        Nom = commandeDto.LePayeurDto.PersonneDto.NomDto,
                        Prenom = commandeDto.LePayeurDto.PersonneDto.PrenomDto,
                        DateNaissance = commandeDto.LePayeurDto.PersonneDto.DateNaissanceDto
                    }
                }
            };
            //manque liste de ligne de commande
            commande.LesLignes = new List<LigneDeCommandeData>();
            foreach (var ligneCommande in commandeDto.LesLignesDto)
            {
                commande.LesLignes.Add(new LigneDeCommandeData
                {
                    Quantite = ligneCommande.QuantiteDto,

                    LeLivre = new LivreData
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
