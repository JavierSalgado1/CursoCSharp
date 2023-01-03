using System;
// Realizar aplicación de consola que permita ir multiplicando de manera indefinida los números que el usuario le va entregando.
// Al momento de llegar a un desborde aritmético, el programa deberá indicarlo al usuario y terminar. Usar checked y filtros para 
// las excepciones.
namespace TareasParte1
{
    class Video24
    {
        static void Main(string[] args)
        {
            uint resultado = 1;
            uint factor = 0;

            Console.WriteLine("Ingrese números separados por líneas [Enter] para irlos multiplicando.");

            do
            {
                checked
                {
                    try
                    {
                        factor = uint.Parse(Console.ReadLine()!);
                        resultado = resultado * factor;

                        Console.Write($"{resultado} * ");
                    }
                    catch (Exception e) when (e.GetType() != typeof(OverflowException))
                    {
                        Console.WriteLine("Ha ocurrido una Excepción. Detalle: " + e.Message);
                        Console.WriteLine("Vuelva a intentar con otro valor.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Ha ocurrido una Excepción por desbordamiento; el programa terminará.");
                        // Con la siguiente asignación, la condición del while ya no se cumplirá, por lo que se saldrá del bucle.
                        resultado = 0;
                    }
                }                               
            }
            // Para que el bucle se repita de manera indefinida, se ingresa una condición que se sabe nunca dejará de cumplirse.
            while (resultado > 0);
        }
    }
}