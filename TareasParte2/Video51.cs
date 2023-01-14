// Realizar aplicación de consola que simule la gestión de viviendas, entre las que habrán cabañas, casas y departamentos, que generarán 
// gastos de luz y de agua, además de gastos comunes para los departamentos. Adicionalmente, deberá incluirse una interfaz para las viviendas 
// con patio, que pedirá indicar el número de autos que caben y si el patio es apto para plantar.
namespace TareasParte2
{
    class Video51
    {
        static void Main(string[] args)
        {
            byte respuesta = 0;
            bool finBucle = false;

            Console.Clear();

            do
            {
                try
                {
                    Console.WriteLine("¿Qué tipo de vivienda desea revisar?\n1) Cabaña\n2) Casa\n3) Departamento");
                    respuesta = byte.Parse(Console.ReadLine()!);

                    if (respuesta != 1 && respuesta != 2 && respuesta != 3) throw new Exception();
                    else finBucle = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Debe ingresar un 1, un 2 ó un 3.");
                }
            } 
            while (!finBucle);

            Console.Clear();
            Vivienda miVivienda = null!;
            finBucle = false;

            if (respuesta == 1) miVivienda = new Cabaña("Los Álamos 666, Horcón");
            else if(respuesta == 2) miVivienda = new Casa("Florida 999, Peñaflor");
            else miVivienda = new Departamento("El Canelo 333, Pedro Aguirre Cerda", "13H");

            Console.Clear();
            Console.WriteLine($"----- {(miVivienda.GetType().ToString()).Replace("TareasParte2.", "")} -----");
            Console.WriteLine($"Dirección: {miVivienda.GetDireccion()}");
            Console.WriteLine($"Cuenta mensual de luz: ${miVivienda.GetCuentaLuz()}");
            Console.WriteLine($"Cuenta mensual de agua: ${miVivienda.GetCuentaAgua()}");

            switch (respuesta)
            {
                case 1:
                    Cabaña miCabaña = (Cabaña)miVivienda;
                    Console.WriteLine($"Capacidad máxima de autos: {miCabaña.capacidadAutos()}");
                    Console.Write("Apto para plantar: ");

                    if(miCabaña.aptoParaPlantar()) Console.WriteLine(" Sí");
                    else Console.WriteLine("No");
                    break;
                case 2:
                    Casa miCasa = (Casa)miVivienda;
                    Console.WriteLine($"Capacidad máxima de autos: {miCasa.capacidadAutos()}");
                    Console.Write("Apto para plantar: ");

                    if(miCasa.aptoParaPlantar()) Console.WriteLine("Sí");
                    else Console.WriteLine("No");
                    break;
                case 3:
                    Departamento miDepa = (Departamento)miVivienda;
                    Console.WriteLine($"Cuenta de gastos comunes: ${miDepa.GetGastosComunes()}");
                    break;
            }
        }
    }

    class Vivienda 
    {
        protected uint cuentaLuz;
        protected uint cuentaAgua;
        protected string direccion;

        public Vivienda(string direccion, uint cuentaLuz, uint cuentaAgua)
        {
            this.cuentaLuz = cuentaLuz;
            this.cuentaAgua = cuentaAgua;
            this.direccion = direccion;
        }

        public uint GetCuentaLuz() => this.cuentaLuz;
        public uint GetCuentaAgua() => this.cuentaAgua;
        public virtual string GetDireccion() => this.direccion;
    }

    interface IViviendaPatio
    {
        byte capacidadAutos();
        bool aptoParaPlantar();
    }

    class Cabaña : Vivienda, IViviendaPatio
    {
        public Cabaña(string direccion) : base(direccion, 5000, 10000) {}

        public byte capacidadAutos() => 2;
        public bool aptoParaPlantar() => true;
    }

    class Casa : Vivienda, IViviendaPatio
    {
        public Casa(string direccion) : base(direccion, 10000, 12000) {}

        public byte capacidadAutos() => 1;
        public bool aptoParaPlantar() => false;
    }

    class Departamento : Vivienda
    {
        private string depto;
        private uint gastosComunes;

        public Departamento(string direccion, string depto) : base(direccion, 5000, 5000)
        {
            this.depto = depto;
            this.gastosComunes = 3000;
        }

        public uint GetGastosComunes() => this.gastosComunes;

        public override string GetDireccion()
        {
            return this.direccion + ", " + this.depto;
        }
    }
}