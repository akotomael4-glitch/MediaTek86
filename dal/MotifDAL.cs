using MediaTek86.bddmanager;
using MediaTek86.Modele;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MediaTek86.dal
{
    public class MotifDAL
    {
        private BddManager bdd = BddManager.GetInstance();

        public List<Motif> GetAll()

        {
            List<Motif> liste = new List<Motif>();

            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();

                string requete = "SELECT * FROM motif";

                MySqlCommand command = new MySqlCommand(requete, connection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    liste.Add(new Motif
                    {
                        Id = reader.GetInt32("id"),
                        Libelle = reader.GetString("libelle")
                    });
                }
            }

                    return liste;


                }
            }
        }
    


