// Realizar aplicación de consola que pida al usuario ingresar una contraseña que cumpla con las características de una contraseña fuerte, 
// es decir, que contenga al menos una minúscula, una mayúscula, un número, un carácter especial y al menos 8 carácteres de longitud.
// Utilizar expresiones regulares para las validaciones.
using System.Text.RegularExpressions;

namespace TareasParte3
{
    class Video72
    {
        static void Main(string[] args)
        {
            Console.Clear();

            bool passwordCorrecta = false;
            string passwordIngresada = "";

            do
            {
                try
                {
                    Console.Write("Ingrese una contraseña: ");
                    passwordIngresada = Console.ReadLine()!;

                    if (String.Compare(passwordIngresada.Replace(" ", ""), "") == 0) throw new Exception();

                    passwordCorrecta = ValidarContraseña(passwordIngresada);
                }
                catch(Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un texto válido y sin espacios en blanco.");
                }
            }
            while (!passwordCorrecta);

            Console.WriteLine($"La contraseña {passwordIngresada} cumple con los requisitos.");
        }

        static bool ValidarContraseña(string passwordIngresada)
        {
            Regex filtroEspacios = new Regex(" ");
            Regex filtroMin = new Regex(@"[a-z]+");
            Regex filtroMay = new Regex(@"[A-Z]+");
            Regex filtroNum = new Regex(@"\d+");
            Regex filtroEsp = new Regex(@"[°\||!|""|#|$|%|/|\(|\)|=|?|¿|'|¡|\\|*|´|¨|{|}|^|\[|\]|-|_|.|,|;|:]+");

            MatchCollection matchEspacios = filtroEspacios.Matches(passwordIngresada);
            MatchCollection matchMin = filtroMin.Matches(passwordIngresada);
            MatchCollection matchMay = filtroMay.Matches(passwordIngresada);
            MatchCollection matchNum = filtroNum.Matches(passwordIngresada);
            MatchCollection matchEsp = filtroEsp.Matches(passwordIngresada);

            if (matchEspacios.Count == 0)
            {
                if (matchMin.Count > 0)
                {
                    if(matchMay.Count > 0) 
                    {
                        if(matchNum.Count > 0)
                        {
                            if (matchEsp.Count > 0)
                            {
                                if(passwordIngresada.Length >= 8)
                                {
                                    return true;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("La contraseña debe tener como mínimo 8 carácteres.");
                                    return false;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Debe ingresar al menos un carácter especial.");
                                return false;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Debe ingresar al menos un número.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Debe ingresar al menos una mayúscula.");
                        return false;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar al menos una minúscula.");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No puede ingresar espacios en blanco.");
                return false;
            }
        }
    }
}
