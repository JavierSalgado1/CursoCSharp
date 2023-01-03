using System;
// Realizar aplicación de consola que simule las operaciones básicas con 2 fracciones (sumar, restar, multiplicar y dividir). 
// Cada fracción deberá ser tratada como un objeto. Permitir que el usuario ingrese los numeradores y denominadores de las 
// fracciones con las que operar.
namespace TareasParte1
{
    class Video33
    {
        static void Main(string[] args)
        {
            short numerador1;
            short denominador1;
            short numerador2;
            short denominador2;
            Fraccion miFraccion1 = null!;
            Fraccion miFraccion2 = null!;

            char respuesta = 'S';
            byte accion;

            do
            {
                Console.WriteLine("Elija una acción a realizar ingresando el número correspondiente: ");
                Console.WriteLine("1) Sumar.");
                Console.WriteLine("2) Restar.");
                Console.WriteLine("3) Multiplicar.");
                Console.WriteLine("4) Dividir.");

                try
                {
                    accion = byte.Parse(Console.ReadLine()!);
                    Console.Clear();

                    if(accion >= 1 && accion <= 4)
                    {
                        Console.Write("--- PRIMERA FRACCIÓN ---\nNumerador: ");
                        numerador1 = short.Parse(Console.ReadLine()!);
                        Console.Write("Denominador: ");
                        denominador1 = short.Parse(Console.ReadLine()!);
                        miFraccion1 = new Fraccion(numerador1, denominador1);

                        Console.Write("--- SEGUNDA FRACCIÓN ---\nNumerador: ");
                        numerador2 = short.Parse(Console.ReadLine()!);
                        Console.Write("Denominador: ");
                        denominador2 = short.Parse(Console.ReadLine()!);                        
                        miFraccion2 = new Fraccion(numerador2, denominador2);     
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }

                    switch (accion)
                    {
                        case 1:
                            Fraccion resultadoSuma =  miFraccion1.Sumar(miFraccion2);
                            Console.WriteLine($"El resultado de la Suma es: {resultadoSuma.GetNumerador()} / {resultadoSuma.GetDenominador()}");                      
                            break;
                        case 2:
                            Fraccion resultadoResta =  miFraccion1.Restar(miFraccion2);
                            Console.WriteLine($"El resultado de la Resta es: {resultadoResta.GetNumerador()} / {resultadoResta.GetDenominador()}");
                            break;
                        case 3:
                            Fraccion resultadoMultiplicacion =  miFraccion1.Multiplicar(miFraccion2);
                            Console.WriteLine($"El resultado de la Multiplicación es: {resultadoMultiplicacion.GetNumerador()} / {resultadoMultiplicacion.GetDenominador()}");
                            break;
                        case 4:
                            Fraccion resultadoDivision =  miFraccion1.Dividir(miFraccion2);
                            Console.WriteLine($"El resultado de la División es: {resultadoDivision.GetNumerador()} / {resultadoDivision.GetDenominador()}");
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

    class Fraccion 
    {
        private short numerador;
        private short denominador;

        public Fraccion(short numerador, short denominador)
        {
            this.numerador = numerador;
            this.denominador = denominador;
        }

        public short GetNumerador()
        {
            return this.numerador;
        }

        public short GetDenominador()
        {
            return this.denominador;
        }

        // Se declara que el método retorne un objeto de la clase Fraccion ya que el resultado será una fracción nueva, con 
        // un numerador y denominador específicos.
        public Fraccion Sumar(Fraccion otraFraccion)
        {
            short numeradorResultado;
            short denominadorResultado;

            if (this.denominador == otraFraccion.GetDenominador())
            {
                numeradorResultado = (short)(this.numerador + otraFraccion.GetNumerador());
                denominadorResultado = this.denominador;
            }
            else
            {
                short MCM = maximoComunDivisor(this.denominador, otraFraccion.GetDenominador());
                short mcm = minimoComunMultiplo(this.denominador, otraFraccion.GetDenominador(), MCM);

                numeradorResultado = (short)(((mcm / this.denominador) * this.numerador) + ((mcm / otraFraccion.GetDenominador()) * otraFraccion.GetNumerador()));
                denominadorResultado = mcm;
            }

            return new Fraccion(numeradorResultado, denominadorResultado);
        }

        public Fraccion Restar(Fraccion otraFraccion)
        {
            short numeradorResultado;
            short denominadorResultado;

            if (this.denominador == otraFraccion.GetDenominador())
            {
                numeradorResultado = (short)(this.numerador - otraFraccion.GetNumerador());
                denominadorResultado = this.denominador;
            }
            else
            {
                short MCM = maximoComunDivisor(this.denominador, otraFraccion.GetDenominador());
                short mcm = minimoComunMultiplo(this.denominador, otraFraccion.GetDenominador(), MCM);

                numeradorResultado = (short)(((mcm / this.denominador) * this.numerador) - ((mcm / otraFraccion.GetDenominador()) * otraFraccion.GetNumerador()));
                denominadorResultado = mcm;
            }

            Fraccion resultado = new Fraccion(numeradorResultado, denominadorResultado);
            resultado.simplificar();

            return resultado;
        }

        public Fraccion Multiplicar(Fraccion otraFraccion)
        {
            short numeradorResultado = (short)(this.numerador * otraFraccion.GetNumerador());
            short denominadorResultado = (short)(this.denominador * otraFraccion.GetDenominador());

            Fraccion resultado = new Fraccion(numeradorResultado, denominadorResultado);
            resultado.simplificar();

            return resultado;
        }

        public Fraccion Dividir(Fraccion otraFraccion)
        {
            short numeradorResultado = (short)(this.numerador * otraFraccion.GetDenominador());
            short denominadorResultado = (short)(this.denominador * otraFraccion.GetNumerador());

            Fraccion resultado = new Fraccion(numeradorResultado, denominadorResultado);
            resultado.simplificar();

            return resultado;
        }

        private short minimoComunMultiplo(short denominador1, short denominador2, short maximoComunDivisor)
        {
            short resultado;
            resultado = (short)((denominador1 * denominador2) / maximoComunDivisor);
            return resultado;
        }

        private short maximoComunDivisor(short denominador1, short denominador2)
        {
            // Para encontrar el M.C.D. se utilizará el famoso algoritmo de Euclides.
            // Fuente: http://www.eljavatar.com/2014/05/Diagrama-de-Flujo-y-Pseudocodigo-para-Hallar-el-Maximo-Comun-Divisor.html

            short a = Math.Max(denominador1, denominador2);
            short b = Math.Min(denominador1, denominador2);

            short r = 1;

            while (b != 0)
            {
                r = b;
                b = (short)(a % b);
                a = r;
            }

            return r;
        }

        private void simplificar()
        {
            short elementoMenor;
            short contador = 2;

            do
            {
                if ((this.numerador%contador == 0) && (this.denominador%contador == 0))
                {
                    this.numerador = (short)(this.numerador / contador);
                    this.denominador = (short)(this.denominador / contador);
                }
                else
                {
                    contador ++;
                }

                elementoMenor = Math.Min(this.numerador, this.denominador);
            } 
            while (contador <= (elementoMenor / 2));
        }
    }
}