﻿using System;
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
        private VenteBouquinContext context = new VenteBouquinContext();
        #region constructeur par deffaut
        public LigneDeCommandeData()
        {

        }
        #endregion
        #region constructeur par codeCommande
        public LigneDeCommandeData(int codeLigneCommande)
        {
            var laLigne = context.LigneDeCommandes
                                .Where(c => c.IdLigneDeCommande == codeLigneCommande)
                                .ToList()
                                .FirstOrDefault();
            CodeLigneCommande = laLigne.IdLigneDeCommande;
            Quantite = laLigne.Quantite;
            LeLivre = new LivreData(laLigne.Livre.CodeISBN);
        }
        #endregion
    }
}
