using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp28.Data
{
    public class Conexion
    {
        private string connectionString;
        private SqlConnection connection;

        public Conexion(string connectionString)
        {
            this.connectionString = connectionString;
            this.connection = new SqlConnection(connectionString);
        }

        public void AbrirConexion()
        {
            if(connection.State == System.Data.ConnectionState.Closed) 
            {
                connection.Open();
            }
        }

        public void CerrarConexion()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlDataReader EjecutarQuery(string query)
        {
            try
            {
                AbrirConexion();
                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    return command.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta" + ex.Message);
                return null;
            }
        }

        public void Dispose()
        {
            CerrarConexion();
        }
    
    }
}
