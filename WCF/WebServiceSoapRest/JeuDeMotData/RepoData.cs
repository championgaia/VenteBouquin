using JeuDeMotData.ClassData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeMotData
{
    public class RepoData
    {
        public string GetWord()
        {
            return new JeuDeMot().MonMot;
        }
    }
}
