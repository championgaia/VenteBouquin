//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VenteBouquin_DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Livre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Livre()
        {
            this.LigneDeCommandes = new HashSet<LigneDeCommande>();
        }
    
        public int IdLivre { get; set; }
        public string CodeISBN { get; set; }
        public string NomLivre { get; set; }
        public string Auteur { get; set; }
        public string Editeur { get; set; }
        public string CoverImage { get; set; }
        public decimal Prix { get; set; }
        public Nullable<int> FkDescription { get; set; }
        public int FkLivreCategory { get; set; }
    
        public virtual Description Description { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneDeCommande> LigneDeCommandes { get; set; }
        public virtual LivreCategory LivreCategory { get; set; }
    }
}