using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class DescriptionData
    {
        public int CodeDescription { get; set; }
        public string CodeISBN { get; set; }
        public string Detail { get; set; }
    }
    internal class DescriptionDatas
    {
        public List<DescriptionData> ListeDescription { get; set; }
        #region Constructeur par deffault
        public DescriptionDatas()
        {

        }
        #endregion
        #region Constructeur
        public DescriptionDatas(int codeDescription)
        {
            ListeDescription = new List<DescriptionData>();
            //besoin contexte
        }
        #endregion
    }
}
