using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class LigneDeCommandeData
    {
        public int CodeLigneCommande { get; set; }
        public int Quantite { get; set; }
        public CommandeData LaCommande { get; set; }
        public LivreData LeLivre { get; set; }
        public PromotionData LaPromo { get; set; }
        #region constructeur par deffaut
        public LigneDeCommandeData()
        {

        }
        #endregion
        #region constructeur par codeCommande
        public LigneDeCommandeData(int codeLigneCommande)
        {
            VenteBouquinContext context = new VenteBouquinContext();
            var laLigne = context.LigneDeCommandes
                                .Where(c => c.IdLigneDeCommande == codeLigneCommande)
                                .ToList()
                                .FirstOrDefault();
            CodeLigneCommande = laLigne.IdLigneDeCommande;
            Quantite = laLigne.Quantite;
            LeLivre = new LivreDatas(laLigne.Livre.CodeISBN).ListeLivre.FirstOrDefault();
        }
        #endregion
    }
    internal class LigneDeCommandeDatas
    {
        public List<LigneDeCommandeData> ListeLigneCommande { get; set; }
        #region constructeur par deffaut
        public LigneDeCommandeDatas() { }
        #endregion
        #region constructeur par codeCommande
        public LigneDeCommandeDatas(int codeCommande)
        {
            ListeLigneCommande = new CommandeData(codeCommande).LesLignes;
        }
        #endregion
    }
}
