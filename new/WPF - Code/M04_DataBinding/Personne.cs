using System.ComponentModel;

namespace M04_DataBinding
{
    // L'interface INotifyPropertyChanged est nécessaire
    //  pour que la classe de binding soit notifiée
    //  des changements
    public class Personne : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (prenom != value)
                {
                    prenom = value;
                    // nameof() renvoie le nom de l'élément pointé
                    RaisePropertyChanged(nameof(Prenom));
                }
            }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set
            {
                if (nom != value)
                {
                    nom = value;
                    RaisePropertyChanged(nameof(Nom));
                }
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            // On déclenche l'événement pour notifier les abonnés (uniquement s'il y en a)
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));

            /* Autre version équivalente
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));
            */
        }
    }
}
