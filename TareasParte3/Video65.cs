// "Crea un programa que lea el contenido de un fichero de texto, lo almacene línea por línea en una cola, luego muestre este contenido 
// en pantalla y finalmente lo vuelque a otro fichero de texto." *Utilizar colección de tipo Queue.
// FUENTE DEL EJERCICIO: https://www.nachocabanes.com/csharp/curso2015/csharp11c.php ... Ejercicio propuesto 11.3.3.
using System.Collections.Generic;

namespace TareasParte3
{
    class Video65
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Queue<string> colaTextoArchivo = new Queue<string>();
            string rutaArchivo = "";
            bool rutaCorrecta = false;
            StreamReader strArchivo = null!;

            do
            {
                try
                {
                    Console.Write("Ingrese la ruta del archivo de texto a volcar: ");
                    rutaArchivo = Console.ReadLine()!.Trim();

                    strArchivo = new StreamReader(rutaArchivo);
                    rutaCorrecta = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese una ruta válida.");
                }
            } 
            while (!rutaCorrecta);

            string linea; 

            while((linea = strArchivo.ReadLine()!) != null)
            {
                colaTextoArchivo.Enqueue(linea);
            }

            Console.WriteLine("----- Archivo volcado -----\n");

            rutaArchivo = rutaArchivo.Replace(".txt", "_Volcado.txt");

            if (!File.Exists(rutaArchivo))
            {
                StreamWriter archivoNuevo = new StreamWriter(rutaArchivo);

                try
                {
                    while((linea = colaTextoArchivo.Peek()) != null)
                    {
                        archivoNuevo.WriteLine(colaTextoArchivo.Dequeue());
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nProceso terminado.");
                }
                finally
                {
                    strArchivo.Close();
                    archivoNuevo.Close();
                }
            }
            else
            {
                Console.WriteLine("Elimine primero el archivo que termina en _Volcado.txt y vuelva a intentarlo.");
            }
        }
    }
}