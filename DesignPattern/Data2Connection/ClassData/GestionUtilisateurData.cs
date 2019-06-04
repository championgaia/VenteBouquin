using ClassDto.ClassDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data2.ClassData
{
    class GestionUtilisateurData
    {
        private string CONNECTIONSTRING;
        public GestionUtilisateurData()
        {
            CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["VenteBouquinDb"].ToString();
        }
        #region GetAllPeople
        public List<PersonneDTO> GetAllPeople()
        {
            List<PersonneDTO> maListPeople = new List<PersonneDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetPersonne", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    maListPeople.Add(new PersonneDTO
                    {
                        CodePersonneDto = int.Parse(reader[0].ToString()),
                        NomDto = reader[1].ToString(),
                        PrenomDto = reader[2].ToString(),
                        DateNaissanceDto = reader[3].ToString(),
                        AdresseDto = new AdresseDTO
                        {
                            CodeAdresseDto = int.Parse(reader[3].ToString()),
                            NumeroRueDto = int.Parse(reader[4].ToString()),
                            NomRueDto = reader[5].ToString(),
                            NomVilleDto = reader[6].ToString(),
                            CodePostaleDto = reader[7].ToString(),
                            NomPaysDto = reader[8].ToString(),
                            AdresseComplementaireDto = reader[9].ToString()
                        }
                    });
                }
            }
            return maListPeople;
        }
        #endregion
        #region CreatePersonne
        public void CreatePersonne(PersonneDTO personneDto)
        {
        }
        #endregion
        #region GetPayeurDTO par codePayeur     GestionUtilisateurData
        public PayeurDTO GetPayeurDTO(int codePayeur)
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetPayeur", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idPayeur", codePayeur);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    monListePayeurDto.Add(new PayeurDTO
                    {
                        CodePayeurDto = int.Parse(reader[0].ToString()),
                        CodeUtilisateurDto = reader[0].ToString(),
                        PersonneDto = new PersonneDTO
                        {
                            CodePersonneDto = int.Parse(reader[0].ToString()),
                            NomDto = reader[1].ToString(),
                            PrenomDto = reader[2].ToString(),
                            DateNaissanceDto = reader[3].ToString()
                        }
                    });
                }
            }
            return monListePayeurDto.FirstOrDefault();
        }
        #endregion
        #region GetPayeurDTO par codeUtilisateur     GestionUtilisateurData
        public PayeurDTO GetPayeurDTO(string codeUtilisateur)
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetPayeur", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codeUtilisateur", codeUtilisateur);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    monListePayeurDto.Add(new PayeurDTO
                    {
                        CodePayeurDto = int.Parse(reader[0].ToString()),
                        CodeUtilisateurDto = reader[0].ToString(),
                        PersonneDto = new PersonneDTO
                        {
                            CodePersonneDto = int.Parse(reader[0].ToString()),
                            NomDto = reader[1].ToString(),
                            PrenomDto = reader[2].ToString(),
                            DateNaissanceDto = reader[3].ToString()
                        }
                    });
                }
            }
            return monListePayeurDto.FirstOrDefault();
        }
        #endregion
        #region GetAllPayeurDTO     GestionUtilisateurData
        public List<PayeurDTO> GetAllPayeurDTO()
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetPayeur", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    monListePayeurDto.Add(new PayeurDTO
                    {
                        CodePayeurDto = int.Parse(reader[0].ToString()),
                        CodeUtilisateurDto = reader[0].ToString(),
                        PersonneDto = new PersonneDTO
                        {
                            CodePersonneDto = int.Parse(reader[0].ToString()),
                            NomDto = reader[1].ToString(),
                            PrenomDto = reader[2].ToString(),
                            DateNaissanceDto = reader[3].ToString()
                        }
                    });
                }
            }
            return monListePayeurDto;
        }
        #endregion
        #region CreatePayeur    GestionUtilisateurData
        public void CreatePayeur(PayeurDTO payeurDto)
        {

        }
        #endregion
    }
}
