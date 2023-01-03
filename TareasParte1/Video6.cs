using System;
// Realizar aplicación de consola en que se definan valores de coma flotante y se impriman como 
// enteros, truncando la parte decimal. Utilizar conversiones.
namespace TareasParte1
{
    class Video6
    {
        static void Main(string[] args)
        {
            double num1 = 333.4324;
            double num2 = 0.0012303;

            // Se realiza una conversión explícita de double a int, y debido a la pérdida de 
            // información, elimina los decimales de los valores.
            Console.WriteLine("El primer número truncado es: " + (int)num1);
            Console.WriteLine($"El segundo número truncado es: {(int)num2}");
        }
    }
}