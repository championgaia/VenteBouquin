using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class CommandeData
    {
        public int CodeCommande { get; set; }
        public double PrixTotal { get; set; }
        public PayeurData LePayeur { get; set; }
        public List<LigneDeCommandeData> LesLignes { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region constructeur
        #region constructeur par deffaut
        public CommandeData() { }
        #endregion
        #region constructeur par codeCommande
        public CommandeData(int codeCommande)
        {
            var leCommande = context.Commandes
                                .Where(c => c.IdCommande == codeCommande)
                                .ToList()
                                .FirstOrDefault();
            CodeCommande = leCommande.IdCommande;
            PrixTotal = (double)leCommande.PrixTotal;
            LePayeur = new PayeurData(leCommande.FkUtilisateur);
            LesLignes =  new List<LigneDeCommandeData>();
            foreach (var item in context.LigneDeCommandes
                                .Where(c => c.FkCommande == codeCommande)
                                .ToList())
            {
                LesLignes.Add(new LigneDeCommandeData(item.IdLigneDeCommande));
            }
        }
        #endregion
        #endregion
        #region CreateCommande Data
        public void CreateCommande()
        {
            var c = new Commande
            {
                PrixTotal = (decimal)PrixTotal,
                FkUtilisateur = LePayeur.CodePayeur
            };
            foreach (var item in LesLignes)
            {
                c.LigneDeCommandes.Add(new LigneDeCommande
                {
                    FkLivre = item.LeLivre.CodeLivre,
                    Quantite = item.Quantite,
                    FkPromotion = 1 //
                });
            }
            context.Commandes.Add(c);
            context.SaveChanges();
        }
        #endregion
    }
    internal class CommandeDatas
    {
        public List<CommandeData> LesCommandes { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region constructeur
        #region constructeur par deffaut
        public CommandeDatas() { }
        #endregion
        #region constructeur par codePayeur
        public CommandeDatas(int codePayeur)
        {
            var lesCommande = context.Commandes
                                .Where(c => c.FkUtilisateur == codePayeur)
                                .ToList();
            foreach (var leCommande in lesCommande)
            {
                LesCommandes.Add(new CommandeData
                {
                    CodeCommande = leCommande.IdCommande,
                    PrixTotal = (double)leCommande.PrixTotal,
                    LePayeur = new PayeurData(leCommande.FkUtilisateur),
                    LesLignes = new LigneDeCommandeDatas(leCommande.IdCommande).ListeLigneCommande
                });
            }
        }
        #endregion
        #endregion
    }
}
