using System;
// Realizar aplicación de consola que pida al usuario ingresar la una cantidad de números a revisar. La cantidad de números a revisar 
// serán pedidos por al usuario, y de estos, el programa deberá decir cuántos fueron menores que 100, cuántos entre 100 y 1000 y 
// cuántos mayores que 1000. Utilizar bucle do While.
namespace TareasParte1
{
    class Video21
    {
        static void Main(string[] args)
        {
            byte contador = 1;
            uint numIngresado = 0;
            byte contMenores = 0;
            byte contMedios = 0;
            byte contMayores = 0;

            Console.Write("Ingresa la cantidad de números a revisar: ");
            byte cantidad = byte.Parse(Console.ReadLine()!);
            Console.WriteLine("------------------------------------------");

            do
            {
                Console.Write($"Ingrese el {contador}° número: ");
                numIngresado = uint.Parse(Console.ReadLine()!);
                
                contador++;

                if (numIngresado < 100) contMenores++;
                else if(numIngresado >= 100 && numIngresado <= 1000) contMedios++;
                else contMayores++;
            }
            while(contador <= cantidad);

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Cantidad de números menores que 100: {contMenores}");
            Console.WriteLine($"Cantidad de números entre 100 y 1000: {contMedios}");
            Console.WriteLine($"Cantidad de números mayores que 1000: {contMayores}");
        }
    }
}