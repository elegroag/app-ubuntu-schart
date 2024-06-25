
using System;
using Microsoft.Data.Sqlite;

namespace BackFacture.connection
{
    public sealed class SqConnection
    {
        private static readonly Lazy<SqConnection> _instance = new Lazy<SqConnection>(() => new SqConnection());

        private SqliteConnection connection;

        private SqConnection()
        {
            try
            {
                connection = new SqliteConnection("Data Source=" + Config.Dbpath);
                if (Config.Verbose)
                {
                    Console.WriteLine("¡Conexión exitosa a la base de datos SQLite!");
                }
            }
            catch (Exception err)
            {
                // Trata cualquier error de conexión
                Console.WriteLine(err.Message);
            }
        }

        public static SqConnection Instance => _instance.Value;

        public SqliteConnection Connection
        {
            get
            {
                this.connection.Open();
                return connection;
            }
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception err)
            {
                // Trata cualquier error de cierre
                Console.WriteLine(err.Message);
            }
        }
    }

}