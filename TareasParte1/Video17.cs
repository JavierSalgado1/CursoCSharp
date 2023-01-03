using System;
// Realizar aplicación de consola que pida ingresar 3 números (asumir que son positivos) y que los multiplique. Imprimir el nombre 
// del tipo de dato entero de menor capacidad que puede contener al resultado. Utilizar if con else if.
namespace TareasParte1
{
    class Video17
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el primer factor: ");
            // Se realiza la definición y asignación del valor de la variable num1 en la misma línea.
            ulong num1 = ulong.Parse(Console.ReadLine()!);

            Console.Write("Ingrese el segundo factor: ");
            ulong num2 = ulong.Parse(Console.ReadLine()!);

            Console.Write("Ingrese el tercer factor: ");
            ulong num3 = ulong.Parse(Console.ReadLine()!);

            // Se almacena el valor devuelto por el método Multiplicar en la variable resultado.
            ulong resultado = Multiplicar(num1, num2, num3);

            if (resultado <= 255)
            {
                Console.WriteLine($"El resultado es {resultado} y puede ser almacenado en un byte");
            }
            else if(resultado <= 65535)
            {
                Console.WriteLine($"El resultado es {resultado} y puede ser almacenado en un ushort");
            }
            else if(resultado <= 4294967295)
            {
                Console.WriteLine($"El resultado es {resultado} y puede ser almacenado en un uint");
            }
            else
            {
                Console.WriteLine($"El resultado es {resultado} y puede ser almacenado en un ulong");
            }
        }

        static ulong Multiplicar(ulong factor1, ulong factor2, ulong factor3)
        {
            ulong resultado = factor1*factor2*factor3;
            return resultado;
        }
    }
}