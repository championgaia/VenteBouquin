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
                                .FirstOrDefault(c => c.IdCommande == codeCommande);
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
    }
}
