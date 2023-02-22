namespace Video85
{
    class Materia
    {
        private string nombreMateria;
        private bool checkeado;

        public Materia(string nombreMateria)
        {
            this.nombreMateria = nombreMateria;
            this.checkeado = false;
        }

        public string NombreMateria
        {
            get => nombreMateria;
            set => nombreMateria = value;
        }

        public bool Checkeado
        {
            get => checkeado;
            set => checkeado = value;
        }
    }
}
