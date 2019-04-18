namespace Exo_Morpion.Classes
{
    public class Joueur
    {
        public Joueur(int ordre, string nom, string symbole)
        {
            this.Ordre = ordre;
            this.Nom = nom;
            this.Symbole = symbole;
        }

        public int Ordre { get; }

        public string Symbole { get; }

        public string Nom { get; set; }

        public int NombrePartiesGagnees { get; set; }

        public int NombrePartiesPerdues { get; set; }

        public void JouerCase(Case casePlateau)
        {
            casePlateau.JoueePar = this;
        }
    }
}
