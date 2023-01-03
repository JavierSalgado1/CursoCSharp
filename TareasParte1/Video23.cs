using System;
// Realizar aplicación de consola que pida dos números al usuario para dividirlos. Se debe usar bloque Try Catch y lograr, mediante 
// pruebas, imprimir el mensaje de al menos 3 tipos de excepciones distintas. Puedes modificar ligeramente el código para obtener 
// más excepciones. PISTA: De ser necesario, revisar documentación de las distintas excepciones en C#.
namespace TareasParte1
{
    class Video23
    {
        static void Main(string[] args)
        {
            double resultado = 0;

            try
            {
                Console.WriteLine("----- D I V I S I Ó N -----");
                Console.Write("Ingrese el primer número: ");
                // Si intentas guardar en esta variable un texto podrías obtener un FormatException.
                // También podrías ingresar un número mayor a lo permitido por int, y obtener una OverflowException.
                int num1 = int.Parse(Console.ReadLine()!);

                Console.Write("Ingrese el segundo número: ");
                int num2 = int.Parse(Console.ReadLine()!);
            
                // Si no realizas las conversiones a double, podrías ingresar un 0 en num2 y obtener la excepción 
                // DivideByZeroException.
                //resultado = num1 / num2;
                resultado = (double)num1 / (double)num2;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Resultado: " + resultado);
        }
    }
}