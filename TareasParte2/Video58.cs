// Realizar aplicación de consola que pida al usuario ingresar el número de un mes de 1 al 12. Se deberá hacer que, para los meses de 
// Diciembre, Enero y Febrero, el programa indique que hay vacaciones, y sino, que es época de estudios. Trabajar los meses como tipos 
// enumerados.
namespace TareasParte2
{
    class Video58
    {
        static void Main(string[] args)
        {
            Console.Clear();

            bool finBucle = false;
            byte mes = 0;

            do
            {
                try
                {
                    Console.WriteLine("Ingrese un número del 1 al 12");
                    mes = byte.Parse(Console.ReadLine()!);

                    if (mes < 1 || mes > 12) throw new Exception();
                    finBucle = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un número del 1 al 12.");
                }
            }
            while (!finBucle);

            if (mes == (byte)Meses.Diciembre || mes == (byte)Meses.Enero || mes == (byte)Meses.Febrero) Console.WriteLine("Es época de vacaciones.");
            else Console.WriteLine("Es época de estudio.");
        }
    }

    enum Meses
    {
        // Al asignar un valor numérico entero al primer elemento del enum, los demás obtienen implícitamente el valor correlativo siguiente.
        Enero = 1,
        Febrero,
        Marzo,
        Abril, 
        Mayo,
        Junio, 
        Julio, 
        Agosto, 
        Septiembre, 
        Octubre, 
        Noviembre, 
        Diciembre
    }
}