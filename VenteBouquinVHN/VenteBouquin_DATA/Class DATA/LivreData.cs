using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class LivreData
    {
        public string CodeISBN { get; set; }
        public string NomLivre { get; set; }
        public string Auteur { get; set; }
        public string Editeur { get; set; }
        public string CoverImage { get; set; }
        public double Prix { get; set; }
        public DescriptionData Description { get; set; }
        public LivreCategoryData LaCategory { get; set; }
    }
    internal class LivreDatas
    {
        public List<LivreData> ListeLivre { get; set; }
        #region Constructeur par deffault
        public LivreDatas()
        {

        }
        #endregion
        #region Constructeur
        public LivreDatas(int codeISBN)
        {
            ListeLivre = new List<LivreData>();
            //besoin contexte
        }
        #endregion
    }
}
