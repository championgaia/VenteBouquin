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
    
    public partial class Personne
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personne()
        {
            this.Utilisateurs = new HashSet<Utilisateur>();
        }
    
        public int IdPersonne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public System.DateTime DateNaissance { get; set; }
        public int FkAdresse { get; set; }
    
        public virtual Adresse Adresse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
