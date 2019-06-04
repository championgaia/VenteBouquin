using Data;
using Data2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WF01_01_MyFirstWF.Models
{
    public class LivreModel
    {
        public int CodeLivreM { get; set; }
        public string CodeISBNM { get; set; }
        public string NomLivreM { get; set; }
        public string AuteurM { get; set; }
        public string EditeurM { get; set; }
        public string CoverImageM { get; set; }
        public double PrixM { get; set; }
        public DescriptionModel DescriptionM { get; set; }
        public LivreCategoryModel LaCategoryM { get; set; }
        RepoData2 repo = new RepoData2();
        #region Constructeur par deffault
        public LivreModel() { }
        #endregion
        public LivreModel(string codeISBN)
        {
            var livre = repo.GetLivreByCodeISBN(codeISBN);
            CodeISBNM = codeISBN;
            CodeLivreM = livre.CodeLivreDto;
            NomLivreM = livre.NomLivreDto;
            AuteurM = livre.AuteurDto;
            EditeurM = livre.EditeurDto;
            CoverImageM = livre.CoverImageDto;
            LaCategoryM = new LivreCategoryModel
            {
                CodeCategoryM = livre.LaCategoryDto.CodeCategoryDto,
                NomCategoryM = livre.LaCategoryDto.NomCategoryDto
            };
            DescriptionM = new DescriptionModel
            {
                CodeDescriptionM = livre.DescriptionDto.CodeDescriptionDto,
                DetailM = livre.DescriptionDto.DetailDto
            };
        }
    }
}