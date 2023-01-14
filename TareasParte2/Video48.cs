// Realizar aplicación de consola que simule manejar un personaje de un juego de peleas 2D. Cualquier personaje debiese implementar una 
// interfaz que le permita realizar un ataque especial y una "ulti", además de sus combos propios.
namespace TareasParte2
{
    class Video48
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Personaje miPersonaje = new Personaje();

            byte contador = 1;
            byte eleccion;

            do
            {
                Console.WriteLine($"----- El siguiente es tu movimiento n° {contador} de 5 -----");
                Console.WriteLine("Ingresa un movimiento: ");
                Console.WriteLine("1) Puñetazo\n2) Patada\n3) Ataque Especial\n4) Ulti");

                try
                {
                    eleccion = byte.Parse(Console.ReadLine()!);

                    switch (eleccion)
                    {
                        case 1:
                            Console.WriteLine(miPersonaje.DarPuñetazo());
                            break;
                        case 2:
                            Console.WriteLine(miPersonaje.DarPatada());
                            break;
                        case 3:
                            Console.WriteLine(miPersonaje.UtilizarAtaqueEspecial());
                            break;
                        case 4:
                            Console.WriteLine(miPersonaje.UtilizarUltiEspecial());
                            break;
                        default:
                            throw new Exception();
                    }

                    contador++;
                }
                catch (Exception)
                {
                    Console.WriteLine("Debe ingresar un 1, un 2, un 3 ó un 4.");
                }
            }
            while (contador <= 5);

            Console.WriteLine("----- FIN DEL JUEGO -----");
        }
    }

    class Personaje : IPersonaje
    {
        private short hp;
        private short mp;

        public Personaje()
        {
            this.hp = 10000;
            this.mp = 3000;
        }

        public short GetHp() => this.hp;
        public short GetMP() => this.mp;

        public string DarPuñetazo()
        {
            return "Has dado un puñetazo.";
        }

        public string DarPatada()
        {
            return "Has dado una patada.";
        }

        public string UtilizarAtaqueEspecial()
        {
            if (this.mp >= 750)
            {
                this.mp = (short)(mp - 750);
                return "Has utilizado el ataque especial.";
            }
            else
            {
                return "No tienes suficientes Magic Points para realizar el ataque especial.";
            }
        }

        public string UtilizarUltiEspecial()
        {
            if (this.mp >= 1500)
            {
                this.mp = (short)(mp - 1500);
                return "Has utilizado la Ulti de tu personaje.";
            }
            else
            {
                return "No tienes suficientes Magic Points para realizar la Ulti de tu personaje.";
            }
        }
    }

    interface IPersonaje
    {
        string UtilizarAtaqueEspecial();
        string UtilizarUltiEspecial();
    }
} 