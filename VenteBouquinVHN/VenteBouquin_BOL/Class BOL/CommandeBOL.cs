using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class CommandeBOL
    {
        public int CodeCommande { get; set; }
        public double PrixTotal { get; set; }
        public PayeurBOL LePayeur { get; set; }
        public List<LigneDeCommandeBOL> LesLignes { get; set; }
        #region constructeur
        #region constructeur par deffaut
        public CommandeBOL() { }
        #endregion
        #region constructeur par codeCommande
        public CommandeBOL(int codeCommande)
        {
            RepoData repo = new RepoData();
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
    }
    internal class CommandeBOLs
    {
        public List<CommandeBOL> LesCommandes { get; set; }
        private RepoData repo = new RepoData();
        #region constructeur
        #region constructeur par deffaut
        public CommandeBOLs() {}
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
                    LePayeur = new PayeurBOLs(leCommande.LePayeurDto.CodePayeurDto).ListePayeur.FirstOrDefault(),
                    LesLignes = new LigneDeCommandeBOLs(leCommande.CodeCommandeDto).ListeLigneCommande
                });
            }
        }
        #endregion
        #endregion
    }
}
