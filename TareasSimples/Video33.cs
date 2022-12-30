using System;
// Realizar aplicación de consola que simule las operaciones básicas con fracciones (sumar, restar, dividir y multiplicar). 
// Cada fracción deberá ser tratada como un objeto.
namespace TareasSimples
{
    class Video33
    {
        static void Main(string[] args)
        {

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
        }

        private short minimoComunMultiplo(short denominador1, short denominador2)
        {

        }
    }
}