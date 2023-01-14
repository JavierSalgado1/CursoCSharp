// Realizar aplicación de consola que contenga una clase llamada Java y otra CSharp. Permitir que cada una entregue una descrición 
// común y detallada de qué es lo que son y lo que hacen. Utilizar herencia.
namespace TareasParte2
{
    class Video42
    {
        static void Main(string[] args)
        {
            Console.Clear();

            bool finBucle = false;
            byte respuesta = 0;

            do
            {
                try
                {
                    Console.WriteLine("¿De cuál de estas tecnologías te gustaría obtener información?");
                    Console.WriteLine("1) Java\n2) C#");
                    respuesta = byte.Parse(Console.ReadLine()!);
                    if (respuesta < 1 || respuesta > 2)
                    {
                        Console.WriteLine("El número ingresado debe ser 1 ó 2.");
                    }
                    else
                    {
                        finBucle = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\nIntente ingresar su elección nuevamente (1 ó 2).");
                }
            } 
            while (!finBucle);

            Console.Clear();

            switch (respuesta)
            {
                case 1:
                    Java version18 = new Java();
                    version18.ImprimirInfoGeneral();
                    version18.ImprimirInfoEspecifica();
                    break;
                case 2:
                    CSharp version10 = new CSharp();
                    version10.ImprimirInfoGeneral();
                    version10.ImprimirInfoEspecifica();
                    break;
            }
        }
    }

    class LenguajeProgramacion
    {
        public void ImprimirInfoGeneral()
        {
            Console.WriteLine("Soy un lenguaje especialmente creado para comunicarme con máquinas y controlar su comportamiento.");
        }
    }

    class Java : LenguajeProgramacion
    {
        public void ImprimirInfoEspecifica()
        {
            Console.WriteLine("Me denominan Java y además, soy una plataforma informática que fue comercializada por primera vez en ");
            Console.WriteLine("1995 por Sun Microsystems.");
        }
    }

    class CSharp : LenguajeProgramacion
    {
        public void ImprimirInfoEspecifica()
        {
            Console.WriteLine("Me denominan C# y fui desarrollado y estandarizado por Microsoft como parte de su plataforma .NET al ");
            Console.WriteLine("igual que, por ejemplo, Visual Basic .NET.");
        }
    }
}