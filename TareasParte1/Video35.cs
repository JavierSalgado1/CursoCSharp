// Realizar aplicación de consola que pida al usuario una fracción y que luego la imprima su valor sumado en 5/2 de 
// manera repetida hasta que la fracción represente un número superior a 1000. Tratar las fracciones como clases anónimas.
// PISTA: Investigar sobre el tipo dynamic. 
namespace TareasParte1
{
    class Video35
    {
        static void Main(string[] args)
        {
            ushort numerador = 0;
            ushort denominador = 0;
            bool fraccionValida;

            do
            {
                try
                {
                    Console.Write("Ingrese el numerador de la fracción: ");
                    numerador = ushort.Parse(Console.ReadLine()!);
                    Console.Write("Ingrese el denominador de la fracción: ");
                    denominador = ushort.Parse(Console.ReadLine()!);

                    fraccionValida = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    fraccionValida = false;
                }
            } 
            while (!fraccionValida);

            var fraccionSuma = new {num = (ushort)5, den = (ushort)2};
            var fraccionAImprimir = new {num = numerador, den = denominador};

            Console.Clear();
            double fraccionDecimal;

            do
            {
                Console.Write($"{fraccionAImprimir.num}/{fraccionAImprimir.den} ");
                fraccionAImprimir = sumar(fraccionAImprimir.num, fraccionAImprimir.den, fraccionSuma.num, fraccionSuma.den);
                fraccionAImprimir = simplificar(fraccionAImprimir);
                Console.Write($"+ 5/2 = {fraccionAImprimir.num}/{fraccionAImprimir.den}");

                fraccionDecimal = (double)fraccionAImprimir.num / (double)fraccionAImprimir.den;
                Console.WriteLine($"                      En decimal: {fraccionDecimal}");
            } 
            while (fraccionDecimal <= 1000 && fraccionDecimal >= 0.001);

            Console.WriteLine("Fin del programa.");
        }
    
        // Se establece el método como dynamic para que devuelva un objeto, pero sin especificar qué tipo de objeto es.
        // De esta manera, podemos almacenar su resultado en una clase anónima.
        static dynamic sumar(ushort numerador1, ushort denominador1, ushort numerador2, ushort denominador2)
        {
            ushort numeradorResultado;
            ushort denominadorResultado;

            if (denominador1 == denominador2)
            {
                numeradorResultado = (ushort)(numerador1 + numerador2);
                denominadorResultado = (ushort)denominador1;
            }
            else
            {
                ushort MCM = maximoComunDivisor(denominador1, denominador2);
                ushort mcm = minimoComunMultiplo(denominador1, denominador2, MCM);

                numeradorResultado = (ushort)(((mcm / denominador1) * numerador1) + ((mcm / denominador2) * numerador2));
                denominadorResultado = mcm;
            }

            var resultado = new {num = numeradorResultado, den = denominadorResultado};
            return resultado;
        }

        static ushort maximoComunDivisor(ushort denominador1, ushort denominador2)
        {
            // Para encontrar el M.C.D. se utilizará el famoso algoritmo de Euclides.
            // Fuente: http://www.eljavatar.com/2014/05/Diagrama-de-Flujo-y-Pseudocodigo-para-Hallar-el-Maximo-Comun-Divisor.html
            ushort a = Math.Max(denominador1, denominador2);
            ushort b = Math.Min(denominador1, denominador2);

            ushort r = 1;

            while (b != 0)
            {
                r = b;
                b = (ushort)(a % b);
                a = r;
            }

            return r;
        }

        static ushort minimoComunMultiplo(ushort denominador1, ushort denominador2, ushort maximoComunDivisor)
        {
            ushort resultado;
            resultado = (ushort)((denominador1 * denominador2) / maximoComunDivisor);
            return resultado;
        }

        static dynamic simplificar(dynamic fraccion)
        {
            ushort elementoMenor;
            ushort contador = 2;
            ushort numSimplificado = fraccion.num;
            ushort denSimplificado = fraccion.den;

            do
            {
                if ((numSimplificado%contador == 0) && (denSimplificado%contador == 0))
                {
                    numSimplificado = (ushort)(numSimplificado / contador);
                    denSimplificado = (ushort)(denSimplificado / contador);
                }
                else
                {
                    contador ++;
                }

                elementoMenor = Math.Min(numSimplificado, denSimplificado);
            } 
            while (contador <= (elementoMenor / 2));

            var fraccionSimplificada = new {num = numSimplificado, den = denSimplificado};
            return fraccionSimplificada;
        }
    }
}