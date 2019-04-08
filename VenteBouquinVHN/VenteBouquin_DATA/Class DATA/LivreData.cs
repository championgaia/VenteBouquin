﻿using System;
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
    }
    internal class LivreDatas
    {
        private VenteBouquinContext context = new VenteBouquinContext();
        public List<LivreData> ListeLivre { get; set; }
        #region Constructeur par deffault
        public LivreDatas()
        {

        }
        #endregion
        #region Constructeur par code ISBN
        public LivreDatas(string codeISBN)
        {
            ListeLivre = new List<LivreData>();
            //besoin contexte
            var listeLivreCodeISBN = context.Livres
                .Include("Description")
                .Select(c => c)
                .Distinct()
                .Where(c => c.CodeISBN == codeISBN)
                .ToList();
            foreach (var item in listeLivreCodeISBN)
            {
                ListeLivre.Add(new LivreData {
                    CodeISBN = item.CodeISBN,
                    NomLivre = item.NomLivre,
                    Auteur = item.Auteur,
                    Editeur = item.Editeur,
                    CoverImage = item.CoverImage,
                    Prix = (double)item.Prix,
                    Description = new DescriptionData {
                        CodeDescription = item.Description.IdDescription,
                        CodeISBN = item.Description.CodeISBN,
                        Detail =  item.Description.Detail },
                    LaCategory = new LivreCategoryDatas(item.FkLivreCategory).ListeCategory.FirstOrDefault()
                });
            }

        }
        #endregion
        #region Constructeur par codeCategory
        public LivreDatas(int codeCategory)
        {
            ListeLivre = new List<LivreData>();
            //besoin contexte
            var listeLivreAvecCodeCategory = context.Livres
                .Include("LivreCategory")
                .Include("Description")
                .Select(c => c)
                .Distinct()
                .Where(c => c.FkLivreCategory == codeCategory)
                .ToList();
            foreach (var item in listeLivreAvecCodeCategory)
            {
                ListeLivre.Add(new LivreData
                {
                    CodeISBN = item.CodeISBN,
                    NomLivre = item.NomLivre,
                    Auteur = item.Auteur,
                    Editeur = item.Editeur,
                    CoverImage = item.CoverImage,
                    Prix = (double)item.Prix,
                    Description = new DescriptionData
                    {
                        CodeDescription = item.Description.IdDescription,
                        CodeISBN = item.Description.CodeISBN,
                        Detail = item.Description.Detail
                    },
                    LaCategory = new LivreCategoryDatas(item.FkLivreCategory).ListeCategory.FirstOrDefault()
                });
            }
        }
        #endregion

    }
}
