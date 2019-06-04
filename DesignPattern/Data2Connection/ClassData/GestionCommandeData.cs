using ClassDto.ClassDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data2.ClassData
{
    internal class GestionCommandeData
    {
        private string CONNECTIONSTRING;
        public GestionCommandeData()
        {
            CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["VenteBouquinDb"].ToString();
        }
        #region GetCommandeDTO par codeCommande     GestionCommandeData
        public CommandeDTO GetCommandeDTO(int codeCommande)
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetCommande", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCommande", codeCommande);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    maListe.Add(new CommandeDTO
                    {
                        CodeCommandeDto = int.Parse(reader[0].ToString()),
                        PrixTotalDto = double.Parse(reader[1].ToString()),
                        LePayeurDto = new PayeurDTO
                        {
                            CodePayeurDto = int.Parse(reader[3].ToString()),
                            CodeUtilisateurDto = reader[2].ToString(),
                            PersonneDto = new PersonneDTO
                            {
                                CodePersonneDto = int.Parse(reader[4].ToString()),
                                NomDto = reader[5].ToString(),
                                PrenomDto = reader[6].ToString(),
                                DateNaissanceDto = reader[7].ToString()
                            }
                        }
                    });
                }
            }
            return maListe.FirstOrDefault();
        }
        #endregion
        #region GetListCommandeDTO par codePayeur
        public List<CommandeDTO> GetListCommandeDTO(int codePayeur)
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetCommande", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idPayeur", codePayeur);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    maListe.Add(new CommandeDTO
                    {
                        CodeCommandeDto = int.Parse(reader[0].ToString()),
                        PrixTotalDto = double.Parse(reader[1].ToString()),
                        LePayeurDto = new PayeurDTO
                        {
                            CodePayeurDto = int.Parse(reader[3].ToString()),
                            CodeUtilisateurDto = reader[2].ToString(),
                            PersonneDto = new PersonneDTO
                            {
                                CodePersonneDto = int.Parse(reader[4].ToString()),
                                NomDto = reader[5].ToString(),
                                PrenomDto = reader[6].ToString(),
                                DateNaissanceDto = reader[7].ToString()
                            }
                        }
                    });
                }
            }
            return maListe;
        }
        #endregion
        #region GetAllCommandeDTO       GestionCommandeData
        public List<CommandeDTO> GetAllCommandeDTO()
        {
            List<CommandeDTO> maListe = new List<CommandeDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetCommande", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    maListe.Add(new CommandeDTO
                    {
                        CodeCommandeDto = int.Parse(reader[0].ToString()),
                        PrixTotalDto = double.Parse(reader[1].ToString()),
                        LePayeurDto = new PayeurDTO
                        {
                            CodePayeurDto = int.Parse(reader[3].ToString()),
                            CodeUtilisateurDto = reader[2].ToString(),
                            PersonneDto = new PersonneDTO
                            {
                                CodePersonneDto = int.Parse(reader[4].ToString()),
                                NomDto = reader[5].ToString(),
                                PrenomDto = reader[6].ToString(),
                                DateNaissanceDto = reader[7].ToString()
                            }
                        }
                    });
                }
            }
            return maListe;
        }
        #endregion
        #region GetAllLigneDeCommandeDTO       GestionLigneDeCommandeData
        public List<LigneDeCommandeDTO> GetAllLigneDeCommandeDTO(int codeCommande)
        {
            List<LigneDeCommandeDTO> maListe = new List<LigneDeCommandeDTO>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTIONSTRING;
                connection.Open();
                SqlCommand command = new SqlCommand("GetLigneDeCommande", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCommande", codeCommande);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    maListe.Add(new LigneDeCommandeDTO
                    {
                        CodeLigneCommandeDto = int.Parse(reader[2].ToString()),
                        QuantiteDto = int.Parse(reader[3].ToString()),
                        LeLivreDto = new LivreDTO
                         {
                             CodeISBNDto = reader[4].ToString(),
                             CodeLivreDto = int.Parse(reader[6].ToString()),
                             PrixDto = int.Parse(reader[5].ToString())
                         },
                         LaPromoDto = new PromotionDTO
                         {
                              CodePromotionDto = int.Parse(reader[7].ToString()),
                               PourcentagePromo = double.Parse(reader[8].ToString())
                         },
                         LaCommandeDto = new CommandeDTO
                         {
                             CodeCommandeDto = int.Parse(reader[0].ToString())
                         }
                    });
                }
            }
            return maListe;
        }
        #endregion
        #region CreateCommande     GestionCommandeData
        public void CreateCommande(CommandeDTO commandeDto)
        {
            
        }
        #endregion
    }
}
