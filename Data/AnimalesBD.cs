using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp28.Data
{
    class AnimalesBD
    {
        private string connectionString = "Data Source=DESKTOP-6A0H483;Initial Catalog=ZooDatabase;Integrated Security=True";
        
        public List<Animal> Get()
        {
            List<Animal> animales = new List<Animal>();
            string query = "SELECT AnimalID, Nombre, Especie, Edad, FechaLlegada, EstadoSalud FROM Animales";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                //sirve para hacer querys
                SqlCommand command = new SqlCommand(query,connection);
                connection.Open();
                //lee el resultado uno a uno
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string especie = reader .GetString(2);
                    int edad = reader.GetInt32(3);
                    DateTime fechallegada = reader.GetDateTime(4);
                    string estado = reader.GetString(5);
                    Animal animal  = new Animal(id,nombre,especie,edad,fechallegada,estado);
                    animales.Add(animal);

                }
                reader.Close();
                connection.Close();
            }


            return animales;
        }
        public void Add(Animal animal)
        {
            string query = "INSERT INTO Animales(AnimalID, Nombre, Especie, Edad, FechaLlegada, EstadoSalud)" +
                            "values(@AnimalID,@Nombre,@Especie,@Edad,@FechaLlegada,@EstadoSalud)";

            using( var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@AnimalID",animal.AnimalID);
                command.Parameters.AddWithValue("@Nombre", animal.Nombre);
                command.Parameters.AddWithValue("@Especie", animal.Especie);
                command.Parameters.AddWithValue("@Edad", animal.Edad);
                command.Parameters.AddWithValue("@FechaLlegada", animal.FechaLlegada);
                command.Parameters.AddWithValue("@EstadoSalud", animal.EstadoSalud);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(Animal animal, int Id)
        {
            string query = "update Animales " +
                "set AnimalID=@AnimalID,NOMBRE=@Nombre,Especie=@Especie,Edad=@Edad,FechaLlegada=@FechaLlegada,EstadoSalud=@EstadoSalud " +
                "WHERE AnimalID=@AnimalID";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", animal.Nombre);
                command.Parameters.AddWithValue("@Especie", animal.Especie);
                command.Parameters.AddWithValue("@Edad", animal.Edad);
                command.Parameters.AddWithValue("@FechaLlegada", animal.FechaLlegada);
                command.Parameters.AddWithValue("@EstadoSalud", animal.EstadoSalud);
                command.Parameters.AddWithValue("@AnimalID", Id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int Id)
        {
            string query = "delete from Animales where AnimalID=@AnimalID";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AnimalID", Id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
