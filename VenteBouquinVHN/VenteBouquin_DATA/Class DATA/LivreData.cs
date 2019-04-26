using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class LivreData
    {
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
    internal class LivreDatas
    {
        private VenteBouquinContext context = new VenteBouquinContext();
        public List<LivreData> ListeLivre { get; set; }
        #region Constructeur par deffault
        public LivreDatas()
        {
            ListeLivre = new List<LivreData>();
            #region Version 2
            //version 2
            var liste2 = context.Livres
                .Distinct()
                .ToList();
            foreach (var livre in liste2)
            {
                ListeLivre.Add(new LivreData
                {
                    CodeISBN = livre.CodeISBN,
                    NomLivre = livre.NomLivre,
                    Auteur = livre.Auteur,
                    Editeur = livre.Editeur,
                    CoverImage = livre.CoverImage,
                    Prix = (double)livre.Prix,
                    Description = new DescriptionData
                    {
                        CodeDescription = livre.Description.IdDescription,
                        CodeISBN = livre.Description.CodeISBN,
                        Detail = livre.Description.Detail
                    },//modifier mettre dans la descritiondata
                    LaCategory = new LivreCategoryData
                    {
                        CodeCategory = livre.LivreCategory.IdCategory,
                        NomCategory = livre.LivreCategory.NomCategory
                    } // modifier mettre dans la categorydata
                });

            }
            #endregion
        }
        #endregion
        
        #region Constructeur par codeCategory
        public LivreDatas(int codeCategory)
        {
            ListeLivre = new List<LivreData>();
            #region version 2
            var liste2 = context.Livres
                .Where(c => c.FkLivreCategory == codeCategory)
                .ToList();
            foreach (var livre in liste2)
            {
                ListeLivre.Add(new LivreData
                {
                    CodeISBN = livre.CodeISBN,
                    NomLivre = livre.NomLivre,
                    Auteur = livre.Auteur,
                    Editeur = livre.Editeur,
                    CoverImage = livre.CoverImage,
                    Prix = (double)livre.Prix,
                    Description = new DescriptionData
                    {
                        CodeDescription = livre.Description.IdDescription,
                        CodeISBN = livre.Description.CodeISBN,
                        Detail = livre.Description.Detail
                    },
                    LaCategory = new LivreCategoryData
                    {
                        CodeCategory = livre.LivreCategory.IdCategory,
                        NomCategory = livre.LivreCategory.NomCategory
                    }
                });
            }
            #endregion
        }
        #endregion

    }
}
