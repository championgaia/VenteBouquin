using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class LivreBOL
    {
        public string CodeISBN { get; set; }
        public string NomLivre { get; set; }
        public string Auteur { get; set; }
        public string Editeur { get; set; }
        public string CoverImage { get; set; }
        public double Prix { get; set; }
        public DescriptionBOL Description { get; set; }
        public LivreCategoryBOL LaCategory { get; set; }
    }
    internal class LivreBOLs
    {
        public List<LivreBOL> ListeLivre { get; set; }
        private RepoData repo = new RepoData();
        #region Constructeur par deffault
        public LivreBOLs()
        {

        }
        #endregion
        #region Constructeur par code ISBN
        public LivreBOLs(string codeISBN)
        {
            ListeLivre = new List<LivreBOL>();
            //besoin repo
            foreach (var item in repo.GetLivreParCodeISBNDTORepoData(codeISBN))
            {
                ListeLivre.Add(new LivreBOL {
                    CodeISBN = item.CodeISBNDto,
                    NomLivre = item.NomLivreDto,
                    Auteur = item.AuteurDto,
                    Editeur = item.EditeurDto,
                    CoverImage = item.CoverImageDto,
                    Prix = item.PrixDto,
                    Description = new DescriptionBOL
                    {
                        CodeDescription = item.DescriptionDto.CodeDescriptionDto,
                        CodeISBN = item.DescriptionDto.CodeISBNDto,
                        Detail = item.DescriptionDto.DetailDto
                    },
                    LaCategory = new LivreCategoryBOL
                    {
                        CodeCategory = item.LaCategoryDto.CodeCategoryDto,
                        NomCategory = item.LaCategoryDto.NomCategoryDto
                    }
                    
                });
            }
        }
        #endregion
        #region Constructeur par codeCategory
        public LivreBOLs(int codeCategory)
        {
            ListeLivre = new List<LivreBOL>();
            //besoin repo
            foreach (var item in repo.GetLivreParCategoryDTORepoData(codeCategory))
            {
                ListeLivre.Add(new LivreBOL
                {
                    CodeISBN = item.CodeISBNDto,
                    NomLivre = item.NomLivreDto,
                    Auteur = item.AuteurDto,
                    Editeur = item.EditeurDto,
                    CoverImage = item.CoverImageDto,
                    Prix = item.PrixDto,
                    Description = new DescriptionBOL
                    {
                        CodeDescription = item.DescriptionDto.CodeDescriptionDto,
                        CodeISBN = item.DescriptionDto.CodeISBNDto,
                        Detail = item.DescriptionDto.DetailDto
                    },
                    LaCategory = new LivreCategoryBOL
                    {
                        CodeCategory = item.LaCategoryDto.CodeCategoryDto,
                        NomCategory = item.LaCategoryDto.NomCategoryDto
                    }

                });
            }
        }
        #endregion
    }
}
