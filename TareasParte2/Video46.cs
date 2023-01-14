// EJERCICIO PROPUESTO EN EL CURSO. Realizar aplicación de consola que simule las clases Avión, Vehículo y Coche. Estas clases tendrán 
// 3 métodos comunes: Arrancar Motor y Parar Motor. Además, contarán con el método virtual Conducir.
namespace TareasParte2
{
    class Video46
    {
        static void Main(string[] args)
        {
            byte respuestaContexto = 0;
            char respuestaBucle = 'S';
            bool finBucle = false;

            Console.Clear();

            do
            {
                try
                {
                    Console.WriteLine("¿Qué vehículo desea manejar?\n1) Coche\n2) Avión");
                    respuestaContexto = byte.Parse(Console.ReadLine()!);
                    finBucle = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Debe ingresar un 1 ó un 2.");
                }
            } 
            while (!finBucle);

            Console.Clear();
            Vehiculos miVehiculo = null!;
            finBucle = false;

            if (respuestaContexto == 1) 
            {
                miVehiculo = new Coche();
            }
            else 
            {
                miVehiculo = new Avion();
            }

            do
            {
                try
                {
                    Console.WriteLine("¿Qué acción desea realizar?\n1) Arrancar Motor\n2) Parar Motor\n3) Conducir");
                    respuestaContexto = byte.Parse(Console.ReadLine()!);

                    switch (respuestaContexto)
                    {
                        case 1:
                            miVehiculo.ArrancarMotor();
                            break;
                        case 2:
                            miVehiculo.PararMotor();
                            break;
                        case 3:
                            miVehiculo.Conducir();
                            break;
                        default:
                            throw new Exception();
                    }

                    do
                    {
                        try
                        {
                            Console.WriteLine("¿Desea realizar otra acción? (S/N)");
                            respuestaBucle = Char.Parse(Console.ReadLine()!);

                            if(respuestaBucle == 'S' || respuestaBucle == 'N') finBucle = true;
                            else throw new Exception();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Debe ingresar una S o una N.");
                            finBucle = false;
                        }
                    } 
                    while (!finBucle);
                }
                catch (Exception)
                {
                    Console.WriteLine("Debe ingresar un 1, un 2 ó un 3.");
                }
            } 
            while (respuestaBucle != 'N');
        }
    }

    class Vehiculos
    {
        protected bool motorEncendido;

        public Vehiculos()
        {
            this.motorEncendido = false;
        }

        public void ArrancarMotor()
        {
            if (!this.motorEncendido)
            {
                this.motorEncendido = true;
                Console.WriteLine("Has encendido el motor.");
            }
            else
            {
                Console.WriteLine("El motor ya está encendido.");
            }
        }

        public void PararMotor()
        {
            if (this.motorEncendido)
            {
                this.motorEncendido = false;
                Console.WriteLine("Has detenido el motor.");
            }
            else
            {
                Console.WriteLine("El motor ya está detenido.");
            }
        }

        public virtual void Conducir() {}
    }

    class Avion : Vehiculos
    {
        public Avion() : base() {}

        public override void Conducir()
        {
            if (this.motorEncendido) Console.WriteLine("Emprendiendo el vuelo.");
            else Console.WriteLine("Necesitas arrancar el motor para poder despegar.");
        }
    }

    class Coche : Vehiculos
    {
        public Coche() : base() {}

        public override void Conducir()
        {
            if (this.motorEncendido) Console.WriteLine("Acelerando por la calle.");
            else Console.WriteLine("Necesitas arrancar el motor para poder conducir.");
        }
    }
}