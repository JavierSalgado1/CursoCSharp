using System;
// Realizar aplicación de consola que sume, reste, multiplique y divida dos números predefinidos en 
// variables. Mostrar los resultados usando concatenación.
namespace TareasSimples
{
    class Video5
    {
        static void Main(string[] args)
        {
            int num1 = 2000;
            int num2 = 16;

            // Se utilizan paréntesis en la operación para evitar que se concatenen los dos números en 
            // vez de sumarse.
            Console.WriteLine("La suma de los dos números es " + (num1 + num2));
            Console.WriteLine("La resta de los dos números es " + (num1 - num2));

            Console.WriteLine($"La multiplicación de los dos números es {num1 * num2}");
            Console.WriteLine($"La divión entre los dos números es {num1 / num2}");
        }
    }
}
