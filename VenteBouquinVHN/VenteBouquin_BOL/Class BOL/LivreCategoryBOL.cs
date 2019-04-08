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
        #region constructeur par défault
        public LivreCategoryBOL()
        {

        }
        #endregion
    }
    internal class LivreCategoryBOLs
    {
        public List<LivreCategoryBOL> ListeCategory { get; set; }
        private RepoData repo = new RepoData();
        #region Constructeur par deffault
        public LivreCategoryBOLs()
        {

        }
        #endregion
        #region Constructeur
        public LivreCategoryBOLs(int codeCategory)
        {
            ListeCategory = new List<LivreCategoryBOL>();
            //besoin repo
            foreach (var item in repo.GetLivreCategoryDTOsRepoData(codeCategory))
            {
                ListeCategory.Add(new LivreCategoryBOL {
                    CodeCategory = item.CodeCategoryDto,
                    NomCategory = item.NomCategoryDto
                });
            }
        }
        #endregion
    }
}
