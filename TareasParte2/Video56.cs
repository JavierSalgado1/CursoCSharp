// Crear una clase zapatilla que tenga una marca, modelo, número de talla e indique si tiene caña alta, media o sin caña (HI-MID-LOW). 
// Utilizar properties para cada una de sus propiedades e incluir validaciones cuando se estime necesario. Mostrar por consola todos los 
// valores de los campos de la clase.
namespace TareasParte2
{
    class Video56
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Zapatilla miZapatilla1 = new Zapatilla();
            Zapatilla miZapatilla2 = new Zapatilla();

            miZapatilla1.MARCA = "FILA";
            miZapatilla1.MODELO = "TERATACH600";
            miZapatilla1.TALLA = 42;
            miZapatilla1.CAÑA = "HI";

            miZapatilla2.MARCA = "";
            miZapatilla2.MODELO = "ERX260";
            miZapatilla2.TALLA = 39;
            miZapatilla2.CAÑA = "asasasa";

            Console.WriteLine("-------------------------------\nMarca: " + miZapatilla1.MARCA);
            Console.WriteLine("Modelo: " + miZapatilla1.MODELO);
            Console.WriteLine("Talla: " + miZapatilla1.TALLA);
            Console.WriteLine("Caña: " + miZapatilla1.CAÑA);

            Console.WriteLine("-------------------------------\nMarca: " + miZapatilla2.MARCA);
            Console.WriteLine("Modelo: " + miZapatilla2.MODELO);
            Console.WriteLine("Talla: " + miZapatilla2.TALLA);
            Console.WriteLine("Caña: " + miZapatilla2.CAÑA);
        }
    }

    sealed class Zapatilla 
    {
        private string marca;
        private string modelo;
        private byte talla;
        private string caña;

        public Zapatilla()
        {
            this.marca = "";
            this.modelo = "";
            this.talla = 0;
            this.caña = "";
        }

        public string MARCA
        {
            get => this.marca;
            set => this.marca = validarMarca(value);
        }

        public string MODELO 
        {
            get => this.modelo;
            set => this.modelo = validarModelo(value);
        }

        public byte TALLA 
        {
            get => this.talla;
            set => this.talla = validarTalla(value);
        }

        public string CAÑA 
        {
            get => this.caña;
            set => this.caña = validarCaña(value);
        }

        private string validarMarca(string marca)
        {
            if (String.Compare("", marca.Trim()) == 0) return "MARCA DESCONOCIDA";
            else return marca;
        }

        private string validarModelo(string modelo)
        {
            if (String.Compare("", modelo.Trim()) == 0) return "MODELO DESCONOCIDO";
            else return modelo;
        }

        private byte validarTalla(byte talla)
        {
            if (talla < 32 || talla > 48) throw new OverflowException();
            else return talla;
        }

        private string validarCaña(string caña)
        {
            if (String.Compare("HI", caña.Trim(), false) != 0 && String.Compare("MID", caña.Trim(), false) != 0 && String.Compare("LOW", caña.Trim(), false) != 0) return "SIN INFORMACIÓN DE LA CAÑA";
            else return caña;
        }
    }
}