using System;
// Realizar aplicación de consola que imprima distintos tipos de datos primitivos 
// por medio de variables.
namespace TareasSimples
{
    class Video4
    {
        static void Main(string[] args)
        {
            // Datos de tipo entero con signo (sólo números positivos):
            byte num1 = 255;
            ushort num2 = 65535;
            uint num3 = 4294967295;
            ulong num4 = 18446744073709551615;

            // Datos de tipo entero sin signo ();
            sbyte num5 = -128;
            short num6 = 32767;
            int num7 = -2147483648;
            long num8 = 9223372036854775807;

            // Datos de tipo reales
            // Se agrega el sufijo F a los datos float, ya que de otro modo, el compilador los interpreta como double por defecto.
            float num9 = 0.0001F;
            double num10 = -4.123456789012345;
            // Se agrega el sufijo M a los decimal, ya que de otro modo, el compilador los interpreta como double por defecto.
            decimal num11 = 1.1234567890123456789012345678M;

            // Booleano (puede tomar valor true o false solamente).
            bool estado = true;

            // Imprime por pantalla cada una de las variables, separadas por saltos de línea.
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);
            Console.WriteLine(num6);
            Console.WriteLine(num7);
            Console.WriteLine(num8);
            Console.WriteLine(num9);
            Console.WriteLine(num10);
            Console.WriteLine(num11);
            Console.WriteLine(estado);
        }
    }
}