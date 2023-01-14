// Realizar aplicación de consola que contenga una clase Multiplicar y otra Dividir. Ambas clases tendrán 2 campos, que corresponderán 
// a los valores a multiplicar / dividir, y cada una podrá realizar su operación correspondiente y expresar el resultado en un mensaje. 
// Utilizar herencia para la solución.
namespace TareasParte2
{
    class Video43
    {
        static void Main(string[] args)
        {
            sbyte finalizado = 0;
            byte respuesta = 0;

            do
            {
                try
                {
                    Console.Clear();

                    if (finalizado == -1) Console.WriteLine("Debe ingresar un 1 ó un 2. Inténtelo nuevamente");

                    Console.WriteLine("¿Qué operación desea realizar?");
                    Console.WriteLine("1) Multiplicación\n2) Dividir");
                    respuesta = byte.Parse(Console.ReadLine()!);

                    if (respuesta < 1 || respuesta > 2) throw new Exception();

                    finalizado = 1;
                }
                catch (Exception)
                {
                    finalizado = -1;
                }
            }
            while (finalizado != 1);

            finalizado = 0;
            double numero1 = 0;
            double numero2 = 0;

            do
            {
                try
                {
                    Console.Clear();
                    
                    if (finalizado == -1) Console.WriteLine("Debe ingresar números válidos.");

                    checked
                    {
                        if (respuesta == 1)
                        {
                            Console.WriteLine("----- M U L T I P L I C A C I Ó N -----");
                            Console.Write("Ingrese el primer factor: ");
                            numero1 = double.Parse(Console.ReadLine()!);
                            Console.Write("Ingrese el segundo factor: ");
                            numero2 = double.Parse(Console.ReadLine()!);

                            Multiplicar multiplicacion = new Multiplicar(numero1, numero2);
                            multiplicacion.CalcularResultado();
                            Console.WriteLine(multiplicacion.ExpresarResultado());
                        }
                        else if (respuesta == 2)
                        {
                            Console.WriteLine("----- D I V I S I Ó N -----");
                            Console.Write("Ingrese el dividendo: ");
                            numero1 = double.Parse(Console.ReadLine()!);
                            Console.Write("Ingrese el divisor: ");
                            numero2 = double.Parse(Console.ReadLine()!);

                            Dividir division = new Dividir(numero1, numero2);
                            division.CalcularResultado();
                            Console.WriteLine(division.ExpresarResultado());
                        }   
                    }

                    finalizado = 1;
                }
                catch (Exception)
                {
                    finalizado = -1;
                }
            } 
            while (finalizado != 1);
        }
    }

    class Operaciones
    {
        private double numero1;
        private double numero2;
        private double resultado;

        public double GetNumero1() => this.numero1;
        public double GetNumero2() => this.numero2;
        
        public void SetResultado(double resultado)
        {
            this.resultado = resultado;
        }

        public Operaciones(double numero1, double numero2)
        {
            this.numero1 = numero1;
            this.numero2 = numero2;
        }

        public string ExpresarResultado()
        {
            return $"El resultado de la operación es {this.resultado}";
        }
    }

    class Multiplicar : Operaciones
    {
        public Multiplicar(double numero1, double numero2) : base(numero1, numero2)
        {
        }

        public void CalcularResultado()
        {
            checked
            {
                SetResultado(GetNumero1() * GetNumero2());
            }
        }
    }

    class Dividir : Operaciones
    {
        public Dividir(double numero1, double numero2) : base(numero1, numero2)
        {
        }

        public void CalcularResultado()
        {
            checked
            {
                SetResultado(GetNumero1() / GetNumero2());
            }
        }
    }
}