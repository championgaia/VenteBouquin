using ClassDto.ClassDTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ClassData
{
    class GestionUtilisateurData
    {
        private VenteBouquinContext context = new VenteBouquinContext();
        #region GetAllPeople
        public List<PersonneDTO> GetAllPeople()
        {
            List<PersonneDTO> maListPeople = new List<PersonneDTO>();
            foreach (var personne in context.Personnes)
            {
                maListPeople.Add(new PersonneDTO
                {
                    NomDto = personne.Nom,
                    PrenomDto = personne.Prenom,
                    DateNaissanceDto = personne.DateNaissance.ToShortDateString()
                });
            }
            return maListPeople;
        }
        #endregion
        #region CreatePersonne
        public void CreatePersonne(PersonneDTO personneDto)
        {
            context.Personnes.AddOrUpdate(new Personne
            {
                Nom = personneDto.NomDto,
                Prenom = personneDto.PrenomDto,
                DateNaissance = Convert.ToDateTime(personneDto.DateNaissanceDto),
                FkAdresse = 2
            });
            context.SaveChanges();
        }
        #endregion
        #region GetPayeurDTO par codePayeur     GestionUtilisateurData
        public PayeurDTO GetPayeurDTO(int codePayeur)
        {
            var payeur = context.Utilisateurs
                .FirstOrDefault(c => c.IdUtilisateur == codePayeur);
            if (payeur.CodeUtilisateur != null)
            {
                PayeurDTO payeurDto = new PayeurDTO
                {
                    CodePayeurDto = payeur.IdUtilisateur,
                    CodeUtilisateurDto = payeur.CodeUtilisateur,
                    LoginDto = payeur.Login,
                    PasswordDto = payeur.Password,
                    RoleDto = payeur.Role,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = payeur.Personne.IdPersonne,
                        NomDto = payeur.Personne.Nom,
                        PrenomDto = payeur.Personne.Prenom,
                        DateNaissanceDto = payeur.Personne.DateNaissance.ToShortDateString()
                    }
                };
                //manque liste d'adresse
                return payeurDto;
            }
            return null;
        }
        #endregion
        #region GetPayeurDTO par codeUtilisateur     GestionUtilisateurData
        public PayeurDTO GetPayeurDTO(string codeUtilisateur)
        {
            var payeur = context.Utilisateurs
                .FirstOrDefault(c => c.CodeUtilisateur == codeUtilisateur);
            if (payeur.CodeUtilisateur != null)
            {
                PayeurDTO payeurDto = new PayeurDTO
                {
                    CodePayeurDto = payeur.IdUtilisateur,
                    CodeUtilisateurDto = payeur.CodeUtilisateur,
                    LoginDto = payeur.Login,
                    PasswordDto = payeur.Password,
                    RoleDto = payeur.Role,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = payeur.Personne.IdPersonne,
                        NomDto = payeur.Personne.Nom,
                        PrenomDto = payeur.Personne.Prenom,
                        DateNaissanceDto = payeur.Personne.DateNaissance.ToShortDateString()
                    }
                };
                //manque liste d'adresse
                return payeurDto;
            }
            return null;
        }
        #endregion
        #region GetAllPayeurDTO     GestionUtilisateurData
        public List<PayeurDTO> GetAllPayeurDTO()
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            foreach (var item in context.Utilisateurs.ToList())
            {
                monListePayeurDto.Add(GetPayeurDTO(item.IdUtilisateur));
            }
            //manque liste d'adresse
            return monListePayeurDto;
        }
        #endregion
        #region CreatePayeur    GestionUtilisateurData
        public void CreatePayeur(PayeurDTO payeurDto)
        {
            var payeur = new Utilisateur()
            {
                IdUtilisateur = payeurDto.CodePayeurDto,
                CodeUtilisateur = payeurDto.CodeUtilisateurDto,
                Login = payeurDto.LoginDto,
                Password = payeurDto.PasswordDto,
                Role = payeurDto.RoleDto,
                Personne = new Personne()
                {
                    IdPersonne = payeurDto.PersonneDto.CodePersonneDto,
                    Nom = payeurDto.PersonneDto.NomDto,
                    Prenom = payeurDto.PersonneDto.PrenomDto,
                    DateNaissance = Convert.ToDateTime(payeurDto.PersonneDto.DateNaissanceDto)
                }
            };
            context.Utilisateurs.AddOrUpdate(payeur);
            context.SaveChanges();
        }
        #endregion
    }
}
