using ConsoleApp28.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            string miJson = File.ReadAllText("objeto.txt");
            Animal animalNew = JsonSerializer.Deserialize<Animal>(miJson);
            Console.WriteLine(animalNew.Nombre);

            //Animal newanimal = new Animal(31, "Zorro", "Carnivoro", 23, DateTime.Now, "Enfermo");
            //string miJson = JsonSerializer.Serialize(newanimal);
            //Console.WriteLine(miJson);
            //File.WriteAllText("objeto.txt", miJson);

            void Ejemplo()
            {
                // Display the number of command line arguments.
                Libro[] arrayLibros = new Libro[5];
                arrayLibros[0] = new Libro(1, "Poeta en nueva york", "Federico García Lorca");
                arrayLibros[1] = new Libro(2, "Los asesinos del emperador", "Santiago Posteguillo");
                arrayLibros[2] = new Libro(3, "circo máximo", "Santiago Posteguillo");
                arrayLibros[3] = new Libro(4, "La noche en que Frankenstein leyó el Quijote", "Santiago Posteguillo");
                arrayLibros[4] = new Libro(5, "El origen perdido", "Matilde Asensi");


                var libros = from libro in arrayLibros
                             where libro.Autor == "Santiago Posteguillo"
                             select libro;

                IEnumerable<Libro> libroExtension = arrayLibros.Where(a => a.Autor == "Santiago Posteguillo").OrderBy(a => a.Titulo);

                foreach (Libro i in libroExtension)
                {
                    Console.WriteLine(i.Autor);
                }
            }
            //string connectionString = "Data Source=DESKTOP-6A0H483;Initial Catalog=ZooDatabase;Integrated Security=True";
            //Conexion miConexion = new Conexion(connectionString);
            //string query = "SELECT AnimalID, Nombre, Especie FROM Animales";


            //using(SqlDataReader reader = miConexion.EjecutarQuery(query))
            //{
            //    if(reader != null)
            //    {
            //        while (reader.Read())
            //        {
            //            Console.WriteLine($"AnimalID: {reader["AnimalID"]}, Nombre: {reader["Nombre"]}, Especie: {reader["Especie"]}");
            //        }
            //    }
            //}
            //miConexion.CerrarConexion();


            AnimalesBD animalbd = new AnimalesBD();

            //Animal newanimal = new Animal(31,"Zorro","Carnivoro",23,DateTime.Now,"Enfermo");

            //animalbd.Add(newanimal);

            // Animal editanimal = new Animal(31, "Zorro Australiano", "Carnivoro", 23, DateTime.Now, "Enfermo");

            //animalbd.Delete(31);

            //var animales = animalbd.Get();

            //foreach(var animal in animales)
            //{
            //    Console.WriteLine(animal.Nombre);
            //}

        }
    }
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public Libro(int id, string titulo, string autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
        }
    }

}