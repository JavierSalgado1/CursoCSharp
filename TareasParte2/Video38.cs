// Realizar aplicación de consola que consulte cuántas Películas se querrán ingresar a un catálogo (máximo 15). Las películas deberán poseer un nombre 
// y un autor. Una vez ingresados los datos de las películas, se deberá desplegar una lista de sus nombres con sus autores.
namespace TareasParte2
{
    class Video38
    {
        static void Main(string[] args)
        {
            bool paseIngresoPeliculas = false;
            byte numPeliculas = 0;

            do
            {
                try
                {
                    Console.Write("Ingrese la cantidad de Películas que desea ingresar: ");
                    numPeliculas = byte.Parse(Console.ReadLine()!);

                    if (numPeliculas >= 1 && numPeliculas <= 15)
                    {
                        paseIngresoPeliculas = true;
                    }
                    else
                    {
                        throw new OverflowException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Debe ingresar un número entero.");
                }
                catch(OverflowException)
                {
                    Console.WriteLine("El número debe encontrarse entre el 1 y el 15.");
                }
            }
            while (!paseIngresoPeliculas);
            
            Console.Clear();

            Pelicula[] peliculas = new Pelicula[numPeliculas];
            string nombrePeli;
            string directorPeli;

            for(byte i = 0; i < numPeliculas; i++)
            {
                try
                {
                    Console.WriteLine($"----- Película {i+1} -----");
                    Console.WriteLine("Ingrese el nombre de la película: ");
                    nombrePeli = Console.ReadLine()!;
                    Console.WriteLine("Ingrese el nombre del director: ");
                    directorPeli = Console.ReadLine()!;

                    peliculas[i] = new Pelicula(nombrePeli, directorPeli);
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }                         
            }

            Console.WriteLine("Lista de Películas:");

            for (byte i = 0; i < numPeliculas; i++)
            {
                // Se utiliza \" para poder insertar comillas dobles dentro de una cadena de caracteres.
                Console.WriteLine($"{i+1} \"{peliculas[i].GetNombre()}\" de {peliculas[i].GetDirector()}.");
            }
        }
    }

    class Pelicula
    {
        private string nombre;
        private string director;

        public Pelicula(string nombre, string director)
        {
            this.nombre = nombre;
            this.director = director;
        }

        public string GetNombre() => this.nombre;
        public string GetDirector() => this.director;

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void SetDirector(string director)
        {
            this.director = director;
        }
    }
}