using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class LivreCategoryData
    {
        public int CodeCategory { get; set; }
        public string NomCategory { get; set; }
        #region constructeur par défault
        public LivreCategoryData()
        {

        }
        #endregion
    }
    internal class LivreCategoryDatas
    {
        private VenteBouquinContext context = new VenteBouquinContext();
        public List<LivreCategoryData> ListeCategory { get; set; }
        #region Constructeur par deffault
        public LivreCategoryDatas()
        {

        }
        #endregion
        #region Constructeur
        public LivreCategoryDatas(int codeCategory)
        {
            ListeCategory = new List<LivreCategoryData>();
            //besoin contexte
            var liste = context.LivreCategories
                        .Select(c => c)
                        .Distinct()
                        .Where(c=> c.IdCategory == codeCategory || codeCategory == 0)
                        .OrderBy(c => c.NomCategory)
                        .ToList();
            foreach (var item in liste)
            {
                ListeCategory.Add(new LivreCategoryData {
                    CodeCategory = item.IdCategory,
                    NomCategory = item.NomCategory
                });
            }
        }
        #endregion
    }
}
