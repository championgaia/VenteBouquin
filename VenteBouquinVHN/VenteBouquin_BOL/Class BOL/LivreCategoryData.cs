using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class LivreCategoryBOL
    {
        public int CodeCategory { get; set; }
        public string NomCategory { get; set; }
        #region constructeur par défault
        public LivreCategoryData()
        {

        }
        #endregion
    }
    internal class LivreCategoryBOLs
    {
        public List<LivreCategoryBOL> ListeCategory { get; set; }
        #region Constructeur par deffault
        public LivreCategoryBOLs()
        {

        }
        #endregion
        #region Constructeur
        public LivreCategoryBOLs(int codeCategory)
        {
            ListeCategory = new List<LivreCategoryBOL>();
            //besoin contexte
        }
        #endregion
    }
}
