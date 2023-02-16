using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace Video80
{
    public partial class MainWindow : Window
    {
        List<Persona> listaPersonas = new List<Persona>();

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            if(ValidarDatos())
            {
                sbyte index = ExistePersona(txt_Rut.Text);

                if (index == -1)
                {
                    Persona persona = new Persona();
                    persona = ObtenerDatosFormulario();
                    listaPersonas.Add(persona);

                    MessageBox.Show("Se ha guardado exitosamente.");
                    LimpiarFormulario();
                }
                else
                {
                    if (!listaPersonas[index].GuardandoRegistroNuevo)
                    {
                        listaPersonas[index].Nombre = txt_Nombre.Text;
                        listaPersonas[index].ApPaterno = txt_ApPaterno.Text;
                        listaPersonas[index].ApMaterno = txt_ApMaterno.Text;
                        listaPersonas[index].Edad = byte.Parse(txt_Edad.Text);
                        listaPersonas[index].IngresoFamiliar = uint.Parse(txtBlck_Ingreso.Text);
                        listaPersonas[index].GuardandoRegistroNuevo = true;

                        MessageBox.Show("Se ha modificado exitosamente.");
                        LimpiarFormulario();
                    }

                    else MessageBox.Show("No ha realizado ninguna modificación.");
                }
            } 
        }

        private sbyte ExistePersona(string rut)
        {
            sbyte contador = 0;

            foreach (Persona persona in listaPersonas)
            {
                if (rut == persona.Rut) return contador;
                contador++;
            }
            return -1;
        }

        private Persona ObtenerDatosFormulario()
        {
            Persona persona = new Persona();

            persona.Rut = txt_Rut.Text;
            persona.Nombre = txt_Nombre.Text;
            persona.ApPaterno = txt_ApPaterno.Text;
            persona.ApMaterno = txt_ApMaterno.Text;
            try
            {
                persona.Edad = byte.Parse(txt_Edad.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar una edad válida.");
            }
            persona.IngresoFamiliar = uint.Parse(txtBlck_Ingreso.Text);

            return persona;
        }

        private bool ValidarDatos()
        {
            if(txt_Rut.Text == "")
            {
                MessageBox.Show("Debe ingresar un rut.");
                return false;
            }

            if(txt_Nombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la persona.");
                return false;
            }

            if(txt_ApPaterno.Text == "")
            {
                MessageBox.Show("Debe ingresar el apellido paterno de la persona.");
                return false;
            }

            if(txt_ApMaterno.Text == "")
            {
                MessageBox.Show("Debe ingresar el apellido materno de la persona.");
                return false;
            }

            if(txt_Edad.Text == "")
            {
                MessageBox.Show("Debe ingresar una edad válida.");
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txt_Rut.Text = String.Empty;
            txt_Nombre.Text = String.Empty;
            txt_ApPaterno.Text = String.Empty;
            txt_ApMaterno.Text = String.Empty;
            txt_Edad.Text = String.Empty;
            txtBlck_Ingreso.Text = sldr_Ingreso.Minimum.ToString();
            this.DataContext = null;
        }

        private void TraerDatos()
        {
            sbyte index = ExistePersona(txt_Rut.Text);

            if (index == -1)
            {
                MessageBox.Show("No existe ninguna persona con ese Rut.");
            }
            else
            {
                txt_Nombre.Text = listaPersonas[index].Nombre;
                txt_ApPaterno.Text = listaPersonas[index].ApPaterno;
                txt_ApMaterno.Text = listaPersonas[index].ApMaterno;
                txt_Edad.Text = listaPersonas[index].Edad.ToString();
                txtBlck_Ingreso.Text = listaPersonas[index].IngresoFamiliar.ToString();

                this.DataContext = listaPersonas[index];
            }
        }

        private void txt_Rut_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) { this.DataContext = null; }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            sbyte index = ExistePersona(txt_Rut.Text);

            if (index == -1)
            {
                MessageBox.Show("No hay ninguna persona que eliminar con ese rut.");
            }
            else
            {
                listaPersonas.RemoveAt(index);
                MessageBox.Show("Se he eliminado la persona exitosamente.");
                LimpiarFormulario();
            }
        }

        private void btn_Limpiar_Click(object sender, RoutedEventArgs e) { LimpiarFormulario(); }
        private void btn_Traer_Click(object sender, RoutedEventArgs e) { TraerDatos(); }
    }
}