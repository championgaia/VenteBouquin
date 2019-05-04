using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA.Class_Control_DATA
{
    internal class GestionCommandeData
    {
        private VenteBouquinContext context = new VenteBouquinContext();
        #region GetCommandeDTO par codeCommande     GestionCommandeData
        public CommandeDTO GetCommandeDTO(int codeCommande)
        {
            var commande = context.Commandes
                                .FirstOrDefault(c => c.IdCommande == codeCommande);
            CommandeDTO commandeDto = new CommandeDTO
            {
                CodeCommandeDto = commande.IdCommande,
                PrixTotalDto = (double)commande.PrixTotal,
                LePayeurDto = new PayeurDTO
                {
                    CodePayeurDto = commande.Utilisateur.IdUtilisateur,
                    CodeUtilisateurDto = commande.Utilisateur.CodeUtilisateur,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = commande.Utilisateur.Personne.IdPersonne,
                        NomDto = commande.Utilisateur.Personne.Nom,
                        PrenomDto = commande.Utilisateur.Personne.Prenom,
                        DateNaissanceDto = commande.Utilisateur.Personne.DateNaissance
                    }
                }
            };
            foreach (var ligneCommande in commande.LigneDeCommandes)
            {
                commandeDto.LesLignesDto.Add(new LigneDeCommandeDTO
                {
                    CodeLigneCommandeDto = ligneCommande.IdLigneDeCommande,
                    QuantiteDto = ligneCommande.Quantite,
                    LeLivreDto = new LivreDTO
                    {
                        CodeLivreDto = ligneCommande.Livre.IdLivre,
                        CodeISBNDto = ligneCommande.Livre.CodeISBN,
                        NomLivreDto = ligneCommande.Livre.NomLivre,
                        AuteurDto = ligneCommande.Livre.Auteur,
                        EditeurDto = ligneCommande.Livre.Editeur,
                        PrixDto = (double)ligneCommande.Livre.Prix,
                        DescriptionDto = new DescriptionDTO
                        {
                            CodeDescriptionDto = ligneCommande.Livre.Description.IdDescription,
                            CodeISBNDto = ligneCommande.Livre.Description.CodeISBN,
                            DetailDto = ligneCommande.Livre.Description.Detail
                        }
                    }
                });
            }
            return commandeDto;
        }
        #endregion
        #region GetListCommandeDTO par codePayeur
        public List<CommandeDTO> GetListCommandeDTO(int codePayeur)
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            foreach (var commande in context.Commandes
                                .Where(c => c.FkUtilisateur == codePayeur)
                                .ToList())
            {
                maListe.Add(GetCommandeDTO(commande.IdCommande));
            }
            return maListe;
        }
        #endregion
        #region GetAllCommandeDTO       GestionCommandeData
        public List<CommandeDTO> GetAllCommandeDTO()
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            foreach (var commande in context.Commandes.ToList())
            {
                maListe.Add(GetCommandeDTO(commande.IdCommande));
            }
            return maListe;
        }
        #endregion
        #region CreateCommande     GestionCommandeData
        public void CreateCommande(CommandeDTO commandeDto)
        {
            Commande commande = new Commande
            {
                IdCommande = commandeDto.CodeCommandeDto,
                PrixTotal = (decimal)commandeDto.PrixTotalDto,
                Utilisateur = new Utilisateur
                {
                    IdUtilisateur = commandeDto.LePayeurDto.CodePayeurDto,
                    CodeUtilisateur = commandeDto.LePayeurDto.CodeUtilisateurDto,
                    Personne = new Personne
                    {
                        IdPersonne = commandeDto.LePayeurDto.PersonneDto.CodePersonneDto,
                        Nom = commandeDto.LePayeurDto.PersonneDto.NomDto,
                        Prenom = commandeDto.LePayeurDto.PersonneDto.PrenomDto,
                        DateNaissance = commandeDto.LePayeurDto.PersonneDto.DateNaissanceDto
                    }
                }
            };
            foreach (var ligneCommande in commandeDto.LesLignesDto)
            {
                commande.LigneDeCommandes.Add(new LigneDeCommande
                {
                    Quantite = ligneCommande.QuantiteDto,
                    Livre = new Livre
                    {
                        IdLivre = ligneCommande.LeLivreDto.CodeLivreDto,
                        CodeISBN = ligneCommande.LeLivreDto.CodeISBNDto
                    }
                });
            }
            context.Commandes.AddOrUpdate(commande);
            context.SaveChanges();
        }
        #endregion
    }
}
