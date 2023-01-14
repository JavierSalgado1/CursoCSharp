// Realizar un diseño de clases que tenga en la cúspide una case abstracta "Cuerpo Celeste", que entregará el diámetro, nombre y masa de los 
// cuerpos, además de exigir describir las características de cada uno de estos. De entre estos cuerpos habrán estrellas, capaces de entregar 
// el número de planetas que la orbitan y su tipo, y planetas, con un número de satélites y temperatura media, y podrán ser rocosos o 
// gaseosos, los primeros con o sin actividad volcánica y agua líquida, y los últimos indicarán si poseen o no anillos. Existirá una 
// interfaz llamada ICuerposRocosos, que definirá la intensidad de un terremoto. Agrega unos cuantos cuerpos y muestra su información 
// por consola.
namespace TareasParte2
{
    class Video53
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Estrella miEstrella = new Estrella("Sol", 1391016,  "1,9891 × 1030 Kg.", 8, "Enana Amarilla");

            PlanetaRocoso planeta1 = new PlanetaRocoso("Mercurio", 8479, "3,302 × 10^23 Kg.", 0, 166, false, false);
            PlanetaRocoso planeta2 = new PlanetaRocoso("Venus", 12103, "4,869 × 10^24 Kg.", 0, 463, true, false);
            PlanetaRocoso planeta3 = new PlanetaRocoso("Tierra", 12750, "5,9736 × 10^24 Kg.", 1, 15, true, true);
            PlanetaRocoso planeta4 = new PlanetaRocoso("Marte", 6794, "6,4185 × 10^23 Kg.", 2, -46,  false, false);

            PlanetaGaseoso planeta5 = new PlanetaGaseoso("Júpiter", 142984, "1,899 × 10^27 Kg.", 79, -121, true);
            PlanetaGaseoso planeta6 = new PlanetaGaseoso("Saturno", 120553, "5,688 × 10^26 Kg.", 82, -130, true);
            PlanetaGaseoso planeta7 = new PlanetaGaseoso("Urano", 51118, "8,686 × 10^25 Kg.", 27, -205, true);
            PlanetaGaseoso planeta8 = new PlanetaGaseoso("Neptuno", 49572, "1,024 × 10^26 Kg.", 14, -220, true);

            CuerpoCeleste[] cuerposSistemaSolar = new CuerpoCeleste[9];

            cuerposSistemaSolar[0] = miEstrella;
            cuerposSistemaSolar[1] = planeta1;
            cuerposSistemaSolar[2] = planeta2;
            cuerposSistemaSolar[3] = planeta3;
            cuerposSistemaSolar[4] = planeta4;
            cuerposSistemaSolar[5] = planeta5;
            cuerposSistemaSolar[6] = planeta6;
            cuerposSistemaSolar[7] = planeta7;
            cuerposSistemaSolar[8] = planeta8;

            Console.WriteLine("A continuación, harás un recorrido por el sistema Solar, desde el Sol hasta el último planeta.");
            Console.WriteLine("Presione [Enter] para continuar ...");
            Console.ReadLine();

            foreach(CuerpoCeleste cuerpo in cuerposSistemaSolar)
            {
                Console.Clear();
                Console.WriteLine(cuerpo.Describir());
                Console.WriteLine("Presione [Enter] para continuar ...");
                Console.ReadLine();
            }

            // Y por si quieres provocar un terremoto en la tierra... :(
            // Console.WriteLine(planeta2.provocarTerremoto());
        }
    }

    abstract class CuerpoCeleste
    {
        protected string nombre;
        protected uint diametroKm;
        protected string masa;

        public CuerpoCeleste(string nombre, uint diametroKm, string masa)
        {
            this.nombre = nombre;
            this.diametroKm = diametroKm;
            this.masa = masa;
        }

        public abstract string Describir();

        public string GetNombre() => this.nombre;
        public uint GetDiametroKm() => this.diametroKm;
        public string GetMasa() => this.masa;
    }

    class Planeta : CuerpoCeleste 
    {
        protected ushort numSatelites;
        protected short temperaturaMedia;

        public Planeta(string nombre, uint diametroKm, string masa, ushort numSatelites, short temperaturaMedia) : base(nombre, diametroKm, masa)
        {
            this.numSatelites = numSatelites;
            this.temperaturaMedia = temperaturaMedia;
        }

        public override string Describir()
        {
            string descripcion;
            descripcion = $"----- PLANETA: {nombre} -----\nDiámetro: {diametroKm} Km.\nMasa: {masa}\nNúmero de Satélites conocidos: {numSatelites}";
            descripcion = descripcion + $"\nTemperatura Media: {temperaturaMedia} C°.";
            return descripcion;
        }

        public ushort GetNumSatelites() => this.numSatelites;
        public short GetTemperaturaMedia() => this.temperaturaMedia;
    }

    class Estrella : CuerpoCeleste
    {
        private byte numPlanetasOrbitando;
        private string tipo;

        public Estrella(string nombre, uint diametroKm, string masa, byte numPlanetasOrbitando, string tipo) : base(nombre, diametroKm, masa)
        {
            this.numPlanetasOrbitando = numPlanetasOrbitando; 
            this.tipo = tipo;
        }

        public override string Describir()
        {
            string descripcion;
            descripcion = $"----- ESTRELLA: {nombre} -----\nDiámetro: {diametroKm} Km.\nMasa: {masa}\nNúmero de Planetas orbitando: {numPlanetasOrbitando}";
            descripcion = descripcion + $"\nTipo: {tipo}.";
            return descripcion;
        }

        public byte GetNumPlanetasOrbitando() => this.numPlanetasOrbitando;
        public string GetTipo() => this.tipo;
    }

    interface IPlanetaRocoso
    {
        string provocarTerremoto();
    }

    class PlanetaRocoso : Planeta, IPlanetaRocoso
    {
        private bool actividadVolcanica;
        private bool aguaLiquida;

        public PlanetaRocoso(string nombre, uint diametroKm, string masa, ushort numSatelites, short temperaturaMedia, bool actividadVolcanica, bool aguaLiquida) : base (nombre, diametroKm, masa, numSatelites, temperaturaMedia)
        {
            this.actividadVolcanica = actividadVolcanica;
            this.aguaLiquida = aguaLiquida;
        }
        
        public override string Describir()
        {
            string descripcion;
            descripcion = $"----- PLANETA: {nombre} -----\nDiámetro: {diametroKm} Km.\nMasa: {masa}\nNúmero de Satélites conocidos: {numSatelites}";
            descripcion = descripcion + $"\nTemperatura Media: {temperaturaMedia} C°.\nActividad Volcánica: {GetActividadVolcanica()}\nPosee Agua Líquida: {GetAguaLiquida()}";
            return descripcion;
        }

        public string provocarTerremoto() => "Ha ocurrido un terremoto. Manden ayuda aAaAa.";

        public string GetActividadVolcanica()
        {
            if (actividadVolcanica) return "Sí";
            else return "No";
        }

        public string GetAguaLiquida()
        {
            if (aguaLiquida) return "Sí";
            else return "No";
        }
    }

    class PlanetaGaseoso : Planeta
    {
        private bool tieneAnillos;

        public PlanetaGaseoso(string nombre, uint diametroKm, string masa, ushort numSatelites, short temperaturaMedia, bool tieneAnillos) : base (nombre, diametroKm, masa, numSatelites, temperaturaMedia)
        {
            this.tieneAnillos = tieneAnillos;
        }

        public override string Describir()
        {
            string descripcion;
            descripcion = $"----- PLANETA: {nombre} -----\nDiámetro: {diametroKm} Km.\nMasa: {masa}\nNúmero de Satélites conocidos: {numSatelites}";
            descripcion = descripcion + $"\nTemperatura Media: {temperaturaMedia} C°.\nTiene Anillos: {GetTieneAnillos()}";
            return descripcion;
        }

        public string GetTieneAnillos()
        {
            if (tieneAnillos) return "Si";
            else return "No";
        }
    }
}