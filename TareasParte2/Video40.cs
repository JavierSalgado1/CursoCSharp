// Realizar aplicación de consola que cree productos predefinidos, los cuales tendrán un nombre, un tipo y un stock y precios inicializados 
// en 0. El programa deberá permitir al usuario ingresar el stock y precio para todos estos productos y luego listarlos. Utilizar paso 
// de Array por parámetros de un método.
namespace TareasParte2
{
    class Video40
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Producto[] listaProductos = new Producto[5];

            listaProductos[0] = new Producto("B.C. Rich Bich 10", "Guitarra");
            listaProductos[1] = new Producto("Jackson Randy Rhoads XMG", "Guitarra");
            listaProductos[2] = new Producto("B.C. Rich Wave", "Bajo");
            listaProductos[3] = new Producto("B.C. Rich Mocking Bird MK7", "Guitarra");
            listaProductos[4] = new Producto("Taladro Bauker con Percutor Reversible y Mandril de 10", "Con CMR");

            listaProductos = IngresarValoresProductos(listaProductos);

            ListarProductos(listaProductos);
        }

        static Producto[] IngresarValoresProductos(Producto[] listaProductos)
        {
            ushort stockIngresado;
            uint precioIngresado;
            byte contador = 1;

            for(byte i = 0; i < (byte)listaProductos.Length; i++)
            {
                try
                {
                    Console.WriteLine($"----- Producto {contador} -----");
                    Console.Write($"Nombre: {listaProductos[i].GetNombre()}\nTipo: {listaProductos[i].GetTipo()}\nStock: ");
                    stockIngresado = ushort.Parse(Console.ReadLine()!);
                    Console.Write("Precio: ");
                    precioIngresado = uint.Parse(Console.ReadLine()!);

                    listaProductos[i].SetStock(stockIngresado);
                    listaProductos[i].SetPrecio(precioIngresado);

                    contador++;
                    Console.Clear();
                }
                catch(FormatException)
                {
                    Console.WriteLine("Debe ingresar sólo números.");
                    i--;
                }
                catch(OverflowException)
                {
                    Console.WriteLine("El número debe ser positivo y no tan grande.");
                    i--;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }
            return listaProductos;
        }

        static void ListarProductos(Producto[] lista)
        {
            byte contador = 1;

            foreach(Producto producto in lista)
            {
                Console.WriteLine($"-------- P R O D U C T O {contador} --------");
                Console.WriteLine($"Nombre: {producto.GetNombre()}\nTipo: {producto.GetTipo()}\nStock: {producto.GetStock()}\nPrecio: ${producto.GetPrecio()}");
                Console.WriteLine("-----------------------------------");
                contador++;
            }
        }
    }

    class Producto
    {
        private string nombre;
        private string tipo;
        private ushort stock;
        private uint precio;

        public Producto(string nombre, string tipo)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            SetStock(0);
            SetPrecio(0);
        }

        public void SetStock(ushort stock)
        {
            this.stock = stock;
        }
        
        public void SetPrecio(uint precio)
        {
            this.precio = precio;
        }

        public string GetNombre() => this.nombre;
        public string GetTipo() => this.tipo;
        public ushort GetStock() => this.stock;
        public uint GetPrecio() => this.precio;
    }
}