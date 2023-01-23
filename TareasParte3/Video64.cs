// Realizar aplicación de consola que permita ingresar objetos de tipo Producto, los cuales tendrán un nombre y precio. Inmediatamente 
// se vayan ingresando los productos, estos se irán listando. Permitir al usuario elegir el número de la posición en la cuál alojar 
// cada producto luego de haber ingresado al menos 3. Utilizar LinkedList.
using System.Collections.Generic;

namespace TareasParte3
{
    class Video64
    {
        static void Main(string[] args)
        {
            Console.Clear();

            LinkedList<Producto> listaProductos = new LinkedList<Producto>();
            LinkedListNode<Producto> nodoProducto = null!;
            LinkedListNode<Producto> nodoReferencia = null!;
            byte contador = 1;
            byte contRef = 0;
            string nombreIngresado;
            uint precioIngresado;
            char eleccion = 'S';
            bool eleccionValida = false;
            byte posicion;
            bool posicionCorrecta = false;

            do
            {
                try
                {
                    Console.Write($"----- PRODUCTO #{contador} -----\nNombre: ");
                    nombreIngresado = Console.ReadLine()!;
                    Console.Write("Precio: ");
                    precioIngresado = uint.Parse(Console.ReadLine()!);

                    if(eleccion == 'S' && contador > 3)
                    {
                        do
                        {
                            try
                            {
                                posicionCorrecta = false;
                                ListarProductos(listaProductos);
                                Console.Write("Ingrese la posición en que desea agregar el nuevo producto: ");
                                posicion = byte.Parse(Console.ReadLine()!);
                                posicion -= 1;

                                if(posicion < 0 || posicion > listaProductos.Count) throw new Exception();

                                nodoProducto = new LinkedListNode<Producto>(new Producto(nombreIngresado, precioIngresado));

                                if(posicion == listaProductos.Count)
                                {
                                    listaProductos.AddLast(nodoProducto);
                                }
                                else
                                {
                                    for(LinkedListNode<Producto> productoRef = listaProductos.First!; contRef <= posicion; productoRef = productoRef.Next!)
                                    {
                                        nodoReferencia = productoRef;
                                        contRef++;
                                    }
                                    contRef = 0;

                                    listaProductos.AddBefore(nodoReferencia, nodoProducto);
                                }

                                posicionCorrecta = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"Debe ingresar un numero entre 1 y {contador}");
                            }
                        } 
                        while (!posicionCorrecta);
                    }
                    else
                    {
                        listaProductos.AddLast(new Producto(nombreIngresado, precioIngresado));
                    }
                    Console.Clear();

                    ListarProductos(listaProductos);

                    do
                    {
                        try
                        {
                            eleccionValida = false;
                            Console.WriteLine("¿Desea agregar un producto nuevo? (S/N)");
                            eleccion = char.Parse(Console.ReadLine()!.ToUpper());

                            if(eleccion != 'S' && eleccion != 'N') throw new Exception();
                            eleccionValida = true;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Debe ingresar una S o una N");
                        }
                    } 
                    while (!eleccionValida);
                    
                    Console.Clear();
                    contador++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            } 
            while (eleccion == 'S');
        }

        static void ListarProductos(LinkedList<Producto> lista)
        {
            byte contador = 1;
            Console.WriteLine("----- Lista de productos -----");

            foreach(Producto producto in lista)
            {
                Console.WriteLine($"{contador}) Nombre: {producto.Nombre}\t\tPrecio: ${producto.Precio}");
                contador++;
            }
        }
    }

    class Producto
    {
        private string nombre;
        private uint precio;

        public Producto(string nombre, uint precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }

        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = value;
        }

        public uint Precio
        {
            get => this.precio;
            set => this.precio = value;
        }
    }
}