using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WF01_01_MyFirstWF.Models;

namespace WF01_01_MyFirstWF.ViewModels
{
    public class DetailLivreViewModel
    {
        public LivreModel LivreVM { get; set; }
        
        public DetailLivreViewModel()
        {
                
        }
        public DetailLivreViewModel(string codeISBN)
        {
            LivreVM = new LivreModel(codeISBN);
        }
    }
}