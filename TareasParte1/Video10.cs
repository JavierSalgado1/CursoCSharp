using System;
// Realizar aplicación de consola que imprima en líneas diferentes el nombre de 5 tipos de datos primitivos 
// en C#. Luego, que permita multiplicar 2 números ingresados por el usuario y que imprima el resultado. 
// Utilizar en el programa un método que no reciba parámetros y otro que sí lo haga.
namespace TareasParte1
{
    class Video10
    {
        static void Main(string[] args)
        {   
            // Se invoca el primer método para que imprima los mensajes con los ejemplos primitivos.
            ImprimirPrimitivos();

            int num1;
            int num2;

            // Se reciben en las variables num1 y num2 los valores que ingresa el usuario.
            Console.WriteLine("--------- M U L T I P L I C A C I Ó N ---------");
            Console.Write("Ingrese el primer factor: ");
            num1 = int.Parse(Console.ReadLine()!);
            Console.Write("Ingrese el segundo factor: ");
            num2 = int.Parse(Console.ReadLine()!);

            // Se invoca el método para realizar la multiplicación. Se pasan por parámetro las variables 
            // num1 y num2 obtenidas anteriormente.
            Multiplicacion(num1, num2);
        }

        static void ImprimirPrimitivos()
        {
            Console.WriteLine("Estos son 5 ejemplos de datos primitivos en C#: ");
            Console.WriteLine("ushort");
            Console.WriteLine("sbyte");
            Console.WriteLine("bool");
            Console.WriteLine("long");
            Console.WriteLine("float");
        }

        // Se definen los parámetros factor1 y factor2. A través de estos parámetros se realizan las 
        // operaciones en el método Multiplicación.
        static void Multiplicacion(int factor1, int factor2)
        {
            int resultado = factor1 * factor2;

            Console.WriteLine($"El resultado es {resultado}");
        }
    }
}