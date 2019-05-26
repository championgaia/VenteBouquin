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
    }
}
