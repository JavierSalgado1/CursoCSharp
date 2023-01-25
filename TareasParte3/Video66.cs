// "Escribir un programa que cree un diccionario de traducción español-inglés. El usuario introducirá las palabras en español e inglés 
// separadas por dos puntos, y cada par <palabra>:<traducción> separados por comas. El programa debe crear un diccionario con las 
// palabras y sus traducciones. Después pedirá una frase en español y utilizará el diccionario para traducirla palabra a palabra. Si una 
// palabra no está en el diccionario debe dejarla sin traducir."
// FUENTE DEL EJERCICIO: https://aprendeconalf.es/docencia/python/ejercicios/diccionarios/#ejercicio-8 ... Ejercicio 8.
using System.Collections.Generic;

namespace TareasParte3
{
    class Video66
    {
        static void Main(String[] args)
        {
            Console.Clear();

            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            string palabrasIngresadas;
            byte index;
            bool diccionarioCompletadoCorrectamente = false;

            do
            {
                try
                {
                    Console.WriteLine("Ingrese las palabras para ingresar en el diccionario Español-Inglés.");
                    Console.WriteLine("Formato: palabra:traducción, palabra:traducción, palabra:traducción...");
                    palabrasIngresadas = Console.ReadLine()!;
                    palabrasIngresadas = palabrasIngresadas.Replace(" ", "");

                    if(String.Compare(palabrasIngresadas, "") == 0) throw new Exception();

                    // El método Split de la clase String devuelve un array de strings, en que cada elemento está separado por el 
                    // carácter especidicado, en este caso, la coma.
                    foreach(string parPalabras in palabrasIngresadas.Split(','))
                    {
                        index = (byte)parPalabras.IndexOf(':');
                        // El método Substring de la clase String devuelve parte de una cadena según los argumentos especificados en sus 
                        // distintas sobrecargas.
                        diccionario.Add(parPalabras.Substring(0, index), parPalabras.Substring(index+1));
                    }
                    diccionarioCompletadoCorrectamente = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Error en el formato. Vuelva a intentarlo.");
                    diccionario.Clear();
                }
            } 
            while (!diccionarioCompletadoCorrectamente);

            Console.Clear();

            bool textoIngresado = false;
            string textoEspañol;
            string textoTraducido = "";

            do
            {
                try
                {
                    Console.WriteLine("Ingrese un texto en español. El programa intentará traducirlo al inglés palabra por palabra.");
                    textoEspañol = Console.ReadLine()!.Trim();

                    if(String.Compare(textoEspañol, "") == 0) throw new Exception();

                    foreach(string palabra in textoEspañol.Split(" "))
                    {
                        try
                        {
                            textoTraducido = textoTraducido + diccionario[palabra] + " ";
                        }
                        catch (Exception)
                        {
                            textoTraducido = textoTraducido + palabra + " ";
                        }
                        
                    }

                    textoIngresado = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un texto válido. Vuelva a intentarlo.");
                }
            } 
            while (!textoIngresado);

            diccionario.Clear();
            Console.Clear();
            Console.WriteLine("Texto traducido: ");
            Console.WriteLine(textoTraducido);
        }
    }
}