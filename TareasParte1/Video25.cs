using System;
// Realizar aplicación de consola que pida al usuario loguearse con un email y contraseña. El programa debe pedir los datos 
// hasta que coincida con unos predefinidos. En caso de que el usuario ingrese el email sin "@", se debe devolver una FormatException.
// PISTA: Averiguar sobre el método Contains de la clase String. 
namespace TareasParte1
{
    class Video25
    {
        // Se definen las variables como static ya que serán variables de clase (más adelante en el curso se profundizará en ello).
        static string email = "parkcrestthrashmetal@hotmail.com";
        static string password = "contra321seña";

        static void Main(string[] args)
        {
            bool logueado = false;
            string emailIngresado;
            string passwordIngresada;

            do
            {
                Console.Write("Ingrese su correo: ");
                emailIngresado = Console.ReadLine()!;

                Console.Write("Ingrese su contraseña: ");
                passwordIngresada = Console.ReadLine()!;

                try
                {
                    if (ValidaLogin(emailIngresado, passwordIngresada))
                    {
                        Console.WriteLine("Login Exitoso.");
                        logueado = true;
                    }
                    else
                    {
                        Console.WriteLine("Datos incorrectos; inténtelo nuevamente.");
                    }
                }
                catch (Exception ex)
                {                
                    Console.WriteLine("EXCEPCIÓN: " + ex.Message);
                }                
            }
            // Debido a que while evalúa una expresión booleana, no es necesario escribir en este caso "logueado == false".
            while(!logueado);
        }

        static bool ValidaLogin(string emailIngresado, string passwordIngresada)
        {
            // Como tercer parámetro del método Compare (ignoreCase), se envía true para la verificación del email, ya que no 
            // importan las mayúsculas ni minúsculas al evaluar un correo, no así con las contraseñas; es por esto que al 
            // validar la contraseña, se envía este parámetro como false.
            if (String.Compare(emailIngresado, email, true) == 0 && String.Compare(passwordIngresada, password, false) == 0)
            {
                return true;
            }
            // Se utiliza el método Contains de la clase String para verificar si en emailIngresado existe el carácter @.
            // Si existe, devuelve true, y sino, false. En este caso, se antepone el ! para entrar dentro del código del else if 
            // si es que el email no contiene arroba.
            else if(!emailIngresado.Contains("@"))
            {
                throw new FormatException();
            }
            else
            {
                return false;
            }            
        }
    }
}