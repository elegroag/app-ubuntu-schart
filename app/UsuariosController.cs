using System;
using Microsoft.Data.Sqlite;
using BackFacture.connection;
using Newtonsoft.Json.Linq;

namespace BackFacture.app
{
    public class UsuariosController
    {

        private SqConnection sqConnection;

        public UsuariosController()
        {
            this.sqConnection = SqConnection.Instance;
        }

        public Response PruebaConnection(JObject data)
        {
            SqliteConnection connection = this.sqConnection.Connection;
            string msj = "";
            try
            {
                var query = @"SELECT id, nombres, apellidos, cedula FROM usuarios";
                using var command = new SqliteCommand(query, connection);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var nombres = reader.GetString(1);
                    var apellidos = reader.GetString(2);
                    var cedula = reader.GetInt64(3);
                    msj = $"ID: {id}, Nombre: {nombres} {apellidos}, Cedula: {cedula}";
                }
                connection.Close();
            }
            catch (Exception err)
            {
                connection.Close();
                Console.WriteLine(err.Message);
                throw;
            }
            return new Response(ResponseStatus.Success, msj, data);
        }

        public Response CreateTable(JObject data)
        {
            string msj = "";
            try
            {
                SqliteConnection connection = this.sqConnection.Connection;
                connection.Open();

                var createCommand = connection.CreateCommand();
                createCommand.CommandText =
                @"
                    CREATE TABLE data (
                        value BLOB
                    )
                ";
                createCommand.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
            return new Response(ResponseStatus.Success, msj, data);

        }
    }
}