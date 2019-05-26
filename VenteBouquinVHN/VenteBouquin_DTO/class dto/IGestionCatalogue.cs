using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public interface IGestionCatalogue
    {
        List<LivreCategoryDTO> GetAllLivreCategory();
        LivreCategoryDTO GetLivreCategory(int codeCategory);
        List<LivreDTO> GetAllLivreDTO();
        List<LivreDTO> GetLivreParCategoryDTO(int codeCategory);
        LivreDTO GetLivreParCodeISBNDTO(string codeISBN);
    }
}
