// Realizar aplicación de consola que pida a un alumno 5 calificaciones que obtuvo durante un semestre (escala 1.0 a 7.0). Si el alumno 
// obtiene un promedio de 4.0 o superior, se debe indicar que aprobó, y en caso contrario, que reprobó. Utilizar un Array para almacenar 
// las calificaciones parciales.
namespace TareasParte2
{
    class Video36
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine()!;

            float[] notasParciales = new float[5];
            byte contador = 1;

            do
            {
                try
                {
                    Console.Write($"Ingrese su {contador}° nota parcial: ");
                    notasParciales[contador - 1] = float.Parse(Console.ReadLine()!);

                    if (notasParciales[contador -1] >= 1.0 && notasParciales[contador - 1] <= 7.0)
                    {
                        contador++;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("La nota ingresada debe ser un valor numérico decimal entre 1,0 y 7,0");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }             
            } while (contador <= 5);

            float promedio = (notasParciales[0] + notasParciales[1] + notasParciales[2] + notasParciales[3] + notasParciales[4]) / 5;

            Console.Write($"El promedio final de {nombre} es de {promedio}. Por lo tanto, ");

            if (promedio >= 4.0)
            {
                Console.WriteLine("aprobó.");
            }
            else
            {
                Console.WriteLine("reprobó.");
            }
        }
    }
}