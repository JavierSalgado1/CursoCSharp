using System;
// Realizar aplicación de consola que ordene de mayor a menor 2 o 3 números decimales dados. Probar con números distintos de 0 
// y que no se repitan.
namespace TareasSimples
{
    class Video14
    {
        static void Main(string[] args)
        {
            // Se agrega el sufijo F a los decimales, ya que de otro modo, el compilador los interpreta como double por defecto.
            float num1 = 0.003003F;
            float num2 = 0.003F;
            float num3 = 0.3003F;

            Console.WriteLine(OrdenaMayorAMenor(num1, num2, num3));

            // Puedes probar ingresando solo dos números como parámetros, ya que el tercero es opcional.
            // Console.WriteLine(OrdenaMayorAMenor(num1, num2));
        }

        static string OrdenaMayorAMenor(float num1, float num2, float num3 = -1)
        {
            // El algoritmo utilizado en este método puede ser notablemente simplificado con el uso de "else", que se verá
            // prontamente en el curso.
            string cadenaOrdenada = "";

            if (num1 > num2)
            {
                cadenaOrdenada = $"{num1} > {num2}";

                if(num3 == -1)
                {
                    return cadenaOrdenada;
                }

                if (num3 < num2)
                {
                    return cadenaOrdenada + $" > {num3}";
                }

                if (num3 > num1)
                {
                    return $"{num3} > " + cadenaOrdenada;
                }

                return $"{num1} > {num3} > {num2}";
            }

            cadenaOrdenada = $"{num2} > {num1}";

            if(num3 == -1)
            {
                return cadenaOrdenada;
            }

            if (num3 < num1)
            {
                return cadenaOrdenada + $" > {num3}";
            }

            if (num3 > num2)
            {
                return $"{num3} > " + cadenaOrdenada;
            }

            return $"{num2} > {num3} > {num1}";
        }
    }
}