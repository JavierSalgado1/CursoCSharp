using System;
// Realizar aplicación de consola que simule una alcancía. La alcancía tendrá como propiedad el dinero que almacena y podrá 
// permitir ingresar dinero a ella y también mostrar la cantidad actual. El usuario deberá indicar las cantidades a ingresar. 
// Utilizar encapsulación y realizar validaciones de ser necesario.
namespace TareasParte1
{
    class Video29
    {
        static void Main(string[] args)
        {
            // Se declara la variable respuesta como tipo char. El tipo char almacena solo un carácter, pero para igresarlo como texto, 
            // debemos ingresarlo entre comillas simples, y no en comillas dobles como se hace con los string.
            char respuesta = 'S';
            int dinero;
            Alcancia miAlcancia = new Alcancia();

            do
            {
                // Primero vemos la cantidad de dinero que posee actualmente la alcancía, que debiera ser 0 la primera vez.
                Console.WriteLine("Dinero contenido: " + miAlcancia.MostrarCantidad());

                Console.Write("Ingrese dinero a la alcancía: ");

                try
                {
                    dinero = int.Parse(Console.ReadLine()!);
                    miAlcancia.IngresarDinero(dinero);

                    Console.WriteLine("¿Desea ingresar más dinero? (S/N)");
                    respuesta = char.Parse(Console.ReadLine()!);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("La cantidad de dinero debe ser positiva... y caber en una alcancía.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Debe ingresar una cantidad numérica.");
                }             
            } 
            while (respuesta == 'S');
        }
    }

    class Alcancia
    {
        private int dinero = 0;

        public void IngresarDinero(int ingreso)
        {
            if (ingreso >= 0)
            {
                dinero = dinero + ingreso;
            }
            else
            {
                throw new OverflowException();
            }
        }

        public string MostrarCantidad()
        {
            return("Contengo en mi interior $" + dinero);
        }
    }
}