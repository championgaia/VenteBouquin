using JeuDeMotData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeMotBOL.ClassBol
{
    internal class JeuDeMotBol
    {
        public string MonMot { get; set; }
        public string LeMotADisplay { get; set; }
        private RepoData repo = new RepoData();
        public JeuDeMotBol()
        {
            MonMot = repo.GetWord();
            LeMotADisplay = string.Concat(MonMot.Select(c => "*"));
        }
        public string MakeChoise(char maLettre)
        {
            if (MonMot.Where(c => c == maLettre).Count() != 0)
            {
                for (int i = 0; i < MonMot.Length; i++)
                {
                    if (MonMot[i] == maLettre)
                    {
                        char[] tmpBuffer = LeMotADisplay.ToCharArray();
                        tmpBuffer[i] = maLettre;
                        LeMotADisplay = new string(tmpBuffer);
                    }
                }
            }
            return LeMotADisplay;
        }
    }
}
