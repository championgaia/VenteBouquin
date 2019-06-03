
using ClassDto.ClassDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ClassData
{
    class GestionCatalogueData
    {
        private string CONNECTIONSTRING;
        public GestionCatalogueData()
        {
            CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["VenteBouquinDb"].ToString();
        }
        #region GetAllLivreCategoryDTOs    GestionCatalogueData
        public List<LivreCategoryDTO> GetAllLivreCategoryDTOs()
        {
            List<LivreCategoryDTO> livreCategoryDTOs = new List<LivreCategoryDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    livreCategoryDTOs.Add(new LivreCategoryDTO
                    {
                        CodeCategoryDto = int.Parse(reader[0].ToString()),
                        NomCategoryDto = reader[1].ToString()
                    });
                }
            }
            return livreCategoryDTOs;
        }
        #endregion
        #region GetLivreCategory par codeCategory    GestionCatalogueData
        public LivreCategoryDTO GetLivreCategory(int codeCategory)
        {
            var categoryDto = new LivreCategoryDTO();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCategory", codeCategory);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categoryDto.CodeCategoryDto = int.Parse(reader[0].ToString());
                    categoryDto.NomCategoryDto = reader[1].ToString();
                }
            }
            return categoryDto;
        }
        #endregion
        #region GetAllLivreDTO  GestionCatalogueData
        public List<LivreDTO> GetAllLivreDTO()
        {
            var listeLivreDTO = new List<LivreDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetLivre", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listeLivreDTO.Add(new LivreDTO
                    {
                        AuteurDto = reader[2].ToString(),
                        CodeISBNDto = reader[3].ToString(),
                        
                        CoverImageDto = reader[4].ToString(),
                        EditeurDto = reader[5].ToString(),
                        CodeLivreDto = int.Parse(reader[6].ToString()),
                        NomLivreDto = reader[7].ToString(),
                        PrixDto = double.Parse(reader[8].ToString()),
                        DescriptionDto = new DescriptionDTO
                        {
                            CodeDescriptionDto = int.Parse(reader[9].ToString()),
                            DetailDto = reader[10].ToString(),
                            CodeISBNDto = reader[3].ToString()
                        },
                        LaCategoryDto = new LivreCategoryDTO
                        {
                            CodeCategoryDto = int.Parse(reader[0].ToString()),
                            NomCategoryDto = reader[1].ToString()
                        }
                    });
                }
            }
            return listeLivreDTO;
        }
        #endregion
        #region GetLivreParCategoryDTO  GestionCatalogueData
        public List<LivreDTO> GetLivreParCategoryDTO(int codeCategory)
        {
            var listeLivreDTO = new List<LivreDTO>();
            foreach (var item in context.Livres
                .Where(c => c.FkLivreCategory == codeCategory)
                .ToList())
            {
                listeLivreDTO.Add(GetLivreParCodeISBNDTO(item.CodeISBN));
            }
            return listeLivreDTO;
        }
        #endregion
        #region GetLivreParCodeISBNDTO  GestionCatalogueData
        public LivreDTO GetLivreParCodeISBNDTO(string codeISBN)
        {
            var livre = context.Livres
                .FirstOrDefault(c => c.CodeISBN == codeISBN);
            var livreDTO = new LivreDTO
            {
                CodeLivreDto = livre.IdLivre,
                CodeISBNDto = livre.CodeISBN,
                NomLivreDto = livre.NomLivre,
                AuteurDto = livre.Auteur,
                EditeurDto = livre.Editeur,
                PrixDto = (double)livre.Prix,
                DescriptionDto = new DescriptionDTO
                {
                    CodeDescriptionDto = livre.Description.IdDescription,
                    CodeISBNDto = livre.Description.CodeISBN,
                    DetailDto = livre.Description.Detail
                },
                LaCategoryDto = GetLivreCategory(livre.FkLivreCategory)
            };
            return livreDTO;
        }
        #endregion
    }
}
