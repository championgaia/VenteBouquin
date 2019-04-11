using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf02_01_DataBinding
{
    public class Personne : INotifyPropertyChanged
    {
        private string _nom;
        private string _prenom;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Nom
        {
            get => _nom;
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    RaisePropertyChanged(nameof(Nom));
                }
            }
        }
        public string Prenom
        {
            get => _prenom;
            set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    RaisePropertyChanged(nameof(Prenom));
                }
            }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //equivalent
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}
        }
        public override string ToString()
        {
            return string.Format(_nom + _prenom);
        }
    }
}
