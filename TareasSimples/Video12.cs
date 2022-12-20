using System;
// Realizar una aplicación de consola que permita mutiplicar 3 números y elevar a uno a x potencia
// utilizando sobrecarga de métodos.
namespace TareasSimples
{
    class Video12
    {
        static void Main(String[] args)
        {
            ushort num1;
            ushort num2;
            ushort num3;

            Console.WriteLine("------ M U L T I P L I C A C I Ó N ------");

            Console.Write("Primer factor: ");
            num1 = ushort.Parse(Console.ReadLine()!);

            Console.Write("Segundo factor: ");
            num2 = ushort.Parse(Console.ReadLine()!);

            Console.Write("Tercer factor: ");
            num3 = ushort.Parse(Console.ReadLine()!);

            Console.WriteLine($"{num1} x {num2} x {num3} = " + Operacion(num1, num2, num3));

            Console.WriteLine("------ P O T E N C I A ------");

            Console.Write("Ingrese la base: ");
            num1 = ushort.Parse(Console.ReadLine()!);

            Console.Write("Ingrese el exponente: ");
            num2 = ushort.Parse(Console.ReadLine()!);
            
            Console.WriteLine($"{num1} ^ {num2} = " + Operacion(num1, num2));
        }

        static uint Operacion(ushort num1, ushort num2)
        {
            uint resultado = (uint)Math.Pow(num1, num2);
            return resultado;
        }

        static uint Operacion(uint num1, uint num2, uint num3)
        {
            uint resultado = num1 * num2 * num3;
            return resultado;
        }
    }
}