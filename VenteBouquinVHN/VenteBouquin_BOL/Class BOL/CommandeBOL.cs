using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class CommandeBOL
    {
        public int CodeCommande { get; set; }
        public double PrixTotal { get; set; }
        public PayeurBOL LePayeur { get; set; }
        public List<LigneDeCommandeBOL> LesLignes { get; set; }
        private RepoData repo = new RepoData();
        #region constructeur
        #region constructeur par deffaut
        public CommandeBOL() { }
        #endregion
        #region constructeur par codeCommande
        public CommandeBOL(int codeCommande)
        {
            var leCommande = repo.GetCommandeDTORepoData(codeCommande);
            CodeCommande = leCommande.CodeCommandeDto;
            PrixTotal = leCommande.PrixTotalDto;
            LePayeur = new PayeurBOL
            {
                CodePayeur = leCommande.LePayeurDto.CodePayeurDto,
                CodeUtilisateur = leCommande.LePayeurDto.CodeUtilisateurDto,
                Personne = new PersonneBOL
                {
                    CodePersonne = leCommande.LePayeurDto.PersonneDto.CodePersonneDto,
                    Nom = leCommande.LePayeurDto.PersonneDto.NomDto,
                    Prenom = leCommande.LePayeurDto.PersonneDto.PrenomDto,
                    DateNaissance = leCommande.LePayeurDto.PersonneDto.DateNaissanceDto
                }
            };
            LesLignes = new List<LigneDeCommandeBOL>();
            foreach (var ligneCommande in leCommande.LesLignesDto)
            {
                LesLignes.Add(new LigneDeCommandeBOL
                {
                    CodeLigneCommande = ligneCommande.CodeLigneCommandeDto,
                    Quantite = ligneCommande.QuantiteDto,
                    LeLivre = new LivreBOL(ligneCommande.LeLivreDto.CodeISBNDto)
                });
            }
        }
        #endregion
        #endregion
        #region CreateCommande BOL
        public void CreateCommande()
        {
            CommandeDTO commandeDto = new CommandeDTO
            {
                CodeCommandeDto = CodeCommande,
                PrixTotalDto = PrixTotal,
                LePayeurDto = new PayeurDTO
                {
                    CodePayeurDto = LePayeur.CodePayeur,
                    CodeUtilisateurDto = LePayeur.CodeUtilisateur,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = LePayeur.Personne.CodePersonne,
                        NomDto = LePayeur.Personne.Nom,
                        PrenomDto = LePayeur.Personne.Prenom,
                        DateNaissanceDto = LePayeur.Personne.DateNaissance
                    }
                }
            };
            //manque liste de ligne de commande
            commandeDto.LesLignesDto = new List<LigneDeCommandeDTO>();
            foreach (var ligneCommande in LesLignes)
            {
                commandeDto.LesLignesDto.Add(new LigneDeCommandeDTO
                {
                    QuantiteDto = ligneCommande.Quantite,
                    LeLivreDto = new LivreDTO
                    {
                        CodeLivreDto = ligneCommande.LeLivre.CodeLivre,
                        CodeISBNDto = ligneCommande.LeLivre.CodeISBN
                    }
                });
            }
            repo.CreateCommande(commandeDto);
        }
        #endregion
    }
    internal class CommandeBOLs
    {
        public List<CommandeBOL> LesCommandes { get; set; }
        private RepoData repo = new RepoData();
        #region constructeur
        #region constructeur par deffaut
        public CommandeBOLs()
        {
            var lesCommande = repo.GetAllCommandeDTORepoData();
            foreach (var leCommande in lesCommande)
            {
                LesCommandes.Add(new CommandeBOL
                {
                    CodeCommande = leCommande.CodeCommandeDto,
                    PrixTotal = leCommande.PrixTotalDto,
                    LePayeur = new PayeurBOL(leCommande.LePayeurDto.CodePayeurDto),
                    LesLignes = new LigneDeCommandeBOLs(leCommande.CodeCommandeDto).ListeLigneCommande
                });
            }
        }
        #endregion
        #region constructeur par codePayeur
        public CommandeBOLs(int codePayeur)
        {
            var lesCommande = repo.GetListCommandeDTORepoData(codePayeur);
            foreach (var leCommande in lesCommande)
            {
                LesCommandes.Add(new CommandeBOL
                {
                    CodeCommande = leCommande.CodeCommandeDto,
                    PrixTotal = leCommande.PrixTotalDto,
                    LePayeur = new PayeurBOL(leCommande.LePayeurDto.CodePayeurDto),
                    LesLignes = new LigneDeCommandeBOLs(leCommande.CodeCommandeDto).ListeLigneCommande
                });
            }
        }
        #endregion
        #endregion
    }
}
