using System;
// Realizar aplicación de consola que pida los datos personales de una persona y luego imprima en pantalla una presentación 
// redactada de la misma. Utilizar método/s con paso de parámetros y que retornen un valor.
namespace TareasSimples
{
    class Video11
    {
        static void Main(string[] args)
        {
            // El tipo de dato string permite almacenar texto. Para asignarle un valor, se hace a través de comillas dobles ("") 
            // como en el siguiente ejemplo --------> string nombre = "Juanito Pérez";
            string nombre;
            byte edad;
            ulong telefono;

            Console.Write("Ingrese su nombre: ");
            // Como el método ReadLine de la clase Console devuelve un dato de tipo string, no es necesario realizar un parseo 
            // o conversión del dato, como en los demás casos.
            nombre = Console.ReadLine()!;

            // Se agrega "!" luego de readline para indicar al compilador que el programa está preparado para recibir un valor 
            // nulo en la variable num1, y así evitar una advertencia por parte del compilador.
            Console.Write("Ingrese su edad: ");
            edad = byte.Parse(Console.ReadLine()!);

            Console.Write("Ingrese su número de teléfono: ");
            telefono = ulong.Parse(Console.ReadLine()!);

            Console.WriteLine("--------------------------------------");
            // Se imprime el valor devuelto por el método MostrarInformacionPersonal.
            Console.WriteLine(MostrarInformacionPersonal(nombre, edad, telefono));         
            Console.WriteLine("--------------------------------------");
        }

        static string MostrarInformacionPersonal(string nombre, byte edad, ulong telefono)
        {
            string mensaje;

            // Se concatenan los valores pasados por parámetro con el mensaje.
            mensaje = $"Tu nombre es {nombre}, tienes {edad} años de edad y tu número de teléfono es {telefono}.";

            // Se devuelve el valor del mensaje.
            return mensaje;
        }
    }
}