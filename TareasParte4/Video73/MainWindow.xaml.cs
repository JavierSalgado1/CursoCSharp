using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Video73
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Grid miGrid = new Grid();
            this.Content = miGrid;

            Button boton1 = new Button();
            Button boton2 = new Button();
            Button boton3 = new Button();

            boton1.Content = "Azul";
            boton2.Content = "Rojo";
            boton3.Content = "Verde";

            boton1.Width = 100;
            boton2.Width = 100;
            boton3.Width = 100;

            boton1.Height= 100;
            boton2.Height = 100;
            boton3.Height = 100;

            boton1.HorizontalAlignment = HorizontalAlignment.Left;
            boton2.HorizontalAlignment = HorizontalAlignment.Center;
            boton3.HorizontalAlignment = HorizontalAlignment.Right;

            boton1.Foreground = Brushes.Blue;
            boton2.Foreground = Brushes.Red;
            boton3.Foreground = Brushes.Green;

            miGrid.Children.Add(boton1);
            miGrid.Children.Add(boton2);
            miGrid.Children.Add(boton3);
        }
    }
}
