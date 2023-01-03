using System;
// Realizar aplicación de consola que pida ingresar la talla de una camisa (S, M, L o XL), y que según la ingresada, imprima 
// si tiene o no tiene descuento (las tallas L y XL lo tienen). Utilizar operadores lógicos.
namespace TareasParte1
{
    class Video16
    {
        static void Main(string[] args)
        {
            string talla;

            Console.WriteLine("Ingrese la talla de la camisa (S - M - L - XL): ");
            talla = Console.ReadLine()!;

            VerificaDescuento(talla);
        }

        static void VerificaDescuento(string talla)
        {
            // La siguiente instrucción en comentarios realiza la misma comprobación que el if finalmente utilizado, solo que 
            // a través del método Compare de la clase String. Puede verse más complejo, pero es más flexible y permite realizar 
            // una comprobación más flexible. El tercer parámetro indicado como false ordena que se compruebe que el texto a 
            // comparar se encuentre tal cuál en cuanto a mayúsculas y minúsculas. Si colocamos true en vez de false, se puede 
            // omitir esta parte de la comprobación, haciendo que, por ejemplo, "xl" sea lo mismo que "XL" a la hora de evaluar 
            // el if.
            //
            // if (String.Compare(talla, "L", false) == 0 || String.Compare(talla, "XL", false) == 0)
            if(talla == "L" || talla == "XL")
            {
                Console.WriteLine($"Esta camisa talla {talla} SÍ tiene descuento.");
            }
            else
            {
                Console.WriteLine($"Ests camisa talla {talla} NO tiene descuento.");
            }
        }
    }
}