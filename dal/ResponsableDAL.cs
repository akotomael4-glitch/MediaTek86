using MySql.Data.MySqlClient;
using System;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    public class ResponsableDAL
    {
        private BddManager bdd = BddManager.GetInstance();

        public bool Connexion(string login, string pwd)
        {
            using (MySqlConnection connection = bdd.GetConnection())
            {
                connection.Open();


                string requete =
                     "SELECT COUNT(*) FROM responsable " +
                     
                     "WHERE login = @login AND pwd = @pwd";

                MySqlCommand command = new MySqlCommand(requete, connection);

                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@pwd", pwd);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;


            }
        }
    }
}

