using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class DescriptionBOL
    {
        public int CodeDescription { get; set; }
        public string CodeISBN { get; set; }
        public string Detail { get; set; }
    }
    internal class DescriptionBOLs
    {
        public List<DescriptionBOL> ListeDescription { get; set; }
        #region Constructeur par deffault
        public DescriptionBOLs()
        {

        }
        #endregion
        #region Constructeur
        public DescriptionBOLs(int codeDescription)
        {
            ListeDescription = new List<DescriptionBOL>();
            //besoin contexte
        }
        #endregion
    }
}
