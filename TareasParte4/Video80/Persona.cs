using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video80
{
    class Persona : INotifyPropertyChanged
    {
        private string rut;
        private string nombre;
        private string apPaterno;
        private string apMaterno;
        private byte edad;
        private uint ingresoFamiliar;
        private bool guardandoRegistroNuevo = true;

        public bool GuardandoRegistroNuevo
        {
            get => guardandoRegistroNuevo;
            set
            {
                guardandoRegistroNuevo = value;
            }
        }

        public string Rut
        {
            get => rut;
            set
            {
                rut = value;
                OnPropertyChanged("GuardandoRegistroNuevo");
            }
        }

        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                OnPropertyChanged("GuardandoRegistroNuevo");
            }
        }

        public string ApPaterno
        {
            get => apPaterno;
            set
            {
                apPaterno = value;
                OnPropertyChanged("GuardandoRegistroNuevo");
            }
        }

        public string ApMaterno
        {
            get => apMaterno;
            set
            {
                apMaterno = value;
                OnPropertyChanged("GuardandoRegistroNuevo");
            }
        }

        public byte Edad
        {
            get => edad;
            set
            {
                edad = value;
                OnPropertyChanged("GuardandoRegistroNuevo");
            }
        }

        public uint IngresoFamiliar
        {
            get => ingresoFamiliar;
            set
            {
                ingresoFamiliar = value;
                OnPropertyChanged("GuardandoRegistroNuevo");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
                guardandoRegistroNuevo = false;
            }
        }
    }
}
