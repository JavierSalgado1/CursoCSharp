using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;

namespace Video94
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            CapaDatos da = new CapaDatos();

            rdbttn_Nombre.IsChecked = false;
            rdbttn_Edad.IsChecked = false;

            txtbx_Nombre.Text = string.Empty;
            txtbx_EdadDesde.Text = string.Empty;
            txtbx_EdadHasta.Text = string.Empty;
            txtbx_Nombre.IsEnabled = false;
            txtbx_EdadDesde.IsEnabled = false;
            txtbx_EdadHasta.IsEnabled = false;

            lstbx_Personas.ItemsSource = null;
            lstbx_Personas.Items.Clear();
            lstbx_Personas.ItemsSource = (da.ListarPersonas()).DefaultView;
        }

        private bool ValidarFormulario()
        {
            if ((bool)rdbttn_Nombre.IsChecked)
            {
                if (string.Compare("".Trim(), txtbx_Nombre.Text) == 0)
                {
                    MessageBox.Show("Debe ingresar un nombre a buscar.");
                    return false;
                }
            }
            else
            {
                if (string.Compare("".Trim(), txtbx_EdadDesde.Text) == 0)
                {
                    MessageBox.Show("Debe ingresar una edad desde la cual a buscar.");
                    return false;
                }
                if (string.Compare("".Trim(), txtbx_EdadHasta.Text) == 0)
                {
                    MessageBox.Show("Debe ingresar una edad hasta la cual a buscar.");
                    return false;
                }

                Regex filtroNumeros = new Regex("^[0-9]+$");

                MatchCollection matchNum = filtroNumeros.Matches(txtbx_EdadDesde.Text);
                if (matchNum.Count == 0)
                {
                    MessageBox.Show("Debe ingresar una edad desde válida.");
                    return false;
                }

                matchNum = filtroNumeros.Matches(txtbx_EdadHasta.Text);
                if (matchNum.Count == 0)
                {
                    MessageBox.Show("Debe ingresar una edad hasta válida.");
                    return false;
                }
            }

            return true;
        }

        private void rdbttn_Nombre_Checked(object sender, RoutedEventArgs e)
        {
            txtbx_Nombre.IsEnabled = true;
            txtbx_EdadDesde.IsEnabled = false;
            txtbx_EdadHasta.IsEnabled = false;
        }

        private void rdbttn_Edad_Checked(object sender, RoutedEventArgs e)
        {
            txtbx_Nombre.IsEnabled = false;
            txtbx_EdadDesde.IsEnabled = true;
            txtbx_EdadHasta.IsEnabled = true;
        }

        private void bttn_Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (!(bool)rdbttn_Edad.IsChecked && !(bool)rdbttn_Nombre.IsChecked)
            {
                MessageBox.Show("Debe elegir algún filtro de búsqueda.");
            }
            else
            {
                if (ValidarFormulario())
                {
                    CapaDatos da = new CapaDatos();
                    lstbx_Personas.ItemsSource = null;
                    lstbx_Personas.Items.Clear();

                    if ((bool)rdbttn_Nombre.IsChecked)
                    {
                        lstbx_Personas.ItemsSource = (da.ListarPersonasPorNombre(txtbx_Nombre.Text)).DefaultView;
                    }
                    else
                    {
                        lstbx_Personas.ItemsSource = (da.ListarPersonasPorRangoEdad(byte.Parse(txtbx_EdadDesde.Text), byte.Parse(txtbx_EdadHasta.Text))).DefaultView;
                    }
                }
            }
        }

        private void bttn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
        }
    }
}