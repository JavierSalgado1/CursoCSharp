namespace Video83
{
    class Album
    {
        private string nombre;
        private string artista;
        private string tipo;
        private string trackList;
        private byte valoracion;

        public Album(string nombre, string artista, string tipo, string trackList, byte valoracion) 
        {
            this.nombre = nombre;
            this.artista = artista;
            this.tipo = tipo;
            this.trackList = trackList;
            this.valoracion = valoracion;
        }

        public Album() { }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Artista { get => artista; set => artista = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string TrackList { get => trackList; set => trackList = value; }
        public byte Valoracion { get => valoracion; set => valoracion = value; }
    }
}
