// Realizar aplicación de consola que pida al usuario ingresar un texto, y luego deberá informar cuántas vocales con tilde hay. Utilizar 
// bucle foreach.
namespace TareasParte2
{
    class Video39
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Cuéntenos por qué debiéramos contratarlo como asesor de gramática.\n");
            string explicacion = Console.ReadLine()!;
            ushort contadorTildes = 0;

            foreach(char letra in explicacion)
            {
                // Se transforma la letra a mayúscula para que, en caso de ser minúscula, se considere exactamente igual, y así reducir 
                // el condicional escrito en el if. 
                char letraMayúscula = Char.ToUpper(letra);

                if (letraMayúscula == 'Á'|| letraMayúscula == 'É' || letraMayúscula == 'Í' || letraMayúscula == 'Ó' || letraMayúscula == 'Ú')
                {
                    contadorTildes++;
                }
            }

            Console.WriteLine("\n---------------------------------\nEn tu texto se encontraron " + contadorTildes + " vocales con tilde.");
        }
    }
}