using System;
// Realizar aplicación de consola que simule álbumes lanzados por una disquera. Cada álbum tendrá un título, artista, año de
// lanzamiento, formato (CD, Cassette o Vinilo) y además, tendrá un identificador único. Este identificador dependerá del orden en que 
// se cree el objeto del disco de manera correlativa y ascendente (01, 02, 03, etc) y como prefijo una abreviatura del formato 
// del álbum (CD, CS, VN). Ejemplos de identificadores: CD01, CD02, CS01, CD03, VN01, CD04, CD05, VN02, etc. Utilizar alguna 
// variable o método estático.
namespace TareasSimples
{
    class Video34
    {
        static void Main(string[] args)
        {
            Album disco1 = new Album("Hallucinative Minds", "Parkcrest", 2015, "CD");
            Album disco2 = new Album("Hallucinative Minds", "Parkcrest", 2015, "Cassette");
            Album disco3 = new Album("Grimoire", "Hellish", 2016, "CD");
            Album disco4 = new Album("Grimoire", "Hellish", 2016, "Cassette");
            Album disco5 = new Album("The Spectre of Lonely Souls", "Hellish", 2018, "CD");
            Album disco6 = new Album("The Spectre of Lonely Souls", "Hellish", 2018, "Cassette");
            Album disco7 = new Album("Anacronía", "Hemisferio", 2018, "CD");
            Album disco8 = new Album("Anacronía", "Hemisferio", 2018, "Cassette");
            Album disco9 = new Album("...And That Blue Will Turn to Red", "Parkcrest", 2019, "CD");
            Album disco10 = new Album("...And That Blue Will Turn to Red", "Parkcrest", 2019, "Cassette");
            Album disco11 = new Album("No Life Forms", "Critical Defiance", 2022, "CD");
            Album disco12 = new Album("No Life Forms", "Critical Defiance", 2022, "Cassette");
            Album disco13 = new Album("No Life Forms", "Critical Defiance", 2022, "Vinilo");
            Album disco14 = new Album("Choose Your Death", "Behead", 2022, "CD");
            Album disco15 = new Album("The Dance of the Four Elemental Serpents", "Hellish", 2022, "CD");
            Album disco16 = new Album("The Dance of the Four Elemental Serpents", "Hellish", 2022, "Cassette");
            Album disco17 = new Album("The Dance of the Four Elemental Serpents", "Hellish", 2022, "Vinilo");

            Console.WriteLine($"Disco 1... Título: {disco1.GetTitulo()}\nArtista: {disco1.GetArtista()}\nID: {disco1.getId()}");
            Console.WriteLine($"Disco 2... Título: {disco2.GetTitulo()}\nArtista: {disco2.GetArtista()}\nID: {disco2.getId()}");
            Console.WriteLine($"Disco 3... Título: {disco3.GetTitulo()}\nArtista: {disco3.GetArtista()}\nID: {disco3.getId()}");
            Console.WriteLine($"Disco 4... Título: {disco4.GetTitulo()}\nArtista: {disco4.GetArtista()}\nID: {disco4.getId()}");
            Console.WriteLine($"Disco 5... Título: {disco5.GetTitulo()}\nArtista: {disco5.GetArtista()}\nID: {disco5.getId()}");
            Console.WriteLine($"Disco 6... Título: {disco6.GetTitulo()}\nArtista: {disco6.GetArtista()}\nID: {disco6.getId()}");
            Console.WriteLine($"Disco 7... Título: {disco7.GetTitulo()}\nArtista: {disco7.GetArtista()}\nID: {disco7.getId()}");
            Console.WriteLine($"Disco 8... Título: {disco8.GetTitulo()}\nArtista: {disco8.GetArtista()}\nID: {disco8.getId()}");
            Console.WriteLine($"Disco 9... Título: {disco9.GetTitulo()}\nArtista: {disco9.GetArtista()}\nID: {disco9.getId()}");
            Console.WriteLine($"Disco 10... Título: {disco10.GetTitulo()}\nArtista: {disco10.GetArtista()}\nID: {disco10.getId()}");
            Console.WriteLine($"Disco 11... Título: {disco11.GetTitulo()}\nArtista: {disco11.GetArtista()}\nID: {disco11.getId()}");
            Console.WriteLine($"Disco 12... Título: {disco12.GetTitulo()}\nArtista: {disco12.GetArtista()}\nID: {disco12.getId()}");
            Console.WriteLine($"Disco 13... Título: {disco13.GetTitulo()}\nArtista: {disco13.GetArtista()}\nID: {disco13.getId()}");
            Console.WriteLine($"Disco 14... Título: {disco14.GetTitulo()}\nArtista: {disco14.GetArtista()}\nID: {disco14.getId()}");
            Console.WriteLine($"Disco 15... Título: {disco15.GetTitulo()}\nArtista: {disco15.GetArtista()}\nID: {disco15.getId()}");
            Console.WriteLine($"Disco 16... Título: {disco16.GetTitulo()}\nArtista: {disco16.GetArtista()}\nID: {disco16.getId()}");
            Console.WriteLine($"Disco 17... Título: {disco17.GetTitulo()}\nArtista: {disco17.GetArtista()}\nID: {disco17.getId()}");
        }
    }

    class Album
    {
        private string id = "";
        private static byte numeroCD = 0;
        private static byte numeroCassette = 0;
        private static byte numeroVinilo = 0;
        private string titulo;
        private string artista;
        private ushort año;
        private string formato;

        public Album(string titulo, string artista, ushort año, string formato)
        {
            if (String.Compare(formato, "CD", true) == 0 || String.Compare(formato, "Cassette", true) == 0 || String.Compare(formato, "Vinilo", true) == 0)
            {
                this.formato = formato;
            }
            else
            {
                Console.WriteLine("El formato a ingresar debe ser 'CD', 'Cassette' o 'Vinilo'.");
                throw new FormatException();
            }

            this.titulo = titulo;
            this.artista = artista;
            this.año = año;

            switch (formato)
            {
                case "CD":
                    this.id = "CD";
                    numeroCD ++;
                    if (numeroCD < 10)
                    {
                        this.id += "0" + numeroCD;
                    }
                    else
                    {
                        this.id += numeroCD;
                    }
                    break;
                case "Cassette":
                    this.id = "CS";
                    numeroCassette ++;
                    if (numeroCassette < 10)
                    {
                        this.id += "0" + numeroCassette;
                    }
                    else
                    {
                        this.id += numeroCassette;
                    }
                    break;
                case "Vinilo":
                    this.id = "VN";
                    numeroVinilo ++;
                    if (numeroVinilo < 10)
                    {
                        this.id += "0" + numeroVinilo;
                    }
                    else
                    {
                        this.id += numeroVinilo;
                    }
                    break;
            }
        }

        public string getId() => this.id;
        public string GetArtista() => this.artista;
        public string GetTitulo() => this.titulo;
        public ushort GetAño() => this.año;

        public void SetArtista(string artista) => this.artista = artista;
        public void SetTitulo(string titulo) => this.titulo = titulo;
        public void SetAño (byte año) => this.año = año;
    }
}