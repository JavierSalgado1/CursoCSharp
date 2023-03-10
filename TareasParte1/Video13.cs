using System;
// Realizar una aplicación de consola que muestre el primer nombre de una persona, y luego el nombre completo. Utilizar método con 
// parámetros opcionales.
namespace TareasParte1
{
    class Video13
    {
        static void Main(string[] args)
        {            
            string primerNombre;
            string segundoNombre;
            string apellidos;

            Console.Write("Ingresa tu primer nombre: ");
            // Se agrega "!" luego de readline para indicar al compilador que el programa está preparado para recibir un valor 
            // nulo en la variable num1, y así evitar una advertencia por parte del compilador.
            primerNombre = Console.ReadLine()!;

            Console.Write("Ingresa tus apellidos: ");
            // Como el método ReadLine de la clase Console devuelve un dato de tipo string, no es necesario realizar un parseo 
            // o conversión del dato, como en los demás casos.
            apellidos = Console.ReadLine()!;

            MostrarNombre(primerNombre, apellidos);

            Console.WriteLine("---------------------------------------------");

            Console.Write("Ingresa tu primer nombre: ");
            primerNombre = Console.ReadLine()!;

            Console.Write("Ingresa tu segundo nombre: ");
            segundoNombre = Console.ReadLine()!;

            Console.Write("Ingresa tus apellidos: ");
            apellidos = Console.ReadLine()!;

            MostrarNombre(primerNombre, apellidos, segundoNombre);
        }

        static void MostrarNombre(string primerNombre, string apellidos, string segundoNombre = "" )
        {
            Console.WriteLine("Te llamas " + primerNombre);
            Console.WriteLine($"Tu nombre completo es {primerNombre} {segundoNombre} {apellidos}");
        }
    }
}