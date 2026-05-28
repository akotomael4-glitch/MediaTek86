using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager {
    public class BddManager
    {
        private static BddManager instance;
        // NOTE: Do not keep a single shared MySqlConnection instance. Return a new
        // MySqlConnection for each call to GetConnection to avoid disposing a
        // shared connection when callers use "using".
        private string serverConnectionString = "server=localhost;uid=root;pwd=;";
        private string databaseName = "mediatek86";

        private BddManager()
        {
            // Ensure the database exists on the server; requires a user with CREATE DATABASE privileges (root by default)
            using (var serverConn = new MySqlConnection(serverConnectionString))
            {
                serverConn.Open();
                using (var cmd = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS `{databaseName}` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;", serverConn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // Now create a connection that targets the database
            // do not create a shared connection here; GetConnection will create
            // a new MySqlConnection when requested
            string connectionstring = $"{serverConnectionString}database={databaseName};";
        }

        public static BddManager GetInstance()
        {
            if (instance == null)
            {
                instance = new BddManager();
            }
            return instance;
        }

        public MySqlConnection GetConnection()
        {
            string connectionstring = $"{serverConnectionString}database={databaseName};";
            return new MySqlConnection(connectionstring);
        }
    }
}
