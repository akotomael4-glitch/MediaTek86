using MySql.Data.MySqlClient;
using MediaTek86.Modele;
using MediaTek86.bddmanager;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MediaTek86.dal
{
    public class AbsenceDAL
    {
        private BddManager bdd = BddManager.GetInstance();

        public List<Absence> GetAll()
        {

            List<Absence> liste = new List<Absence>();

            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();

                string requete =
                                "SELECT a.id, a.id_personnel, a.id_motif, a.date_debut, a.date_fin, " +
                                "p.nom AS nomPersonnel, p.prenom AS prenomPersonnel, m.libelle AS motif " +
                                "FROM absence a " +
                                "INNER JOIN personnel p ON a.id_personnel = p.id " +
                                "INNER JOIN motif m ON a.id_motif = m.id";

                MySqlCommand command = new MySqlCommand(requete, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Absence
                        {
                            Id = reader.GetInt32("id"),
                            IdPersonnel = reader.GetInt32("id_personnel"),
                            IdMotif = reader.GetInt32("id_motif"),
                            DateDebut = reader.GetDateTime("date_debut"),
                            DateFin = reader.GetDateTime("date_fin"),
                            Personnel = reader.GetString("nomPersonnel") + " " + reader.GetString("prenomPersonnel"),
                            Motif = reader.GetString("motif")
                        });
                    }
                }
            }

            return liste;
        }
        public void Add(Absence absence)
        {
            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();

                string requete =
                    "INSERT INTO absence (id_personnel, id_motif, date_debut, date_fin) " +
                    "VALUES (@personnel, @motif, @debut, @fin)";

                MySqlCommand command = new MySqlCommand(requete, connection);

                command.Parameters.AddWithValue("@personnel", absence.IdPersonnel);
                command.Parameters.AddWithValue("@motif", absence.IdMotif);
                command.Parameters.AddWithValue("@debut", absence.DateDebut);
                command.Parameters.AddWithValue("@fin", absence.DateFin);

                command.ExecuteNonQuery();
            }
        }
        public void Modifier(Absence absence)
        {
            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();
                string requete =
                   "UPDATE absence " +

                   "SET id_personnel = @personnel, " +

                   "id_motif = @motif, " +

                   "date_debut = @debut, " +

                   "date_fin = @fin " +

                   "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(requete, connection);

                command.Parameters.AddWithValue("@personnel", absence.IdPersonnel);
                command.Parameters.AddWithValue("@motif", absence.IdMotif);
                command.Parameters.AddWithValue("@debut", absence.DateDebut);
                command.Parameters.AddWithValue("@fin", absence.DateFin);
                command.Parameters.AddWithValue("@id", absence.Id);


                command.ExecuteNonQuery();
            }
        }

        public bool Chevauchement(Absence absence)
        {
            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();

                string requete =
                    "SELECT COUNT(*) FROM absence " +
                    "WHERE id_personnel = @personnel " +
                    "AND id != @id " +
                    "AND (@debut <= date_fin AND @fin >= date_debut)";

                MySqlCommand command = new MySqlCommand(requete, connection);

                command.Parameters.AddWithValue("@personnel", absence.IdPersonnel);
                command.Parameters.AddWithValue("@debut", absence.DateDebut);
                command.Parameters.AddWithValue("@fin", absence.DateFin);

                if (absence.Id == 0)
                {
                    command.Parameters.AddWithValue("@id", -1);
                }
                else
                {
                    command.Parameters.AddWithValue("@id", absence.Id);
                }

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }


        public void Supprimer(int id)
        {
            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();

                string requete = "DELETE FROM absence WHERE id = @id";

                MySqlCommand command = new MySqlCommand(requete, connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}




