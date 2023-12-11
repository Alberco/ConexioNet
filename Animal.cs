using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class Animal
    {
        public Animal(int animalID, string nombre, string especie, int edad, DateTime fechaLlegada, string estadoSalud)
        {
            AnimalID = animalID;
            Nombre = nombre;
            Especie = especie;
            Edad = edad;
            FechaLlegada = fechaLlegada;
            EstadoSalud = estadoSalud;
        }

        public int AnimalID {  get; set; }
        public string Nombre { get; set; }
        public string Especie {  get; set; }
        public int Edad {  get; set; }
        public DateTime FechaLlegada { get; set; }
        public string EstadoSalud {  get; set; }
    }
}
