// Realizar aplicación de consola que permita ingresar datos de 5 guitarras, que podrán ser acústicas, electroacústicas y eléctricas. 
// Además de tener características diferenciadoras, todas estas guitarras deberán poder entregar una descripción de todos sus atributos. 
// Poner en práctica el concepto de polimorfismo para mostrar las descripciones.
namespace TareasParte2
{
    class Video45
    {
        static void Main(string[] args)
        {
            byte contadorGuitarras = 0;
            char eleccion;
            string marcaIngresada;
            string modeloIngresado;
            string capsulasIngresadas = "";
            bool puenteFlotanteIngresado = false;

            GuitarraAcustica[] guitarras = new GuitarraAcustica[5];

            Console.Clear();

            do
            {
                try
                {
                    Console.WriteLine($"¿Cuál es la {contadorGuitarras + 1}° guitarra que desea ingresar?");
                    Console.WriteLine("1) Acústica\n2) Electroacústica\n3) Eléctrica");
                    eleccion = char.Parse(Console.ReadLine()!);

                    if (eleccion != '1' && eleccion != '2' && eleccion != '3')
                    {
                        Console.WriteLine("* ----- Debe elegir una opción válida (1, 2 ó 3). ----- *");
                        continue;
                    }

                    Console.Write("\nIngrese la marca de la guitarra: ");
                    marcaIngresada = Console.ReadLine()!;
                    Console.Write("\nIngrese el modelo de la guitarra: ");
                    modeloIngresado = Console.ReadLine()!;

                    if (eleccion != '1')
                    {
                        Console.Write("\nIngrese las cápsulas de la guitarra: ");
                        capsulasIngresadas = Console.ReadLine()!;

                        if (eleccion == '3')
                        {
                            Console.Write("\nSi la guitarra tiene puente fijo, ingrese true, y si no, ingrese false: ");
                            puenteFlotanteIngresado = bool.Parse(Console.ReadLine()!);
                        }
                    }

                    if (!ValidarDatosVacios(marcaIngresada, modeloIngresado, capsulasIngresadas, eleccion)) continue;

                    switch (eleccion)
                    {
                        case '1':
                            guitarras[contadorGuitarras] = new GuitarraAcustica(marcaIngresada, modeloIngresado);
                            break;
                        case '2':
                            guitarras[contadorGuitarras] = new GuitarraElectroacustica(marcaIngresada, modeloIngresado, capsulasIngresadas);
                            break;
                        case '3':
                            guitarras[contadorGuitarras] = new GuitarraElectrica(marcaIngresada, modeloIngresado, capsulasIngresadas, puenteFlotanteIngresado);
                            break;
                    }

                    Console.Clear();
                    contadorGuitarras ++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while(contadorGuitarras < 5);

            Console.Clear();

            contadorGuitarras = 1;

            foreach(GuitarraAcustica guitarra in guitarras)
            {
                Console.WriteLine($"----- GUITARRA N° {contadorGuitarras} -----");
                Console.WriteLine(guitarra.MostrarEspecificacionTecnica());
                contadorGuitarras++;
            }
        }

        static bool ValidarDatosVacios(string marca, string modelo, string capsulas, char tipoGuitarra)
        {
            if (String.Compare(marca.Trim(), "") == 0)
            {
                Console.WriteLine("* ----- La marca no puede ir vacía. Intente ingresar los datos nuevamente ----- *");
                return false;
            }
            else if(String.Compare(modelo.Trim(), "") == 0)
            {
                Console.WriteLine("* ----- El modelo no puede ir vacío. Intente ingresar los datos nuevamente ----- *");
                return false;
            }
            else if(tipoGuitarra != '1' && String.Compare(capsulas.Trim(), "") == 0)
            {
                Console.WriteLine("* ----- Las cápsulas no pueden ir vacías. Intente ingresar los datos nuevamente ----- *");
                return false;
            }
            else
            {
                return true;
            }
        }

        class GuitarraAcustica
        {
            private string marca;
            private string modelo;
            private byte numCuerdas;

            public GuitarraAcustica(string marca, string modelo)
            {
                this.marca = marca;
                this.modelo = modelo;
                this.numCuerdas = 6;
            }

            public string GetMarca() => this.marca;
            public string GetModelo() => this.modelo;
            public byte GetNumCuerdas() => this.numCuerdas;

            public virtual string MostrarEspecificacionTecnica()
            {
                string detalle;
                detalle = $"Guitarra Acústica\nMarca: {this.GetMarca()}\nModelo: {this.GetModelo()}\nNúmero de cuerdas: {this.GetNumCuerdas()}";
                return detalle;
            }
        }

        class GuitarraElectroacustica : GuitarraAcustica
        {
            private string capsulas;

            public GuitarraElectroacustica(string marca, string modelo, string capsulas) : base(marca, modelo)
            {
                this.capsulas = capsulas;
            }

            public string GetCapsulas() => this.capsulas;

            public override string MostrarEspecificacionTecnica()
            {
                string detalle;
                detalle = $"Guitarra Electroacústica\nMarca: {this.GetMarca()}\nModelo: {this.GetModelo()}\nNúmero de cuerdas: {this.GetNumCuerdas()}";
                detalle = detalle + $"\nCápsulas: {this.GetCapsulas()}";
                return detalle;
            }
        }

        class GuitarraElectrica : GuitarraElectroacustica
        {
            private bool puenteFlotante;

            public GuitarraElectrica(string marca, string modelo, string capsulas, bool puenteFlotante) : base(marca, modelo, capsulas)
            {
                this.puenteFlotante = puenteFlotante;
            }

            public bool GetPuenteFlotante() => this.puenteFlotante;

            public override string MostrarEspecificacionTecnica()
            {
                string detalle;
                detalle = $"Guitarra Eléctrica\nMarca: {this.GetMarca()}\nModelo: {this.GetModelo()}\nNúmero de cuerdas: {this.GetNumCuerdas()}";
                detalle = detalle + $"\nCápsulas: {this.GetCapsulas()}";

                if (this.GetPuenteFlotante()) detalle = detalle + "\nTipo de puente: Flotante";
                else detalle = detalle + "\nTipo de puente: Fijo";

                return detalle;
            }
        }
    }
}