using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Video83
{
    public partial class MainWindow : Window
    {
        List<Album> listaDiscos = new List<Album>();

        public MainWindow()
        {
            InitializeComponent();
            LimpiarFormulario();
            lstBx_Discos.ItemsSource = listaDiscos;
        }

        private void AgregarAlbum()
        {
            Album nuevoDisco = ObtenerDatosFormulario();

            if (nuevoDisco != null)
            {
                if (!ExisteAlbum(nuevoDisco.Nombre))
                {
                    if (ValidarDatos(nuevoDisco))
                    {
                        listaDiscos.Add(nuevoDisco);
                        MessageBox.Show("Álbum agregado exitosamente.");
                        lstBx_Discos.Items.Refresh();
                        LimpiarFormulario();
                    }
                }
                else
                {
                    MessageBox.Show("Este álbum ya existe. No se puede agregar.");
                    LimpiarFormulario();
                }
            }
        }

        private void LimpiarFormulario()
        {
            txt_Nombre.Text = string.Empty;
            txt_Artista.Text = string.Empty;
            txt_Tipo.Text = string.Empty;
            txt_TrackList.Document.Blocks.Clear();
            lbl_Valoracion.Text = "0";
        }

        private bool ExisteAlbum(string nombre)
        {
            foreach(Album album in listaDiscos) 
            {
                if (String.Compare(album.Nombre, nombre) == 0) return true;
            }

            return false;
        }

        private bool ValidarDatos(Album disco)
        {
            if(disco.Nombre == "")
            {
                MessageBox.Show("El nombre del álbum no puede ir vacío.");
                return false;
            }

            if (disco.Artista == "")
            {
                MessageBox.Show("El artista del álbum no puede ir vacío.");
                return false;
            }

            if (disco.Tipo == "")
            {
                MessageBox.Show("El tipo del álbum no puede ir vacío.");
                return false;
            }

            if (disco.TrackList == "")
            {
                MessageBox.Show("El track list del álbum no puede ir vacío.");
                return false;
            }

            return true;
        }

        private Album ObtenerDatosFormulario()
        {
            Album disco = new Album();

            try { disco.Nombre = txt_Nombre.Text; } 
            catch 
            {
                MessageBox.Show("El nombre ingresado es inválido.");
                return null;
            }
            
            try { disco.Artista = txt_Artista.Text; } 
            catch 
            {
                MessageBox.Show("El artista ingresado es inválido.");
                return null;
            }

            try { disco.Tipo = txt_Tipo.Text; }
            catch 
            {
                MessageBox.Show("El tipo ingresado es inválido.");
                return null;
            }

            try { disco.Valoracion = byte.Parse(lbl_Valoracion.Text.ToString()); }
            catch
            {
                MessageBox.Show("La valoración ingresada es inválida.");
                return null;
            }

            try { disco.TrackList = StringFromRichTextBox(txt_TrackList); }
            catch
            {
                MessageBox.Show("El tracklist ingresado es inválido.");
                return null;
            }

            return disco;
        }

        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }

        private void lstBx_Discos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBx_Discos.SelectedItem != null)
            {
                txt_TrackList.Document.Blocks.Clear();

                txt_Nombre.Text = (lstBx_Discos.SelectedItem as Album).Nombre;
                txt_Artista.Text = (lstBx_Discos.SelectedItem as Album).Artista;
                txt_Tipo.Text = (lstBx_Discos.SelectedItem as Album).Tipo;
                txt_TrackList.Document.Blocks.Add(new Paragraph(new Run((lstBx_Discos.SelectedItem as Album).TrackList)));
                lbl_Valoracion.Text = (lstBx_Discos.SelectedItem as Album).Valoracion.ToString();
            }
        }

        private void EliminarAlbum()
        {
            if (lstBx_Discos.SelectedItem != null)
            {
                byte contador = 0;

                foreach (Album disco in listaDiscos)
                {
                    if (disco.Nombre == (lstBx_Discos.SelectedItem as Album).Nombre)
                    {
                        listaDiscos.RemoveAt(contador);
                        MessageBox.Show("Se ha eliminado el disco exitosamente");
                        LimpiarFormulario();
                        lstBx_Discos.Items.Refresh();
                        break;
                    }
                    contador++;
                }
            }
            else MessageBox.Show("Debe seleccionar un álbum para poder eliminar.");
        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e) { AgregarAlbum(); }
        private void btn_Eliminar_Click(object sender, RoutedEventArgs e) { EliminarAlbum(); }
    }
}