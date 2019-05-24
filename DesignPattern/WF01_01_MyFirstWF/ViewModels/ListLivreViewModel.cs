using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WF01_01_MyFirstWF.Models;

namespace WF01_01_MyFirstWF.ViewModels
{
    public class ListLivreViewModel
    {
        public List<LivreModel> ListBookVM { get; set; }
        public double TotalPrixVM { get; set; }
        private RepoData repo = new RepoData();
        public ListLivreViewModel()
        {
            ListBookVM = new List<LivreModel>();
            foreach (var livre in repo.GetAllLivre())
            {
                ListBookVM.Add(new LivreModel
                {
                    CodeLivreM = livre.CodeLivreDto,
                    CodeISBNM = livre.CodeISBNDto,
                    AuteurM = livre.AuteurDto,
                    NomLivreM = livre.NomLivreDto,
                    EditeurM = livre.EditeurDto,
                    PrixM = livre.PrixDto,
                    CoverImageM = livre.CoverImageDto,
                    LaCategoryM = new LivreCategoryModel
                    {
                         CodeCategoryM = livre.LaCategoryDto.CodeCategoryDto,
                         NomCategoryM = livre.LaCategoryDto.NomCategoryDto
                    },
                    DescriptionM = new DescriptionModel
                    {
                        CodeDescriptionM = livre.DescriptionDto.CodeDescriptionDto,
                        DetailM = livre.DescriptionDto.DetailDto
                    }
                });
            }
            //TotalPrixVM = ListBookVM.Select(c => c.PrixM).Sum();
        }
        public ListLivreViewModel(double prix)
        {
            TotalPrixVM += prix;
            ListBookVM = new ListLivreViewModel().ListBookVM;
        }
    }
}
