// Realizar aplicación de consola que permita al usuario ingresar 5 vehículos. Estos vehículos podrán ser Motocicletas, automóviles o 
// buses, y cada uno de estos deberán ser representados por clases diferentes. Para los 5 vehículos que el usuario elija ingresar en 
// cada caso, deberá indicar la patente del vehículo, y finalmente listarlas e indicar el tipo de vehículo al que corresponda. 
// Utilizar principio de sustitución. PISTAS: Recordar uso del método GetType e investigar método Replace y sus usos.
namespace TareasParte2
{
    class Video44
    {
        static void Main(string[] args)
        {
            byte contadorVehiculos = 0;
            char eleccion;
            string patenteIngresada;

            Vehiculo[] vehiculos = new Vehiculo[5];

            Console.Clear();

            do
            {
                try
                {
                    Console.WriteLine($"¿Cuál es el {contadorVehiculos + 1}° vehículo que desea ingresar?");
                    Console.WriteLine("1) Motocicleta\n2) Automóvil\n3) Bus");
                    eleccion = char.Parse(Console.ReadLine()!);

                    if (eleccion != '1' && eleccion != '2' && eleccion != '3')
                    {
                        Console.WriteLine("* ----- Debe elegir una opción válida (1, 2 ó 3). ----- *");
                        // La instrucción continue permite seguir inmediatamente desde la próxima iteración del bucle.
                        continue;
                    }

                    Console.Write("\nIngrese la patente para el vehículo: ");
                    patenteIngresada = Console.ReadLine()!;

                    // El método Trim de la clase String permite remover los espacios en blanco de una cadena de caracteres. De esta forma, 
                    // podemos evitar que el usuario ingrese uno o más espacios en blanco.
                    if (String.Compare(patenteIngresada.Trim(), "") == 0)
                    {
                        Console.WriteLine("* ----- La patente no puede ir vacía. ----- *");
                        continue;
                    }

                    switch (eleccion)
                    {
                        case '1':
                            vehiculos[contadorVehiculos] = new Motocicleta(patenteIngresada);
                            break;
                        case '2':
                            vehiculos[contadorVehiculos] = new Automovil(patenteIngresada);
                            break;
                        case '3':
                            vehiculos[contadorVehiculos] = new Bus(patenteIngresada);
                            break;
                    }

                    Console.Clear();
                    contadorVehiculos ++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while(contadorVehiculos < 5);

            contadorVehiculos = 1;

            foreach(Vehiculo vehiculo in vehiculos)
            {
                // Con el método GetType se obtiene el objeto al que pertenece vehiculo y con ToString, se pasa a una cadena de caracteres.
                // Ejemplo: TareasParte2.Bus. Como no queremos saber el nombre del proyecto más la clase, con el método Replace se reemplaza 
                // donde exista la cadena "TareasParte2" por "" (cadena vacía), eliminando así esta parte de la información.
                Console.WriteLine($"Vehículo {contadorVehiculos} ... Tipo: {(vehiculo.GetType().ToString()).Replace("TareasParte2.", "")} ... Patente: {vehiculo.GetPatente()}");
                contadorVehiculos++;
            }
        }
    }

    class Vehiculo
    {
        private string patente;
        private byte numRuedas;
        private byte capacidadMaxima;

        public Vehiculo(string patente, byte numRuedas, byte capacidadMaxima)
        {
            this.patente = patente;
            this.numRuedas = numRuedas;
            this.capacidadMaxima = capacidadMaxima;
        }

        public string GetPatente() => this.patente;
        public byte GetNumRuedas() => this.numRuedas;
        public byte GetCapacidadMaxima() => this.capacidadMaxima;
    }

    class Motocicleta : Vehiculo
    {
        private bool pataFuncionando;

        public Motocicleta(string patente) : base(patente, 2, 1)
        {
            this.pataFuncionando = true;
        }

        public bool GetPataFuncionando() => this.pataFuncionando;
    }

    class Automovil : Vehiculo
    {
        private ushort espacioMaletaEnLitros;

        public Automovil(string patente) : base(patente, 4, 5)
        {
            this.espacioMaletaEnLitros = 600;
        }

        public ushort GetEspacioMaletaEnLitros() => this.espacioMaletaEnLitros;
    }

    class Bus : Vehiculo
    {
        private bool tieneBaño;

        public Bus(string patente) : base(patente, 4, 45)
        {
            this.tieneBaño = false;
        }

        public bool GetTieneBaño() => this.tieneBaño;
    }
}