using System;
// Realizar aplicación de consola que simule una guitarra. La guitarra tendrá como propiedad el número de cuerdas, número de trastes 
// (espacios en el mástil) y el material del cuerpo, y como comportamiento permitirá mostrar su información técnica. Se debe utilizar 
// sobrecarga de constructores.
namespace TareasParte1
{
    class Video30
    {
        static void Main(string[] args)
        {
            Guitarra guitarra1 = new Guitarra();
            Guitarra guitarra2 = new Guitarra(7, 19);

            guitarra1.MostrarFichaTecnica();
            guitarra2.MostrarFichaTecnica();
        }
    }

    class Guitarra
    {
        private byte numCuerdas;
        private byte numTrastes;
        private const string MATERIAL = "Madera";

        public Guitarra()
        {
            numCuerdas = 6;
            numTrastes = 20;
        }

        public Guitarra(byte numCuerdas, byte numTrastes)
        {
            // La palabra reservada "this" permite indicar que nos referimos a la variable de la clase, y aspi evitamos que 
            // el programa entre en un conflicto ante dos variables que tienen el mismo nombre;
            this.numCuerdas = numCuerdas;
            this.numTrastes = numTrastes;
        }

        public void MostrarFichaTecnica()
        {
            // Al escribir \n en un string estamos haciendo un salto de línea. De esta manera nos evitamos crear más instrucciones 
            // Console.WriteLine para poder imprimir más líneas.
            Console.WriteLine($"--- Ficha Técnica ---\nNúmero de cuerdas: {numCuerdas}\nNúmero de trastes: {numTrastes}");
            Console.WriteLine("Material: " + MATERIAL + "\n---------------------");
        }
    }
}