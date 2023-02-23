using System.Windows;

namespace Video87
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Eleccion_Click(object sender, RoutedEventArgs e)
        {
            byte validacion = ValidarSelecciones();

            switch (validacion) 
            {
                case 0:
                    string mensaje = "Instrumento: ";

                    if ((bool)rdbtn_Guitarra.IsChecked) mensaje += "Guitarra\n";
                    else mensaje += "Bajo\n";

                    if ((bool)rdbtn_21.IsChecked) mensaje += "N° de trastes: 21";
                    else if ((bool)rdbtn_22.IsChecked) mensaje += "N° de trastes: 22";
                    else mensaje += "N° de trastes: 24";

                    MessageBox.Show(mensaje);

                    break;
                case 1:
                    MessageBox.Show("Debe seleccionar una guitarra o un bajo.");
                    break;
                case 2:
                    MessageBox.Show("Debe seleccionar el número de trastes.");
                    break;
            }
        }

        private byte ValidarSelecciones()
        {
            if (!(bool)rdbtn_Guitarra.IsChecked && !(bool)rdbtn_Bajo.IsChecked) return 1;
            if (!(bool)rdbtn_21.IsChecked && !(bool)rdbtn_22.IsChecked && !(bool)rdbtn_24.IsChecked) return 2;

            return 0;
        }
    }
}
