using System;
// Realizar aplicación de consola que pida al usuario que pida al usuario ingresar 3 números 
// enteros. La aplicación debe imprimir los resultados. Usar parseo.
namespace TareasSimples
{
    class Video7
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            int num3;
            int resultado;

            // El método Write de la clase Console trabaja exactamente igual que WriteLine, solo que 
            // no realiza un salto de línea después de imprimir el mensaje.
            Console.Write("Ingrese el primer número: "); 
            // Se agrega "!" luego de readline para indicar al compilador que el programa está preparado para recibir un valor 
            // nulo en la variable num1, y así evitar una advertencia por parte del compilador.   
            num1 = int.Parse(Console.ReadLine()!);   

            Console.Write("Ingrese el segundo número: ");
            num2 = int.Parse(Console.ReadLine()!); 

            Console.Write("Ingrese el tercer número: ");
            num3 = int.Parse(Console.ReadLine()!); 

            // Se asigna el valor de la operación en la variable resultado.
            resultado = num1 + num2 + num3;

            Console.WriteLine("---------------------------------");
            Console.WriteLine("El resultado es " + resultado);
            Console.WriteLine("---------------------------------");
        }
    }
}