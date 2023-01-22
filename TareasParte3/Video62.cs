// Realizar aplicación de consola que, a través de una clase genérica, permita crear objetos de tipo Persona y de tipo Mascota. El usuario
// deberá poder almacenar 5 personas o mascotas, según elija al iniciar el programa. La clase genérica deberá permitir, además de 
// guardar los nuevos elementos, modificar el nombre de un elemento a elección. Debe también imprimir la información de todos los objetos 
// agregados. Aplicar alguna restricción.
namespace TareasParte3
{
    class Video62
    {
        static void Main(string[] args)
        {
            Console.Clear();

            byte eleccionObjeto = 0;
            bool objetoYaEscogido = false;

            do
            {
                try
                {
                    Console.WriteLine("¿De qué quiere llenar la lista?\n1) Personas\n2) Animales.");
                    eleccionObjeto = byte.Parse(Console.ReadLine()!);

                    if(eleccionObjeto < 1 || eleccionObjeto > 2) throw new Exception();
                    objetoYaEscogido = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un 1 ó un 2.");
                }
            }
            while (!objetoYaEscogido);

            Console.Clear();
            string nombreIngresado;

            ListaGenerica<Individuo> miLista = new ListaGenerica<Individuo>(5);

            for(byte i = 0; i < 5; i++)
            {
                try
                {
                    if(eleccionObjeto == 1)
                    {
                        Console.Write($"----- Persona {i+1} -----\nNombre: ");
                        nombreIngresado = Console.ReadLine()!;
                        byte edadIngresada;
                        Console.Write("Edad: ");
                        edadIngresada = byte.Parse(Console.ReadLine()!);

                        miLista.Agregar(new Persona(nombreIngresado, edadIngresada));
                    }
                    else
                    {
                        Console.Write($"----- Mascota {i+1} -----\nNombre: ");
                        nombreIngresado = Console.ReadLine()!;
                        string tipoIngresado;
                        Console.Write("Tipo: ");
                        tipoIngresado = Console.ReadLine()!;

                        miLista.Agregar(new Mascota(nombreIngresado, tipoIngresado));
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    i--;
                }
            }
                
            byte accion = 0;
            bool accionYaEscogida = false;
            Console.Clear();

            do
            {
                try
                {
                    Console.WriteLine("--------------------------------------------------\nEsta es la lista completa de elementos.");
                    Console.WriteLine("Si desea modificar algún nombre, ingrese el número correspondiente. Sino, ingrese 0");
                    for(byte i = 0; i < 5; i++)
                    {
                        Console.WriteLine(miLista.GetElemento(i).ImprimirInformacion(i));
                    }
                    accion = byte.Parse(Console.ReadLine()!);

                    if(accion < 0 || accion > 5) throw new Exception();

                    switch (accion)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Fin del Programa.");
                            accionYaEscogida = true;
                            break;
                        default:
                            Console.Clear();
                            Console.Write($"----- Registro #{accion} -----\nNombre: ");
                            nombreIngresado = Console.ReadLine()!;
                            accion -= 1;
                            miLista.GetElemento(accion).NOMBRE = nombreIngresado;
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un número del 0 al 5.");
                }
            } 
            while (!accionYaEscogida);
        }

        class ListaGenerica<T> where T : Individuo
        {
            private byte i = 0;
            private T[] lista;

            public ListaGenerica(byte numElementos)
            {
                lista = new T[numElementos];
            }

            public void Agregar(T objeto)
            {
                lista[i] = objeto;
                i++;
            }

            public T GetElemento(byte index) => lista[index];
        }

        class Individuo
        {
            private string nombre;

            public Individuo(string nombre)
            {
                this.nombre = nombre;
            }

            public virtual string ImprimirInformacion(byte index)
            {
                return $"Me llamo {nombre}";
            }

            public string NOMBRE
            {
                get => this.nombre;
                set => this.nombre = value;
            }
        }

        class Persona : Individuo
        {
            private byte edad;

            public Persona(string nombre, byte edad) : base(nombre)
            {
                this.edad = edad;
            }

            public override string ImprimirInformacion(byte index)
            {
                return $"--- PERSONA #{index+1} ---\nNombre: {NOMBRE}\nEdad: {edad}";
            }

            public byte EDAD
            {
                get => this.edad;
                set => this.edad = value;
            }
        }

        class Mascota : Individuo
        {
            private string tipo;

            public Mascota(string nombre, string tipo) : base(nombre)
            {
                this.tipo = tipo;
            }

            public override string ImprimirInformacion(byte index)
            {
                return $"--- MASCOTA #{index+1} ---\nNombre: {NOMBRE}\nTipo: {tipo}";
            }

            public string TIPO
            {
                get => this.tipo;
                set => this.tipo = value;
            }
        }
    }
}