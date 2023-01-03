using System;
// Realizar aplicación de consola que simule un autobús. Un autobús tendrá número de asientos, número de asientos ocupados, y velocidad 
// a la que viaja. Además, podrá subir pasajeros, bajar pasajeros y establecer una velocidad. Utilizar getters y setters. 
// Dividir la clase autobús entre sus contructores / propiedades y los métodos. Aplicar validaciones si se considera necesario.
// Las acciones a realizar por el bus se deberán ingresar por consola.
namespace TareasParte1
{
    class Video31
    {
        static void Main(string[] args)
        {
            char respuesta = 'S';
            byte accion;

            // Se inicia con parámetros personalizados. También podría hacerse con los parámetros por defecto, pero durante el 
            // transcurso del programa no se podrá modificar el número de asientos ya que no existe un método setter para ello.
            Autobus bus = new Autobus(45, 0, 0);

            do
            {
                Console.WriteLine("Elija una acción a realizar ingresando el número correspondiente: ");
                Console.WriteLine("1) Establecer una velocidad.");
                Console.WriteLine("2) Subir pasajeros.");
                Console.WriteLine("3) Bajar pasajeros.");
                Console.WriteLine("4) Revisar estado del bus.");

                try
                {
                    accion = byte.Parse(Console.ReadLine()!);

                    // El método Clear de la clase Console limpia la información de la consola.
                    Console.Clear();

                    switch (accion)
                    {
                        case 1:
                            Console.Write("Ingrese la velocidad del bus: ");
                            byte velocidadIngresada = byte.Parse(Console.ReadLine()!);
                            bus.SetVelocidad(velocidadIngresada);                           
                            break;
                        case 2:
                            Console.Write("Ingrese la cantidad de pasajeros que subirán: ");
                            byte pasajerosParaSubir = byte.Parse(Console.ReadLine()!);
                            bus.SubirPasajeros(pasajerosParaSubir);
                            break;
                        case 3:
                            Console.Write("Ingrese la cantidad de pasajeros que bajarán: ");
                            byte pasajerosParaBajar = byte.Parse(Console.ReadLine()!);
                            bus.BajarPasajeros(pasajerosParaBajar);
                            break;
                        case 4:
                            Console.WriteLine($"--- ESTADO DEL BUS ---\nNúmero de Asientos: {bus.GetNumAsientos()}\nAsientos ocupados: {bus.GetNumAsientosOcupados()}");
                            Console.WriteLine($"Velocidad actual: {bus.GetVelocidad()} km/h.\n-----------------------");
                            break;
                        default:
                            Console.WriteLine("Ingrese un número de opción válida.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
                
                Console.WriteLine("Ingrese una 'S' si desea continuar.");
                respuesta = char.Parse(Console.ReadLine()!);
            }
            while (respuesta == 'S');
        }
    }

    partial class Autobus
    {
        private byte numAsientos;
        private byte numAsientosOcupados;
        private byte velocidad;

        public Autobus()
        {
            numAsientos = 35;
            numAsientosOcupados = 0;
            velocidad = 0;
        }

        public Autobus(byte numAsientos, byte numAsientosOcupados, byte velocidad)
        {
            this.numAsientos = numAsientos;
            this.numAsientosOcupados = numAsientosOcupados;
            this.velocidad = velocidad;
        }
    }

    partial class Autobus
    {
        public void SubirPasajeros(byte pasajeros)
        {
            if(velocidad == 0)
            {
                if (numAsientosOcupados + pasajeros <= numAsientos)
                {
                    numAsientosOcupados = (byte)(numAsientosOcupados + pasajeros);
                }
                else
                {
                    Console.WriteLine("No quedan suficientes asientos para esta cantidad de pasajeros.");
                }
            }
            else
            {
                Console.WriteLine("El autobús debe estar detenido para subir o bajar pasajeros.");
            }
            
        }

        public void BajarPasajeros(byte pasajeros)
        {
            if (velocidad == 0)
            {
                if(numAsientosOcupados - pasajeros > 0)
                {
                    numAsientosOcupados = (byte)(numAsientosOcupados - pasajeros);
                }
                else
                {
                    Console.WriteLine("No hay tantas personas dentro del autobús.");
                }
            }
            else
            {
                Console.WriteLine("El autobús debe estar detenido para subir o bajar pasajeros.");
            }
            
        }

        public byte GetNumAsientos()
        {
            return this.numAsientos;
        }

        public byte GetNumAsientosOcupados()
        {
            return this.numAsientosOcupados;
        }

        public byte GetVelocidad()
        {
            return this.velocidad;
        }

        public void SetVelocidad(byte velocidad)
        {
            if(velocidad <= 120)
            {
                this.velocidad = velocidad;
            }
            else
            {
                Console.WriteLine("Este bus no puede correr a más de 120 km/h.");
            }
        }
    }
}