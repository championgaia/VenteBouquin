using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #region Constructeur par deffault
        public LivreBOLs()
        {

        }
        #endregion
        #region Constructeur
        public LivreBOLs(int codeISBN)
        {
            ListeLivre = new List<LivreBOL>();
            //besoin contexte
        }
        #endregion
    }
}
