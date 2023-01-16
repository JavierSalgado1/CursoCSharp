// "Crear un programa que permita guardar datos de "imágenes" (ficheros de ordenador que contengan fotografías o cualquier otro tipo
// de información gráfica). De cada imagen se debe guardar: nombre (texto), ancho en píxeles (por ejemplo 2000), alto en píxeles (por 
// ejemplo, 3000), tamaño en Kb (por ejemplo 145,6). El programa debe ser capaz de almacenar hasta 700 imágenes (deberá avisar cuando 
// su capacidad esté llena). Debe permitir las opciones: añadir una ficha nueva, ver todas las fichas (número y nombre de cada imagen), 
// buscar la ficha que tenga un cierto nombre."
// FUENTE DEL EJERCICIO: https://www.nachocabanes.com/csharp/curso2015/csharp04c.php ... Ejercicio propuesto 4.3.2.2.
namespace TareasParte2
{
    class Video57
    {
        static void Main(string[] args)
        {
            Console.Clear();

            byte opcion;
            ushort contadorImagenes = 0;
            bool finPrograma = false;
            Imagen[] imagenes = new Imagen[700];

            do
            {
                try
                {
                    Console.WriteLine("Escoja una de las siguientes opciones: ");
                    Console.Write("1) Añadir una imagen.\n2) Ver todas las imágenes.\n3) Buscar imagen por nombre.\n4) Salir del programa.\n");
                    opcion = byte.Parse(Console.ReadLine()!);

                    switch (opcion)
                    {
                        case 1:
                            imagenes[contadorImagenes] = AgregarImagen();
                            Console.WriteLine("Imagen agregada con éxito.");
                            contadorImagenes++;
                            break;
                        case 2:
                            ListarImagenes(imagenes, contadorImagenes);
                            break;
                        case 3:
                            BuscarImagen(imagenes, contadorImagenes);
                            break;
                        case 4:
                            finPrograma = true;
                            break;
                        // Truco para rellenar el Array automáticamente con 700 elementos.
                        case 255:
                            Console.WriteLine("Has ingresado el código secreto. Se está llenando el array con 700 elementos.");
                            for(ushort i = 0; i < 700; i++)
                            {
                                imagenes[contadorImagenes] = new Imagen(GeneraNombreAutomatico(), 100, 100, 66.6F);
                                contadorImagenes++;
                            }
                            Console.WriteLine("Se han terminado de generar las imágenes.");
                            Console.WriteLine("Pulse [Enter] para continuar...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        default:
                            throw new Exception();
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("* No se pudo agregar la imagen ya que no queda más espacio. *");
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("* Debe ingresar un 1, un 2, un 3 ó un 4. *");
                }
            } 
            while (!finPrograma);
        }

        static Imagen AgregarImagen()
        {
            Console.Clear();
            bool imagenCreada = false;
            string nombre = ".jpg";
            ushort ancho = 0;
            ushort alto = 0;
            float tamaño = 0;

            do
            {
                try
                {
                    Console.WriteLine("----- NUEVA IMAGEN -----");
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine()! + ".jpg";
                    Console.Write("Ancho: ");
                    ancho = ushort.Parse(Console.ReadLine()!);
                    Console.Write("Alto: ");
                    alto = ushort.Parse(Console.ReadLine()!);
                    Console.Write("Tamaño: ");
                    tamaño = float.Parse(Console.ReadLine()!);

                    imagenCreada = true;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            } 
            while (!imagenCreada);

            Console.Clear();
            return new Imagen(nombre, ancho, alto, tamaño);
        }

        static void ListarImagenes(Imagen[] imagenes, ushort contadorImagenes)
        {
            Console.Clear();

            if (contadorImagenes == 0)
            {
                Console.WriteLine("Aún no ha almacenado ninguna imagen.");
            }
            else
            {
                for(ushort i = 0; i < contadorImagenes; i++)
                {
                    Console.WriteLine(imagenes[i].ToString());
                }
            }

            Console.WriteLine("Pulse [Enter] para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        static void BuscarImagen(Imagen[] imagenes, ushort contadorImagenes)
        {
            Console.Clear();

            string imagenABuscar;
            ushort numeroCoincidencias = 0;
            bool nombreIngresado = false;

            

            if (contadorImagenes == 0)
            {
                Console.WriteLine("Aún no ha almacenado ninguna imagen.");
            }
            else
            {
                do
                {
                    imagenABuscar = "";
                    Console.WriteLine("Ingrese el nombre de la imagen a buscar: ");
                    imagenABuscar = Console.ReadLine() + ".jpg";

                    if(String.Compare(imagenABuscar.Trim(), ".jpg") == 0) Console.WriteLine("Debe ingresar texto para poder realizar la búsqueda.");
                    else nombreIngresado = true;
                } 
                while (!nombreIngresado);

                for(ushort i = 0; i < contadorImagenes; i++)
                {
                    if (String.Compare(imagenABuscar, imagenes[i].GetNombre(), false) == 0)
                    {
                        if (numeroCoincidencias == 0) Console.WriteLine("Resultados de la búsqueda: ");

                        Console.WriteLine(imagenes[i].ToString());
                        numeroCoincidencias++;
                    }
                }

                if (numeroCoincidencias == 0) Console.WriteLine("No se encontraron coincidencias.");
            }

            Console.WriteLine("Pulse [Enter] para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        static string GeneraNombreAutomatico()
        {
            string cadena = "";
            char nuevoCaracter;
            byte longitud = 6;
            Random rnd = new Random();

            while (cadena.Length != longitud)
            {
                // Utilizando el método Next de la clase Random, obtenemos un número aleatorio entre los valores ingresados por parámetro, 
                // en este caso, 97 y 122. Estos valores se corresponden a los códigos numéricos que representan los caracteres de las 
                // letras desde la 'a' hasta la 'z' en minúsculas. Una vez se obtiene una de estas letras, se agrega a la cadena hasta 
                // alcanzar los 6 caracteres.
                nuevoCaracter = (char)rnd.Next(97, 122);
                cadena += nuevoCaracter;
            }

            return cadena.ToString() + ".jpg";
        }
    }

    struct Imagen
    {
        private static ushort contador = 0;
        private ushort id;
        private string nombre;
        private ushort ancho;
        private ushort alto;
        private float tamaño;

        public Imagen(string nombre, ushort ancho, ushort alto, float tamaño)
        {
            this.nombre = nombre;
            this.ancho = ancho;
            this.alto = alto;
            this.tamaño = tamaño;
            contador++;
            this.id = contador;
        }

        // Se agrega override ya que ToString es un método heredado de la clase Object.
        public override string ToString()
        {
            return $"{id} ... {this.nombre}";
        }

        public string GetNombre() => this.nombre;
    }
}