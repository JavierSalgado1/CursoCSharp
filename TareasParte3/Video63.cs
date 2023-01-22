// Realizar aplicación de consola que permita agregar objetos de tipo Cerveza. Las cervezas deberán llevar nombre, tipo y graduación 
// alcohólica. El usuario podrá agregar cervezas, listarlas, modificarlas, eliminarlas y buscarlas por nombre. Utilizar Colección List.
using System.Collections.Generic;

namespace TareasParte3
{
    class Video63
    {
        static void Main(string[] args)
        {
            Console.Clear();

            List<Cerveza> listaCervezas = new List<Cerveza>();

            byte opcion = 0;
            bool opcionYaEscogida = false;

            do
            {
                try
                {
                    Console.WriteLine("----- MENÚ GESTIÓN DE CERVEZAS -----");
                    Console.WriteLine("¿Qué acción desea realizar?\n1) Agregar nueva Cerveza\n2) Modificar Cerveza.");
                    Console.WriteLine("3) Eliminar Cerveza\n4) Ver lista de Cervezas\n5) Buscar Cerveza por nombre\n6) Salir");
                    Console.Write("Elección: ");
                    opcion = byte.Parse(Console.ReadLine()!);

                    if(opcion < 1 || opcion > 6) throw new Exception();
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            listaCervezas.Add(AgregarCerveza());
                            break;
                        case 2:
                            ModificarCerveza(listaCervezas);
                            break;
                        case 3:
                            EliminarCerveza(listaCervezas);
                            break;
                        case 4:
                            ListarCervezas(listaCervezas, true);
                            break;
                        case 5:
                            BuscarCerveza(listaCervezas);
                            break;
                        case 6:
                            opcionYaEscogida = true;
                            break;
                    }
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un número del 1 al 6.");
                }
            }
            while (!opcionYaEscogida);
        }

        static Cerveza AgregarCerveza()
        {
            bool agregadaCorrectamente = false;
            string nombre = "", tipo = "";
            double graduacionAlcoholica = 0;

            do
            {
                try
                {
                    Console.WriteLine("--- Nueva Cerveza ---");
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine()!;
                    Console.Write("Tipo: ");
                    tipo = Console.ReadLine()!;
                    Console.Write("Graduación Alcohólica: ");
                    graduacionAlcoholica = double.Parse(Console.ReadLine()!);

                    agregadaCorrectamente = true;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
            while (!agregadaCorrectamente);
            
            return new Cerveza(nombre, tipo, graduacionAlcoholica);
        }

        static void ModificarCerveza(List<Cerveza> listaCervezas)
        {
            bool modificadaCorrectamente = false;
            bool eleccionCorrecta = false;
            byte numCerveza = 0;
            string nombre = "", tipo = "";
            double graduacionAlcoholica = 0;

            if (listaCervezas.Count == 0)
            {
                Console.WriteLine("Aún no ha guardado ninguna cerveza.");
                Console.WriteLine("Ingrese [Enter para continuar]...");
                Console.ReadLine();
            }
            else
            {
                ListarCervezas(listaCervezas, false);

                do
                {
                    try
                    {
                        Console.Write("Ingrese el número de la cerveza que desea modificar: ");
                        numCerveza = byte.Parse(Console.ReadLine()!);

                        if(numCerveza > listaCervezas.Count) throw new Exception();
                        eleccionCorrecta = true;
                    }
                    catch (System.Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Debe ingresar un número del 1 al " + listaCervezas.Count);
                    }
                } 
                while (!eleccionCorrecta);

                numCerveza -= 1;
                Console.Clear();

                do
                {
                    try
                    {
                        Console.WriteLine("--- Modificar Cerveza ---");
                        Console.Write("Nombre actual: " + listaCervezas[numCerveza].Nombre + "\nNuevo nombre: ");
                        nombre = Console.ReadLine()!;
                        Console.Write("Tipo actual: " + listaCervezas[numCerveza].Tipo + "\nNuevo tipo: ");
                        tipo = Console.ReadLine()!;
                        Console.Write("Graduación Alcohólica: " + listaCervezas[numCerveza].GraduacionAlcoholica + "\nNueva Graduación Alcohólica: ");
                        graduacionAlcoholica = double.Parse(Console.ReadLine()!);

                        listaCervezas[numCerveza].Nombre = nombre;
                        listaCervezas[numCerveza].Tipo = tipo;
                        listaCervezas[numCerveza].GraduacionAlcoholica = graduacionAlcoholica;

                        modificadaCorrectamente = true;
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                    }
                }
                while (!modificadaCorrectamente);
            }
        }

        static void EliminarCerveza(List<Cerveza> listaCervezas)
        {
            bool eleccionCorrecta = false;
            byte numCerveza = 0;
            string nombre;

            if (listaCervezas.Count == 0)
            {
                Console.WriteLine("Aún no ha guardado ninguna cerveza.");
                Console.WriteLine("Ingrese [Enter para continuar]...");
                Console.ReadLine();
            }
            else
            {
                ListarCervezas(listaCervezas, false);

                do
                {
                    try
                    {
                        Console.Write("Ingrese el número de la cerveza que desea eliminar: ");
                        numCerveza = byte.Parse(Console.ReadLine()!);

                        if(numCerveza > listaCervezas.Count) throw new Exception();
                        eleccionCorrecta = true;
                    }
                    catch (System.Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Debe ingresar un número del 1 al " + listaCervezas.Count);
                    }
                } 
                while (!eleccionCorrecta);

                numCerveza -= 1;

                nombre = listaCervezas[numCerveza].Nombre;
                listaCervezas.RemoveAt(numCerveza);

                Console.Clear();
                Console.WriteLine($"Cerveza {nombre} eliminada.");
                Console.WriteLine("Ingrese [Enter para continuar]...");
                Console.ReadLine();
            }
        }

        static void ListarCervezas(List<Cerveza> listaCervezas, bool accionListarUnicamente)
        {
            byte contador = 1;

            if (listaCervezas.Count == 0)
            {
                Console.WriteLine("Aún no ha guardado ninguna cerveza.");
                Console.WriteLine("Ingrese [Enter para continuar]...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Lista de Cervezas:\n");

                foreach(Cerveza cervecita in listaCervezas)
                {
                    // \t indica una tabulación, así como \n indica un salto de línea.
                    Console.WriteLine($"{contador}) {cervecita.Nombre}\t\t\tTipo: {cervecita.Tipo}\t\t\tGraduación Alcohólica: {cervecita.GraduacionAlcoholica}°");
                    contador++;
                }

                if (accionListarUnicamente)
                {
                    Console.WriteLine("Ingrese [Enter para continuar]...");
                    Console.ReadLine();
                }
            }
        }
        
        static void BuscarCerveza(List<Cerveza> listaCervezas)
        {
            string nombreCerveza;
            bool nombreIngresado = false;
            byte contadorCervezas = 0;

            if (listaCervezas.Count == 0)
            {
                Console.WriteLine("Aún no ha guardado ninguna cerveza.");
                Console.WriteLine("Ingrese [Enter para continuar]...");
                Console.ReadLine();
            }
            else
            {
                do
                {
                    nombreCerveza = "";
                    Console.WriteLine("Ingrese el nombre de la cerveza a buscar: ");
                    nombreCerveza = Console.ReadLine()!;

                    if(String.Compare(nombreCerveza.Trim(), "") == 0) Console.WriteLine("Debe ingresar texto para poder realizar la búsqueda.");
                    else nombreIngresado = true;
                } 
                while (!nombreIngresado);

                for(ushort i = 0; i < listaCervezas.Count; i++)
                {
                    if (String.Compare(nombreCerveza, listaCervezas[i].Nombre, false) == 0)
                    {
                        if (contadorCervezas == 0) Console.WriteLine("Resultados de la búsqueda: ");

                        Console.WriteLine($"Nombre: {listaCervezas[i].Nombre}\t\t\tTipo: {listaCervezas[i].Tipo}\t\t\tGraduación Alcohólica: {listaCervezas[i].GraduacionAlcoholica}°");
                        contadorCervezas++;
                    }
                }

                if (contadorCervezas == 0) Console.WriteLine("No se encontraron coincidencias.");

                Console.WriteLine("Ingrese [Enter para continuar]...");
                Console.ReadLine();
            }
        }
    }

    class Cerveza
    {
        private string nombre;
        private string tipo;
        private double graduacionAlcoholica;

        public Cerveza(string nombre, string tipo, double graduacionAlcoholica)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.graduacionAlcoholica = graduacionAlcoholica;
        }

        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = value;
        }

        public string Tipo 
        {
            get => this.tipo;
            set => this.tipo = value;
        }

        public double GraduacionAlcoholica 
        {
            get => this.graduacionAlcoholica;
            set => this.graduacionAlcoholica = value;
        }
    }
}