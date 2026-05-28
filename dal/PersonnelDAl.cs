using MySql.Data.MySqlClient;
using MediaTek86.Modele;
using MediaTek86.bddmanager;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Mysqlx.Prepare;

namespace MediaTek86.dal
{
    public class PersonnelDAl
    {
        private BddManager bdd = BddManager.GetInstance();

        public PersonnelDAl()
        {
         
        }

        public List<Personnel> GetAll()
        {
            var liste = new List<Personnel>();

            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(
                    "SELECT p.id, p.nom, p.prenom, s.nom AS Service " +
                    "FROM personnel p " +
                    "INNER JOIN service s ON p.id_service = s.id ",
                    connection))

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Personnel
                        {
                            Id = reader.GetInt32("id"),
                            Nom = reader.GetString("nom"),
                            Prenom = reader.GetString("prenom"),
                            IdService = 0,
                            Service = reader.GetString("Service")
                        });
                    }
                }
            }

            return liste;
        }

        public void Ajouter(Personnel personnel)
        {
            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();

                string query = "INSERT INTO personnel (nom, prenom, id_service) VALUES (@nom, @prenom, @id_service)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", personnel.Nom);
                    command.Parameters.AddWithValue("@prenom", personnel.Prenom);
                    command.Parameters.AddWithValue("@id_service", personnel.IdService);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void supprimer(int id)
        {
            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();
                string request = "DELETE FROM personnel WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(request, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Modifier(Personnel personnel)
        {
            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();

                string request = "UPDATE personnel SET nom = @nom, prenom = @prenom, id_service = @id_service WHERE id = @id";

                MySqlCommand command = new MySqlCommand(request, connection);

                command.Parameters.AddWithValue("@id", personnel.Id);
                command.Parameters.AddWithValue("@nom", personnel.Nom);
                command.Parameters.AddWithValue("@prenom", personnel.Prenom);
                command.Parameters.AddWithValue("@id_service", personnel.IdService);

                command.ExecuteNonQuery();
            }
        }

       
        
        }
    }

        
        

          
