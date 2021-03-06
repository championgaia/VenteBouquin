﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class LivreBOL
    {
        public int CodeLivre { get; set; }
        public string CodeISBN { get; set; }
        public string NomLivre { get; set; }
        public string Auteur { get; set; }
        public string Editeur { get; set; }
        public string CoverImage { get; set; }
        public double Prix { get; set; }
        public DescriptionBOL Description { get; set; }
        public LivreCategoryBOL LaCategory { get; set; }
        private RepoData repo = new RepoData();
        #region Constructeur par deffault
        public LivreBOL() { }
        #endregion
        #region Constructeur par code ISBN
        public LivreBOL(string codeISBN)
        {
            var livreDto = repo.GetLivreParCodeISBNDTORepoData(codeISBN);
            CodeLivre = livreDto.CodeLivreDto;
            CodeISBN = livreDto.CodeISBNDto;
            NomLivre = livreDto.NomLivreDto;
            Auteur = livreDto.AuteurDto;
            Editeur = livreDto.EditeurDto;
            CoverImage = livreDto.CoverImageDto;
            Prix = livreDto.PrixDto;
            Description = new DescriptionBOL
            {
                CodeDescription = livreDto.DescriptionDto.CodeDescriptionDto,
                CodeISBN = livreDto.DescriptionDto.CodeISBNDto,
                Detail = livreDto.DescriptionDto.DetailDto
            };
            LaCategory = new LivreCategoryBOL
            {
                CodeCategory = livreDto.LaCategoryDto.CodeCategoryDto,
                NomCategory = livreDto.LaCategoryDto.NomCategoryDto
            };
        }
        #endregion
    }
}
