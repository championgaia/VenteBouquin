using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_BOL;

namespace VenteBouquin_UIL.Models.VenteBouquinModel
{
    public class LivreModel
    {
        public string CodeISBNM { get; set; }
        public string NomLivreM { get; set; }
        public string AuteurM { get; set; }
        public string EditeurM { get; set; }
        public string CoverImageM { get; set; }
        public double PrixM { get; set; }
        public DescriptionModel DescriptionM { get; set; }
        public LivreCategoryModel LaCategoryM { get; set; }
        private RepoBOL repo = new RepoBOL();
        #region Constructeur par deffault
        public LivreModel() { }
        #endregion
        #region Constructeur par code ISBN
        public LivreModel(string codeISBN)
        {
            var livreDto = repo.GetLivreParCodeISBNDTORepoBol(codeISBN);
            CodeISBNM = livreDto.CodeISBNDto;
            NomLivreM = livreDto.NomLivreDto;
            AuteurM = livreDto.AuteurDto;
            EditeurM = livreDto.EditeurDto;
            CoverImageM = livreDto.CoverImageDto;
            PrixM = livreDto.PrixDto;
            DescriptionM = new DescriptionModel
            {
                CodeDescriptionM = livreDto.DescriptionDto.CodeDescriptionDto,
                CodeISBNM = livreDto.DescriptionDto.CodeISBNDto,
                DetailM = livreDto.DescriptionDto.DetailDto
            };
            LaCategoryM = new LivreCategoryModel
            {
                CodeCategoryM = livreDto.LaCategoryDto.CodeCategoryDto,
                NomCategoryM = livreDto.LaCategoryDto.NomCategoryDto
            };
        }
        #endregion
    }
    public class LivreModels
    {
        public List<LivreModel> ListeLivreM { get; set; }
        private RepoBOL repo = new RepoBOL();
        #region Constructeur par deffault
        public LivreModels()
        {
            ListeLivreM = new List<LivreModel>();
            //besoin repo
            foreach (var item in repo.GetAllLivreDTORepoData())
            {
                ListeLivreM.Add(new LivreModel
                {
                    CodeISBNM = item.CodeISBNDto,
                    NomLivreM = item.NomLivreDto,
                    AuteurM = item.AuteurDto,
                    EditeurM = item.EditeurDto,
                    CoverImageM = item.CoverImageDto,
                    PrixM = item.PrixDto,
                    DescriptionM = new DescriptionModel
                    {
                        CodeDescriptionM = item.DescriptionDto.CodeDescriptionDto,
                        CodeISBNM = item.DescriptionDto.CodeISBNDto,
                        DetailM = item.DescriptionDto.DetailDto
                    },
                    LaCategoryM = new LivreCategoryModel
                    {
                        CodeCategoryM = item.LaCategoryDto.CodeCategoryDto,
                        NomCategoryM = item.LaCategoryDto.NomCategoryDto
                    }

                });
            }
        }
        #endregion
        #region Constructeur par codeCategory
        public LivreModels(int codeCategory)
        {
            ListeLivreM = new List<LivreModel>();
            //besoin repo
            foreach (var item in repo.GetLivreParCategoryDTORepoBol(codeCategory))
            {
                ListeLivreM.Add(new LivreModel
                {
                    CodeISBNM = item.CodeISBNDto,
                    NomLivreM = item.NomLivreDto,
                    AuteurM = item.AuteurDto,
                    EditeurM = item.EditeurDto,
                    CoverImageM = item.CoverImageDto,
                    PrixM = item.PrixDto,
                    DescriptionM = new DescriptionModel
                    {
                        CodeDescriptionM = item.DescriptionDto.CodeDescriptionDto,
                        CodeISBNM = item.DescriptionDto.CodeISBNDto,
                        DetailM = item.DescriptionDto.DetailDto
                    },
                    LaCategoryM = new LivreCategoryModel
                    {
                        CodeCategoryM = item.LaCategoryDto.CodeCategoryDto,
                        NomCategoryM = item.LaCategoryDto.NomCategoryDto
                    }

                });
            }
        }
        #endregion
    }
}