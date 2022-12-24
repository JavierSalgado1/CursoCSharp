using System;
// Realizar aplicación de consola que imprima el valor del número de E (eule), y luego, que calcule e imprima 
// el valor del logaritmo natural de E.
// PISTA: Revisar en internet la documentación de la clase Math si es necesario.
namespace TareasSimples
{
    class Video8
    {
        static void Main(string[] args)
        {
            double resultado;
            // Se imprime el valor de la constante E predefinida en la clase Math
            Console.WriteLine("Número de E: " + Math.E);

            // Se utiliza el método Log de la clase Math, que devuelve el logaritmo natural del número indicado, 
            // que en este caso, es la constante E.
            resultado = Math.Log(Math.E);

            Console.WriteLine("El logaritmo natural de E: " + resultado);
        }
    }
}