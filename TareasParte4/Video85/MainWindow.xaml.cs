using System.Collections.Generic;
using System.Windows;

namespace Video85
{
    public partial class MainWindow : Window
    {
        List<Materia> listaMaterias = new List<Materia>();
        List<Materia> listaTemasMatematicas = new List<Materia>();
        List<Materia> listaTemasCiencia = new List<Materia>();
        List<Materia> listaTemasInformatica = new List<Materia>();
        List<Materia> listaTemasIngles = new List<Materia>();

        private bool evitaEvento = false;

        public MainWindow()
        {
            InitializeComponent();
            LlenarArraysTemas();
            LlenarComboBoxMaterias();
        }

        private void LlenarComboBoxMaterias()
        {
            listaMaterias.Add(new Materia("Matemáticas"));
            listaMaterias.Add(new Materia("Ciencias"));
            listaMaterias.Add(new Materia("Informática"));
            listaMaterias.Add(new Materia("Inglés"));

            cmbx_Materias.ItemsSource = listaMaterias;
        }

        private void LlenarArraysTemas()
        {
            listaTemasMatematicas.Add(new Materia("Aritmética"));
            listaTemasMatematicas.Add(new Materia("Álgebra"));
            listaTemasMatematicas.Add(new Materia("Geometría"));
            listaTemasMatematicas.Add(new Materia("Trigonometría"));
            listaTemasMatematicas.Add(new Materia("Cálculo"));
            listaTemasMatematicas.Add(new Materia("Estadística"));

            listaTemasCiencia.Add(new Materia("Biología"));
            listaTemasCiencia.Add(new Materia("Química"));
            listaTemasCiencia.Add(new Materia("Física"));
            listaTemasCiencia.Add(new Materia("Astronomía"));
            listaTemasCiencia.Add(new Materia("Geología"));

            listaTemasInformatica.Add(new Materia("Programación"));
            listaTemasInformatica.Add(new Materia("Ofimática"));
            listaTemasInformatica.Add(new Materia("Seguridad Informática"));
            listaTemasInformatica.Add(new Materia("Bases de Datos"));
            listaTemasInformatica.Add(new Materia("Conectividad y Redes"));
            listaTemasInformatica.Add(new Materia("Hacking Ético"));

            listaTemasIngles.Add(new Materia("Comunicación Oral"));
            listaTemasIngles.Add(new Materia("Comunicación Escrita"));
            listaTemasIngles.Add(new Materia("Traducción"));
        }

        private void Limpiar()
        {
            cmbx_Materias.SelectedIndex = -1;
            chckbx_Todos.IsChecked = false;

            for (byte count = 0; count < 6; count++) listaTemasMatematicas[count].Checkeado = false;
            for (byte count = 0; count < 5; count++) listaTemasCiencia[count].Checkeado = false;
            for (byte count = 0; count < 6; count++) listaTemasInformatica[count].Checkeado = false;
            for (byte count = 0; count < 3; count++) listaTemasIngles[count].Checkeado = false;
        }

        private bool CompruebaChecks(sbyte index)
        {
            switch (index)
            {
                case 0:
                    foreach(Materia temas in listaTemasMatematicas) if (!temas.Checkeado) return false;
                    break;
                case 1:
                    foreach (Materia temas in listaTemasCiencia) if (!temas.Checkeado) return false;
                    break;
                case 2:
                    foreach (Materia temas in listaTemasInformatica) if (!temas.Checkeado) return false;
                    break;
                case 3:
                    foreach (Materia temas in listaTemasIngles) if (!temas.Checkeado) return false;
                    break;
                default:
                    return false;
            }

            return true;
        }

        private void cmbx_Materias_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            sbyte index = (sbyte)cmbx_Materias.SelectedIndex;

            lstbx_Temas.ItemsSource = null;

            if (CompruebaChecks(index)) chckbx_Todos.IsChecked = true;
            else chckbx_Todos.IsChecked = false;


            switch (index) 
            {
                case 0:
                    chckbx_Todos.IsEnabled = true;
                    lstbx_Temas.ItemsSource = listaTemasMatematicas;
                    break;
                case 1:
                    chckbx_Todos.IsEnabled = true;
                    lstbx_Temas.ItemsSource = listaTemasCiencia;
                    break;
                case 2:
                    chckbx_Todos.IsEnabled = true;
                    lstbx_Temas.ItemsSource = listaTemasInformatica;
                    break;
                case 3:
                    chckbx_Todos.IsEnabled = true;
                    lstbx_Temas.ItemsSource = listaTemasIngles;
                    break;
                case -1:
                    chckbx_Todos.IsEnabled = false;
                    break;
            }
        }

        private void chckbx_Todos_Checked(object sender, RoutedEventArgs e)
        {
            sbyte index = (sbyte)cmbx_Materias.SelectedIndex;

            switch (index)
            {
                case 0:
                    for (byte count = 0; count < 6; count++) listaTemasMatematicas[count].Checkeado = true;
                    break;
                case 1:
                    for (byte count = 0; count < 5; count++) listaTemasCiencia[count].Checkeado = true;
                    break;
                case 2:
                    for (byte count = 0; count < 6; count++) listaTemasInformatica[count].Checkeado = true;
                    break;
                case 3:
                    for (byte count = 0; count < 3; count++) listaTemasIngles[count].Checkeado = true;
                    break;
            }

            lstbx_Temas.Items.Refresh();
        }

        private void chckbx_Todos_Unchecked(object sender, RoutedEventArgs e)
        {
            if(!evitaEvento)
            {
                sbyte index = (sbyte)cmbx_Materias.SelectedIndex;

                switch (index)
                {
                    case 0:
                        for (byte count = 0; count < 6; count++) listaTemasMatematicas[count].Checkeado = false;
                        break;
                    case 1:
                        for (byte count = 0; count < 5; count++) listaTemasCiencia[count].Checkeado = false;
                        break;
                    case 2:
                        for (byte count = 0; count < 6; count++) listaTemasInformatica[count].Checkeado = false;
                        break;
                    case 3:
                        for (byte count = 0; count < 3; count++) listaTemasIngles[count].Checkeado = false;
                        break;
                }

                lstbx_Temas.Items.Refresh();
            }
        }

        private void btn_Limpiar_Click(object sender, RoutedEventArgs e) { Limpiar(); }

        private void btn_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            string mensajeImpresion = "";
            bool encontrado = false;

            foreach(Materia materia in listaTemasMatematicas)
            {
                if(materia.Checkeado)
                {
                    if(!encontrado)
                    {
                        mensajeImpresion += "--- MATEMÁTICAS ---";
                        encontrado = true;
                    }
                    mensajeImpresion += "\n- " + materia.NombreMateria;
                }
            }

            encontrado = false;

            foreach (Materia materia in listaTemasCiencia)
            {
                if (materia.Checkeado)
                {
                    if (!encontrado)
                    {
                        mensajeImpresion += "\n--- CIENCIA ---";
                        encontrado = true;
                    }
                    mensajeImpresion += "\n- " + materia.NombreMateria;
                }
            }

            encontrado = false;

            foreach (Materia materia in listaTemasInformatica)
            {
                if (materia.Checkeado)
                {
                    if (!encontrado)
                    {
                        mensajeImpresion += "\n--- INFORMÁTICA ---";
                        encontrado = true;
                    }
                    mensajeImpresion += "\n- " + materia.NombreMateria;
                }
            }

            encontrado = false;

            foreach (Materia materia in listaTemasIngles)
            {
                if (materia.Checkeado)
                {
                    if (!encontrado)
                    {
                        mensajeImpresion += "\n--- INGLÉS ---";
                        encontrado = true;
                    }
                    mensajeImpresion += "\n- " + materia.NombreMateria;
                }
            }

            if (mensajeImpresion == "") MessageBox.Show("Debe seleccionar algún tema para alguna materia.");
            else
            {
                MessageBox.Show(mensajeImpresion);
                Limpiar();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)chckbx_Todos.IsChecked)
            {
                evitaEvento = true;
                chckbx_Todos.IsChecked = false;
                evitaEvento = false;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!(bool)chckbx_Todos.IsChecked)
            {
                if(CompruebaChecks((sbyte)cmbx_Materias.SelectedIndex))
                {
                    evitaEvento = true;
                    chckbx_Todos.IsChecked = true;
                    evitaEvento = false;
                }
            }
        }
    }
}