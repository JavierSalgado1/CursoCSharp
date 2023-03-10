using System;
// Realizar aplicación de consola que pida al usuario ingresar la ruta de un archivo. La aplicación intentará leer e imprimir 
// el contenido del archivo. Utilizar instrucciones try catch con su respectivo finally.
namespace TareasParte1
{
    class Video26
    {
        static void Main(string[] args)
        {
            string contenido = null!;
            StreamReader archivo = null!;

            Console.Write("Ingrese el nombre de un archivo con su extensión y ruta: ");
 
            try
            {
                string ruta = Console.ReadLine()!;

                archivo = new StreamReader(ruta);
                contenido = archivo.ReadToEnd();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ocurrió una Excepción: " + e.Message);
            }
            finally
            {
                if (String.Compare(contenido, null) != 0)
                {
                    Console.WriteLine("--------- C O N T E N I D O    D E L    A R C H I V O ---------");
                    Console.WriteLine(contenido);

                    archivo.Close();
                    Console.WriteLine("Se cerró la conexión con el archivo.");
                }        
            }
        }
    }
}