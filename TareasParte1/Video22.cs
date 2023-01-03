using System;
// Realizar una aplicación de consola que pida ingresar números de manera indefinida. Estos deben ser guardados en una variable 
// de tipo ushort, y debe advertir al usuario cuándo se ingrese un número que provoque desbordamiento (número de mayor a la 
// capacidad del tipo de dato), y luego continuar con el bucle hasta que el usuario indique lo contrario.
namespace TareasParte1
{
    class Video22
    {
        static void Main(string[] args)
        {
            string respuesta = "No";
            ushort numero;

            do
            {
                try
                {
                    Console.Write("Ingrese un número: ");
                    numero = ushort.Parse(Console.ReadLine()!);  
                }
                // Si bien se suele colocar "ex", "e" u algún otro nombre luego del tipo de excepción, no es necesario en este caso.
                // OverflowException es la excepción que ocurre cuando se sobrepasa el límite de lo que puede contener un tipo de 
                // dato numérico.
                catch(OverflowException)
                {
                    Console.WriteLine("*Ha ocurrido un error de desbordamiento, los números igresados deben encontrarse entre 0 y 65.535*");
                }
        
                Console.WriteLine("¿Deseas ingresar otro? (S/N)");
                respuesta = Console.ReadLine()!;   
            }
            // Se define que el bucle se repita mientras que la respuesta sea "S" (Sí) en mayúsculas (dado el parámetro de case 
            // sensitive en falso). El método Compare de la clase String retorna 0 cuando lo comparado entre el primer y segundo 
            // parámetro es igual.
            while(String.Compare(respuesta, "S", false) == 0);

            Console.WriteLine("----- Fin del Programa -----");
        }
    }
}