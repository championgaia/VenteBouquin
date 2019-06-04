using ClassDto.ClassDTO;
using Data2.ClassData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data2
{
    public class RepoData2
    {
        GestionUtilisateurData gestionUtilisateur = new GestionUtilisateurData();
        GestionCatalogueData gestionCatalogue = new GestionCatalogueData();
        GestionCommandeData gestionCommande = new GestionCommandeData();
        #region gestionUtilisateur RepoDdata
        public List<PersonneDTO> GetAllPeople()
        {
            return gestionUtilisateur.GetAllPeople();
        }
        public PayeurDTO GetPeopleById(string codeUtilisateur)
        {
            return gestionUtilisateur.GetPayeurDTO(codeUtilisateur);
        }
        public PayeurDTO GetPeopleById(int idPayeur)
        {
            return gestionUtilisateur.GetPayeurDTO(idPayeur);
        }
        public List<PayeurDTO> GetAllPayer()
        {
            return gestionUtilisateur.GetAllPayeurDTO();
        }
        public void CreatePersonne(PersonneDTO personneDto)
        {
            gestionUtilisateur.CreatePersonne(personneDto);
        }
        public void CreatePayer(PayeurDTO payeurDto)
        {
            gestionUtilisateur.CreatePayeur(payeurDto);
        }
        #endregion
        #region gestionCatalogue RepoData
        public List<LivreDTO> GetAllLivre()
        {
            return gestionCatalogue.GetAllLivreDTO();
        }
        public LivreDTO GetLivreByCodeISBN(string codeISBN)
        {
            return gestionCatalogue.GetLivreParCodeISBNDTO(codeISBN);
        }
        #endregion
    }
}
