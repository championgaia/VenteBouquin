using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class LivreData //manque CodeBouquin
    {
        public int CodeLivre { get; set; }
        public string CodeISBN { get; set; }
        public string NomLivre { get; set; }
        public string Auteur { get; set; }
        public string Editeur { get; set; }
        public string CoverImage { get; set; }
        public double Prix { get; set; }
        public DescriptionData Description { get; set; }
        public LivreCategoryData LaCategory { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region Constructeur par deffault
        public LivreData(){ }
        #endregion
        #region Constructeur par code ISBN
        public LivreData(string codeISBN)
        {
            #region Version 2
            //version 2
            var livre = context.Livres
                .Where(c => c.CodeISBN == codeISBN)
                .ToList().FirstOrDefault();
            CodeLivre = livre.IdLivre;
            CodeISBN = livre.CodeISBN;
            NomLivre = livre.NomLivre;
            Auteur = livre.Auteur;
            Editeur = livre.Editeur;
            CoverImage = livre.CoverImage;
            Prix = (double)livre.Prix;
            Description = new DescriptionData
            {
                CodeDescription = livre.Description.IdDescription,
                CodeISBN = livre.Description.CodeISBN,
                Detail = livre.Description.Detail
            };//modifier mettre dans la descritiondata
            LaCategory = new LivreCategoryData
            {
                CodeCategory = livre.LivreCategory.IdCategory,
                NomCategory = livre.LivreCategory.NomCategory
            }; // modifier mettre dans la categorydata
            #endregion
        }
        #endregion
    }
}
