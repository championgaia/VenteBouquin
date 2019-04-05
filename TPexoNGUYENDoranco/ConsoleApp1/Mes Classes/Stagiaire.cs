using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Mes_Classes
{
    public class Stagiaire : Personne
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Matiere { get; set; }
        public Stagiaire()
        {

        }
        public Stagiaire(string nom, string prenom, string adresse, bool emploi, DateTime dateDebut,
            DateTime dateFin, string matiere) : base (nom, prenom, adresse, emploi)
        {
            DateDebut = dateDebut; DateFin = dateFin; Matiere = matiere;
        }
        public TimeSpan DureeStage()
        {
            return DateFin - DateDebut;
        }
        public void Etudier(TimeSpan duree, string nomMatiere)
        {
            Console.WriteLine("fait le matière " + Matiere
                + " pendant " + DureeStage().TotalDays);
        }
        public void Afficher()
        {
            Console.WriteLine("Stagiaire " + Nom + " " + Prenom);
            Etudier(DureeStage(), Matiere);
        }
    }
}
