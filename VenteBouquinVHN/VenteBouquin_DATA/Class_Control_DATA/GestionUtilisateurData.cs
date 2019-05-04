using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA.Class_Control_DATA
{
    internal class GestionUtilisateurData
    {
        private VenteBouquinContext context = new VenteBouquinContext();
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
                        DateNaissanceDto = payeur.Personne.DateNaissance
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
                        DateNaissanceDto = payeur.Personne.DateNaissance
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
                    DateNaissance = payeurDto.PersonneDto.DateNaissanceDto
                }
            };
            context.Utilisateurs.AddOrUpdate(payeur);
            context.SaveChanges();
        }
        #endregion
    }
}
