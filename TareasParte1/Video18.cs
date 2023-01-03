using System;
// Realizar aplicación de consola que pida al usuario ingresar de manera exacta el nombre de una ciudad capital de Sudamérica. 
// En caso de acertar, debe indicar el país al que pertenece la capital, y sino, indicar el error. Utilizar condicional switch.
namespace TareasParte1
{
    class Video18
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el nombre de una capital de Sudamérica: ");
            string capital = Console.ReadLine()!;

            switch(capital)
            {
                case "Buenos Aires":
                    Console.WriteLine("Esta capital corresponde a Argentina");
                    break;
                case "Sucre":
                    Console.WriteLine("Esta capital corresponde a Bolivia");
                    break;
                case "Brasilia":
                    Console.WriteLine("Esta capital corresponde a Brasil");
                    break;
                case "Santiago":
                    Console.WriteLine("Esta capital corresponde a Chile");
                    break;
                case "Bogotá":
                    Console.WriteLine("Esta capital corresponde a Colombia");
                    break;
                case "Quito":
                    Console.WriteLine("Esta capital corresponde a Ecuador");
                    break;
                case "Asunción":
                    Console.WriteLine("Esta capital corresponde a Paraguay");
                    break;
                case "Lima":
                    Console.WriteLine("Esta capital corresponde a Perú");
                    break;
                case "Parabarimo":
                    Console.WriteLine("Esta capital corresponde a Surinam");
                    break;
                case "Puerto España":
                    Console.WriteLine("Esta capital corresponde a Trinidad y Tobago");
                    break;
                case "Montevideo":
                    Console.WriteLine("Esta capital corresponde a Uruguay");
                    break;
                case "Caracas":
                    Console.WriteLine("Esta capital corresponde a Venezuela");
                    break;
                default:
                    Console.WriteLine("ERROR: La ciudad ingresada no corresponde a ninguna capital de Sudamérica.");
                    break;
            }
        }
    }
}