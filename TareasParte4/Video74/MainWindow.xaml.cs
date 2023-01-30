using System.Windows;

namespace Video74
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImprimirTablas(byte numero)
        {
            string tabla = "";

            for(byte i = 1; i <= 15; i++)
            {
                tabla += $"{numero} x {i} = {(numero * i)}\n";
            }

            txtB_Salida.Text = tabla;
        }

        private void btn_Tabla3_Click(object sender, RoutedEventArgs e)
        {
            ImprimirTablas(3);
        }

        private void btn_Tabla7_Click(object sender, RoutedEventArgs e)
        {
            ImprimirTablas(7);
        }

        private void btn_Tabla10_Click(object sender, RoutedEventArgs e)
        {
            ImprimirTablas(10);
        }
    }
}
