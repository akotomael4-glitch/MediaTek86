using MySql.Data.MySqlClient;
using MediaTek86.Modele;
using MediaTek86.bddmanager;
using System.Collections.Generic;
using System.Diagnostics;

namespace MediaTek86.dal
{
    public class ServiceDal
    {
        private BddManager bdd = BddManager.GetInstance();

        public List<Service> GetAll()
        {
            List<Service> liste = new List<Service>();

            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();

                string requete = "SELECT * FROM service";

                using (MySqlCommand command = new MySqlCommand(requete, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Service
                        {
                            Id = reader.GetInt32("id"),
                            Nom = reader.GetString("nom")
                        });
                    }
                }
            }

            return liste;
        }
    }
}
