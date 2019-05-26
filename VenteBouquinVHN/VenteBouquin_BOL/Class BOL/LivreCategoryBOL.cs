using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class LivreCategoryBOL
    {
        public int CodeCategory { get; set; }
        public string NomCategory { get; set; }
        private RepoData repo = new RepoData();
        #region constructeur par défault
        public LivreCategoryBOL()
        {

        }
        #endregion
        #region Constructeur
        public LivreCategoryBOL(int codeCategory)
        {
            var category = repo.GetLivreCategoryDTOsRepoData(codeCategory);
            CodeCategory = category.CodeCategoryDto;
            NomCategory = category.NomCategoryDto;
        }
        #endregion
    }
}
