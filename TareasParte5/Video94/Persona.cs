using System.Collections.Generic;
using System.Data;

namespace Video94
{
    class Persona
    {
        private int id;
        private string nombre;
        private string apPaterno;
        private string apMaterno;
        private byte edad;
        private bool sexo; // false = mujer, true = hombre

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string ApPaterno
        {
            get => apPaterno;
            set => apPaterno = value;
        }

        public string ApMaterno
        {
            get => apMaterno;
            set => apMaterno = value;
        }

        public byte Edad
        {
            get => edad;
            set => edad = value;
        }

        public bool Sexo
        {
            get => sexo;
            set => sexo = value;
        }
    }
}
