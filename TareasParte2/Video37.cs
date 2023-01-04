// Realizar aplicación de consola que permita al usuario agregar 5 libros, los cuales tendrán un título, autor, número de páginas y precio. 
// Finalmente, una vez creados todos los libros, se deberá dar la opción de aplicar un porcentaje de descuento a alguno de estos libros.
// Utilizar un Array de objetos para almacenar los libros.
namespace TareasParte2
{
    class Video37
    {
        static void Main(string[] args)
        {
            string titulo;
            string autor;
            ushort nPaginas;
            uint precio;
            Libro[] libros = new Libro[5];
            byte contador = 0;

            do
            {
                 try
                {
                    Console.Write($"------------ NUEVO LIBRO ({contador+1})------------\nIngresa el título: ");
                    titulo = Console.ReadLine()!;
                    Console.Write("Ingresa el autor: ");
                    autor = Console.ReadLine()!;
                    Console.Write("Ingresa el número de páginas: ");
                    nPaginas = ushort.Parse(Console.ReadLine()!);
                    Console.Write("Ingresa el precio: $");
                    precio = uint.Parse(Console.ReadLine()!);

                    libros[contador] = new Libro(titulo, autor, nPaginas, precio);
                    contador ++;
                }
                catch (Exception e)
                {
                Console.WriteLine(e.Message);
                }
            }
            while (contador <= 4);

            contador = 0;
            Console.Clear();

            while (contador <=4)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Libro: {libros[contador].GetTitulo()}\nAutor: {libros[contador].GetAutor()}\nNúmero de páginas: {libros[contador].GetNPaginas()}\nPrecio: ${libros[contador].GetPrecio()}.");
                Console.WriteLine("----------------------------------");
                contador++;
            }
                       
            char respuesta;
            bool fin = false;
            bool finBucleInterno = false;
            bool finUltimoBucle = false;

            do
            {
                try
                {
                    Console.Write("¿Desea aplicar descuento a algún libro? (S/N)");
                    respuesta = char.Parse(Console.ReadLine()!);

                    switch (respuesta)
                    {
                        case 'S':                          
                            double descuento;
                            byte numeroLibro;
                            do
                            {
                                try
                                {
                                    Console.Write("Ingrese el porcentaje de descuento que desea aplicar: ");
                                    descuento = double.Parse(Console.ReadLine()!);
                                    finBucleInterno = true;
                                    do
                                    {
                                        try
                                        {
                                            Console.WriteLine("Ingrese el número del libro al que quiere aplicar el descuento: ");
                                            Console.WriteLine($"1) {libros[0].GetTitulo()}");
                                            Console.WriteLine($"2) {libros[1].GetTitulo()}");
                                            Console.WriteLine($"3) {libros[2].GetTitulo()}");
                                            Console.WriteLine($"4) {libros[3].GetTitulo()}");
                                            Console.WriteLine($"5) {libros[4].GetTitulo()}");
                                            numeroLibro = byte.Parse(Console.ReadLine()!);

                                            if (numeroLibro >= 1 && numeroLibro <= 5)
                                            {
                                                libros[numeroLibro-1].AplicarDescuento(descuento);
                                                Console.WriteLine("------------ LIBRO CON DESCUENTO ------------");
                                                Console.WriteLine($"Libro: {libros[numeroLibro-1].GetTitulo()}\nAutor: {libros[numeroLibro-1].GetAutor()}\nNúmero de páginas: {libros[numeroLibro-1].GetNPaginas()}\nPrecio: ${libros[numeroLibro-1].GetPrecio()}.");
                                                finUltimoBucle = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("El número debe encontrarse entre 0 y 100.");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(e.Message);
                                        }
                                    } while (!finUltimoBucle);
                                }
                                catch (Exception)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Debe ingresar un número entero o decimal entre 0 y 100.");
                                }
                            } 
                            while (!finBucleInterno);
                            fin = true;
                            break;
                        case 'N':
                            fin = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una S o una N.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!fin);

            Console.WriteLine("Fin del programa.");
        }
    }

    class Libro 
    {
        private string titulo;
        private string autor;
        private ushort nPaginas;
        private uint precio;

        public Libro(string titulo, string autor, ushort nPaginas, uint precio)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.nPaginas = nPaginas;
            this.precio = precio;
        }
        
        public string GetTitulo() => this.titulo;
        public string GetAutor() => this.autor;
        public ushort GetNPaginas() => this.nPaginas;
        public uint GetPrecio() => this.precio;

        public void AplicarDescuento(double descuento)
        {
            descuento = (100 - descuento) * 0.01;
            this.precio = (uint)(this.precio * descuento);
        }
    }
}