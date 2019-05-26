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
        private VenteBouquinContext context = new VenteBouquinContext();
        #region constructeur par défault
        public LivreCategoryData()
        {

        }
        #endregion
        #region Constructeur par codeCategory
        public LivreCategoryData(int codeCategory)
        {
            var category = context.LivreCategories
                        .FirstOrDefault(c => c.IdCategory == codeCategory);
            CodeCategory = category.IdCategory;
            NomCategory = category.NomCategory;
        }
        #endregion
    }
}
