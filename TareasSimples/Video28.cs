using System;
// Realizar aplicación de consola que permita crear objetos de tipo Persona y conocer sus nombres completos. Las personas tendrán 
// como propiedades su nombre y su apellido, y como comportamiento, decir sus nombres. Sus propiedades no deben poder accederse 
// desde fuera de la clase.
namespace TareasSimples
{
    class Video28
    {
        static void Main(string[] args)
        {
            // Se crea una instancia de la clase Persona llamada persona1 y se inicializa en la misma línea.
            Persona persona1 = new Persona();

            // Se imprime el retorno del método DecirNombres de la instancia persona1 de la clase Persona.
            Console.WriteLine(persona1.DecirNombres());
        }
    }

    class Persona
    {
        string nombre = "Perico";
        string apellido = "Los Palotes";

        public string DecirNombres()
        {
            return "Mi nombre es " + nombre + " " + apellido;
        }
    }
}