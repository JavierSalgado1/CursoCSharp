using System;
// EJERCICIO PROPUESTO EN EL CURSO. Realizar aplicación de consola que genere un número aleatorio. El usuario deberá introducir 
// números y el programa deberá imprimir si el número ingresado es mayor o menor al número generado. Se debe repetir esto hasta 
// acertar el número, y el programa deberá indicar el número de intentos que se utilizaron para acertar. Utilizar bucle While.
namespace TareasSimples
{
    class Video19
    {
        static void Main(string[] args)
        {
            byte contador = 1;
            byte numIngresado = 0;

            Random rand = new Random();
            int numeroAleatorio = rand.Next(0, 100);

            Console.WriteLine("--- Adivina el número ---");

            while (contador > 0)
            {
                Console.Write("Ingrese un número: ");
                numIngresado = byte.Parse(Console.ReadLine()!);

                if (numeroAleatorio < numIngresado)
                {
                    Console.WriteLine("El número es menor.");
                    // Con el operador ++ se incrementa en uno el valor de contador
                    contador ++;
                }
                else if(numeroAleatorio > numIngresado)
                {
                    Console.WriteLine("El número es mayor.");
                    contador ++;
                }
                else
                {
                    Console.WriteLine($"Acertaste !!!   -----   Número de intentos: {contador}");
                    // Dejando el contador en 0, ya no se complirá la condición del While, por lo que no se volverá a 
                    // repetir la ejecución del bucle.
                    contador = 0;
                }
            }
        }
    }
}