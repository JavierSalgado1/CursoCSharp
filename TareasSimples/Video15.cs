using System;
// Realizar aplicación de consola que pida un correo y contraseña al usuario. Informar al usuario si los datos son correctos o no.
// Predefinir los datos de login. Utilizar operadores lógicos e instrucción else.
namespace TareasSimples
{
    class Video15
    {
        static void Main(string[] args)
        {
            string correoIntroducido;
            string passwordIntroducida;

            //Se usa Write en vez de WriteLine para evitar que se realice un salto de línea después del mensaje.
            Console.Write("Ingrese su correo: ");
            // Se agrega "!" luego de readline para indicar al compilador que el programa está preparado para recibir un valor 
            // nulo en la variable num1, y así evitar una advertencia por parte del compilador.
            correoIntroducido = Console.ReadLine()!;

            Console.Write("Ingrese la contraseña: ");
            passwordIntroducida = Console.ReadLine()!;

            if(ValidarCorreo(correoIntroducido, passwordIntroducida))
            {
                Console.WriteLine("Login exitoso.");
            }
            else
            {
                Console.WriteLine("Datos incorrectos.");
            }
        }

        static bool ValidarCorreo(string correo, string password)
        {
            if(correo == "hellishblackthrash@niidea.com" && password == "contra123seña")
            {
                return true;
            }
            return false;
        }
    }
}