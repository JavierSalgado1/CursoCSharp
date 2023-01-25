// Realizar aplicación de consola que permita al usuario ingresar un número y luego imprimir en consola los números primos que existen 
// hasta llegar a ese número. Utilizar delegados predicados.
// * Adaptación de ejercicio propuesto en el curso.
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace TareasParte3
{
    class Video68
    {
        static void Main(string[] args)
        {
            Console.Clear();

            bool numeroValido = false;
            ushort numero = 0;
            List<ushort> numeros = new List<ushort>();

            do
            {
                try
                {
                    Console.Write("Ingresa un número: ");
                    numero = ushort.Parse(Console.ReadLine()!);
                    numeroValido = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("El número ingresado es inválido.");
                }
            }
            while (!numeroValido);

            for(ushort i = 1; i <= numero; i++)
            {
                numeros.Add(i);
            }

            Predicate<ushort> predicado = new Predicate<ushort>(numerosPrimos);
            List<ushort> listaNumerosPrimos = numeros.FindAll(predicado);

            Console.Clear();
            Console.WriteLine("Lista de números primos: ");

            foreach(ushort numeroPrimo in listaNumerosPrimos)
            {
                Console.WriteLine(numeroPrimo);
            }
        }

        static bool numerosPrimos(ushort numero)
        {
            ushort contador = 0;

            for(ushort divisor = numero; divisor > 0; divisor--)
            {
                if (numero % divisor == 0) contador++;
            }

            if (contador == 2) return true;
            else return false;
        }
    }
}
