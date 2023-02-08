using System;
using System.Windows;
using System.Windows.Input;

namespace Video76
{
    public partial class MainWindow : Window
    {
        private bool enOperacion = false;

        public MainWindow()
        {
            InitializeComponent();
            txtBlck_Pantalla.Focusable = true;
            txtBlck_Pantalla.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Key tecla = e.Key;

            switch (tecla)
            {
                case Key.Escape:
                    BorrarTodo();
                    break;
                case Key.D0:
                    IngresaNumero("0");
                    break;
                case Key.D1:
                    IngresaNumero("1");
                    break;
                case Key.D2:
                    IngresaNumero("2");
                    break;
                case Key.D3:
                    IngresaNumero("3");
                    break;
                case Key.D4:
                    IngresaNumero("4");
                    break;
                case Key.D5:
                    IngresaNumero("5");
                    break;
                case Key.D6:
                    IngresaNumero("6");
                    break;
                case Key.D7:
                    IngresaNumero("7");
                    break;
                case Key.D8:
                    IngresaNumero("8");
                    break;
                case Key.D9:
                    IngresaNumero("9");
                    break;
                case Key.NumPad0:
                    IngresaNumero("0");
                    break;
                case Key.NumPad1:
                    IngresaNumero("1");
                    break;
                case Key.NumPad2:
                    IngresaNumero("2");
                    break;
                case Key.NumPad3:
                    IngresaNumero("3");
                    break;
                case Key.NumPad4:
                    IngresaNumero("4");
                    break;
                case Key.NumPad5:
                    IngresaNumero("5");
                    break;
                case Key.NumPad6:
                    IngresaNumero("6");
                    break;
                case Key.NumPad7:
                    IngresaNumero("7");
                    break;
                case Key.NumPad8:
                    IngresaNumero("8");
                    break;
                case Key.NumPad9:
                    IngresaNumero("9");
                    break;
                case Key.Add:
                    Sumar();
                    break;
                case Key.OemPlus:
                    Sumar();
                    break;
                case Key.OemMinus:
                    Restar();
                    break;
                case Key.Subtract:
                    Restar();
                    break;
                case Key.Multiply:
                    Multiplicar();
                    break;
                case Key.Divide:
                    Dividir();
                    break;
                case Key.OemComma:
                    IngresaNumero(",");
                    break;
                case Key.Decimal:
                    IngresaNumero(",");
                    break;
                default:
                    string nombreTecla = tecla.ToString();
                    if(String.Compare(nombreTecla, "Return") == 0) IgualA();
                    else if(String.Compare(nombreTecla, "Back") == 0) BorrarNumero();
                    break;
            }
            this.Focus();
        }

        private void Borrar()
        {
            txtBlck_Pantalla.Text = "0";
            if (!btn_Coma.IsEnabled) ActivarBotonesSolucionadoError();
        }

        private void BorrarTodo()
        {
            txtBlck_Operaciones.Text = "";
            txtBlck_Pantalla.Text = "0";
            if (!btn_Coma.IsEnabled) ActivarBotonesSolucionadoError();
        }

        private void BorrarNumero()
        {
            txtBlck_Pantalla.Text = (txtBlck_Pantalla.Text).Remove(txtBlck_Pantalla.Text.Length - 1, 1);

            if (String.Compare(txtBlck_Pantalla.Text, "") == 0) txtBlck_Pantalla.Text = "0";
            if (!btn_Coma.IsEnabled) ActivarBotonesSolucionadoError();
        }
        private void Sumar()
        {
            if ((txtBlck_Operaciones.Text).IndexOf("+") == -1 || (txtBlck_Operaciones.Text).IndexOf("=") != -1)
            {
                txtBlck_Operaciones.Text = txtBlck_Pantalla.Text + " + ";
                enOperacion = true;
            }
            else
            {
                ResolverSuma();
            }
        }

        private void Restar()
        {
            if ((txtBlck_Operaciones.Text).IndexOf("-") == -1 || (txtBlck_Operaciones.Text).IndexOf("=") != -1)
            {
                txtBlck_Operaciones.Text = txtBlck_Pantalla.Text + " - ";
                enOperacion = true;
            }
            else
            {
                ResolverResta();
            }
        }

        private void Multiplicar()
        {
            if ((txtBlck_Operaciones.Text).IndexOf("x") == -1 || (txtBlck_Operaciones.Text).IndexOf("=") != -1)
            {
                txtBlck_Operaciones.Text = txtBlck_Pantalla.Text + " x ";
                enOperacion = true;
            }
            else
            {
                ResolverMultiplicacion();
            }
        }

        private void Dividir()
        {
            if ((txtBlck_Operaciones.Text).IndexOf("÷") == -1 || (txtBlck_Operaciones.Text).IndexOf("=") != -1)
            {
                txtBlck_Operaciones.Text = txtBlck_Pantalla.Text + " ÷ ";
                enOperacion = true;
            }
            else
            {
                ResolverDivision();
            }
        }

        private void ResolverSuma(bool desdeIgual = false)
        {
            string operacion = txtBlck_Operaciones.Text;

            decimal numero1 = decimal.Parse(operacion.Replace(" + ", ""));
            decimal numero2 = decimal.Parse(txtBlck_Pantalla.Text);

            decimal resultado = numero1 + numero2;
            txtBlck_Pantalla.Text = resultado.ToString();

            if (resultado.ToString().Length > 3) ActualizarPuntuacionResultado(txtBlck_Pantalla.Text);

            if (!desdeIgual)
            {
                txtBlck_Operaciones.Text = resultado.ToString() + " + ";
                enOperacion = true;
            }
            else
            {
                txtBlck_Operaciones.Text = resultado.ToString() + " + ";
                enOperacion = true;
                txtBlck_Operaciones.Text = numero1 + " + " + numero2 + " = ";
            }
        }

        private void ResolverResta(bool desdeIgual = false)
        {
            string operacion = txtBlck_Operaciones.Text;

            decimal numero1 = decimal.Parse(operacion.Replace(" - ", ""));
            decimal numero2 = decimal.Parse(txtBlck_Pantalla.Text);

            decimal resultado = numero1 - numero2;
            txtBlck_Pantalla.Text = resultado.ToString();

            if (resultado.ToString().Length > 3) ActualizarPuntuacionResultado(txtBlck_Pantalla.Text);

            if (!desdeIgual)
            {
                txtBlck_Operaciones.Text = resultado.ToString() + " - ";
                enOperacion = true;
            }
            else
            {
                txtBlck_Operaciones.Text = resultado.ToString() + " - ";
                enOperacion = true;
                txtBlck_Operaciones.Text = numero1 + " - " + numero2 + " = ";
            }
        }

        private void ResolverMultiplicacion(bool desdeIgual = false)
        {
            string operacion = txtBlck_Operaciones.Text;

            decimal numero1 = decimal.Parse(operacion.Replace(" x ", ""));
            decimal numero2 = decimal.Parse(txtBlck_Pantalla.Text);

            decimal resultado = numero1 * numero2;
            txtBlck_Pantalla.Text = resultado.ToString();

            if (resultado.ToString().Length > 3) ActualizarPuntuacionResultado(txtBlck_Pantalla.Text);

            if (!desdeIgual)
            {
                txtBlck_Operaciones.Text = resultado.ToString() + " x ";
                enOperacion = true;
            }
            else
            {
                txtBlck_Operaciones.Text = resultado.ToString() + " x ";
                enOperacion = true;
                txtBlck_Operaciones.Text = numero1 + " x " + numero2 + " = ";
            }
        }

        private void ResolverDivision(bool desdeIgual = false)
        {
            string operacion = txtBlck_Operaciones.Text;

            decimal numero1 = decimal.Parse(operacion.Replace(" ÷ ", ""));
            decimal numero2 = decimal.Parse(txtBlck_Pantalla.Text);

            try
            {
                decimal resultado = numero1 / numero2;
                txtBlck_Pantalla.Text = resultado.ToString();

                if (resultado.ToString().Length > 3) ActualizarPuntuacionResultado(txtBlck_Pantalla.Text);

                if (!desdeIgual)
                {
                    txtBlck_Operaciones.Text = resultado.ToString() + " ÷ ";
                    enOperacion = true;
                }
                else
                {
                    txtBlck_Operaciones.Text = resultado.ToString() + " ÷ ";
                    enOperacion = true;
                    txtBlck_Operaciones.Text = numero1 + " ÷ " + numero2 + " = ";
                }
            }
            catch (DivideByZeroException)
            {
                txtBlck_Pantalla.Text = "No se puede dividir entre cero";
                DesactivarBotonesACausaDeError();
            }
        }

        private void IgualA()
        {
            if ((txtBlck_Operaciones.Text).IndexOf("=") != -1)
            {
                string operacionReiterada = (txtBlck_Operaciones.Text).Remove(0, (txtBlck_Operaciones.Text).IndexOf(" "));
                operacionReiterada = txtBlck_Pantalla.Text + operacionReiterada;
                string ajuste = (((operacionReiterada).Remove(0, (operacionReiterada.IndexOf(" ") + 2))).Replace(" ", "")).Replace("=", "");

                if (String.Compare(ajuste, "") != 0)
                {
                    txtBlck_Pantalla.Text = ajuste;
                    txtBlck_Operaciones.Text = operacionReiterada.Remove(3 + operacionReiterada.IndexOf((txtBlck_Operaciones.Text).Remove(0, (txtBlck_Operaciones.Text).IndexOf(" "))));
                }
                else return;
            }

            string operacion = txtBlck_Operaciones.Text + txtBlck_Pantalla.Text + " = ";
            string signo = operacion.Substring(operacion.IndexOf(" ") + 1, 1);

            if (String.Compare(signo, "+") == 0) ResolverSuma(true);
            else if (String.Compare(signo, "-") == 0) ResolverResta(true);
            else if (String.Compare(signo, "x") == 0) ResolverMultiplicacion(true);
            else if (String.Compare(signo, "÷") == 0) ResolverDivision(true);
            else if (operacion.IndexOf("√") != -1)
            { 
                txtBlck_Operaciones.Text += " = "; 
                if(operacion.IndexOf("=") != -1)
                {
                    txtBlck_Operaciones.Text = txtBlck_Pantalla.Text + " = ";
                }
            }
            else if (operacion.IndexOf("sqr") != -1)
            {
                txtBlck_Operaciones.Text += " = ";
                if (operacion.IndexOf("=") != -1)
                {
                    txtBlck_Operaciones.Text = txtBlck_Pantalla.Text + " = ";
                }
            }
            else if (String.Compare(signo, "=") == 0) txtBlck_Operaciones.Text = operacion;
        }

        private void IngresaNumero(string numero)
        {
            if(enOperacion)
            {
                txtBlck_Pantalla.Text = "0";
                enOperacion = false;
            }

            string numeroSinPuntos = (txtBlck_Pantalla.Text.Replace(".", "")).Replace(",", "");
            byte conteoNumeros = (byte)numeroSinPuntos.Length;

            if(conteoNumeros < 16)
            {
                if (String.Compare(txtBlck_Pantalla.Text, "0") == 0)
                {
                    if(String.Compare(numero, ",") != 0) txtBlck_Pantalla.Text = numero;
                    else txtBlck_Pantalla.Text += numero;

                }
                else
                {
                    txtBlck_Pantalla.Text += numero;

                    if ((txtBlck_Pantalla.Text).IndexOf(",") == -1) ActualizarPuntuacion(txtBlck_Pantalla.Text);
                }
            }
            else if (String.Compare(txtBlck_Pantalla.Text, "No se puede dividir entre cero") == 0)
            {
                txtBlck_Operaciones.Text = "";
                txtBlck_Pantalla.Text += numero;
            }
        }

        private void ActualizarPuntuacion(string numero)
        {
            numero = numero.Replace(".", "");
            byte numeroDeDigitos = (byte)numero.Length;

            if(numeroDeDigitos > 3)
            {
                byte numeroPuntos = (byte)((numeroDeDigitos - 1) / 3);

                for (byte i = 1; i <= numeroPuntos; i++)
                {
                    numero = numero.Insert(numero.Length - ((i*3) + (i-1)), ".");
                    txtBlck_Pantalla.Text = numero;
                }
            }
        }

        private void ActualizarPuntuacionResultado(string numero) 
        {
            if(numero.IndexOf(",") == -1)
            {
                byte numeroDeDigitos = (byte)numero.Length;
                if (numero.IndexOf("-") != -1) numeroDeDigitos--;
                byte numeroPuntos = (byte)((numeroDeDigitos - 1) / 3);

                for (byte i = 1; i <= numeroPuntos; i++)
                {
                    numero = numero.Insert(numero.Length - ((i * 3) + (i - 1)), ".");
                    txtBlck_Pantalla.Text = numero;
                }
            }
            else
            {
                string parteEntera = "";
                string parteDecimal = "";
                bool enteroGuardado = false;

                foreach (string parteNumero in numero.Split(','))
                {
                    if (enteroGuardado) parteDecimal = parteNumero;
                    else
                    {
                        parteEntera = parteNumero;
                        enteroGuardado = true;
                    }
                }

                byte numeroDeDigitos = (byte)parteEntera.Length;
                if (numero.IndexOf("-") != -1) numeroDeDigitos--;
                byte numeroPuntos = (byte)((numeroDeDigitos - 1) / 3);

                for (byte i = 1; i <= numeroPuntos; i++)
                {
                    parteEntera = parteEntera.Insert(parteEntera.Length - ((i * 3) + (i - 1)), ".");
                    txtBlck_Pantalla.Text = parteEntera + "," + parteDecimal;
                }
            }
        }

        private void CambiarSigno()
        {
            if(txtBlck_Pantalla.Text.IndexOf("-") == -1)
            {
                txtBlck_Pantalla.Text = "-" + txtBlck_Pantalla.Text;
            }
            else
            {
                txtBlck_Pantalla.Text = txtBlck_Pantalla.Text.Replace("-", "");
            }

            if (enOperacion)
            {
                if(txtBlck_Operaciones.Text.IndexOf("-") == -1) txtBlck_Operaciones.Text = txtBlck_Operaciones.Text + "negate( " + txtBlck_Pantalla.Text.Replace("-", "") + " )";
                else if(txtBlck_Operaciones.Text.IndexOf("-") == 0) txtBlck_Operaciones.Text = txtBlck_Operaciones.Text + "negate( -" + txtBlck_Pantalla.Text + " )";

                enOperacion = false;
            }
        }

        private void RaizCuadrada()
        {
            string resultado = Math.Sqrt(double.Parse(txtBlck_Pantalla.Text)).ToString();
            txtBlck_Operaciones.Text = "√(" + txtBlck_Pantalla.Text + ")";
            txtBlck_Pantalla.Text = resultado;
            ActualizarPuntuacionResultado(txtBlck_Pantalla.Text);
        }

        private void ElevarAlCuadrado()
        {
            string resultado = Math.Pow(double.Parse(txtBlck_Pantalla.Text), 2).ToString();
            txtBlck_Operaciones.Text = "sqr(" + txtBlck_Pantalla.Text + ")";
            txtBlck_Pantalla.Text = resultado;
            ActualizarPuntuacionResultado(txtBlck_Pantalla.Text);
        }

        private void UnoPartido()
        {
            string resultado;

            try
            {
                resultado = (1 / decimal.Parse(txtBlck_Pantalla.Text)).ToString();
                txtBlck_Operaciones.Text = "1/(" + txtBlck_Pantalla.Text + ")";
                txtBlck_Pantalla.Text = resultado;
                ActualizarPuntuacionResultado(txtBlck_Pantalla.Text);
            }
            catch (DivideByZeroException)
            {
                txtBlck_Pantalla.Text = "No se puede dividir entre cero";
                resultado = "1/(0)";
                txtBlck_Operaciones.Text = resultado;

                DesactivarBotonesACausaDeError();
            }
            catch (Exception) { }
        }

        private void DesactivarBotonesACausaDeError()
        {
            btn_Porcentaje.IsEnabled = false;
            btn_UnoPartidoX.IsEnabled = false;
            btn_XAlCuadrado.IsEnabled = false;
            btn_RaizCuadradaDeX.IsEnabled = false;
            btn_Dividir.IsEnabled = false;
            btn_Multiplicar.IsEnabled = false;
            btn_Restar.IsEnabled = false;
            btn_Sumar.IsEnabled = false;
            btn_CambiarSigno.IsEnabled = false;
            btn_Coma.IsEnabled = false;
        }

        private void ActivarBotonesSolucionadoError()
        {
            btn_Porcentaje.IsEnabled = true;
            btn_UnoPartidoX.IsEnabled = true;
            btn_XAlCuadrado.IsEnabled = true;
            btn_RaizCuadradaDeX.IsEnabled = true;
            btn_Dividir.IsEnabled = true;
            btn_Multiplicar.IsEnabled = true;
            btn_Restar.IsEnabled = true;
            btn_Sumar.IsEnabled = true;
            btn_CambiarSigno.IsEnabled = true;
            btn_Coma.IsEnabled = true;
            txtBlck_Operaciones.Text = "";
            txtBlck_Pantalla.Text = "0";
        }

        private void Porcentaje()
        {
            txtBlck_Pantalla.Text = "No sé ocupar este botón en la calculadora, así que no supe programarlo XD";
            DesactivarBotonesACausaDeError();
        }

        private void btn_Cero_Click(object sender, RoutedEventArgs e) { IngresaNumero("0"); txtBlck_Pantalla.Focus();}
        private void btn_Uno_Click(object sender, RoutedEventArgs e) { IngresaNumero("1"); txtBlck_Pantalla.Focus(); }
        private void btn_Dos_Click(object sender, RoutedEventArgs e) { IngresaNumero("2"); txtBlck_Pantalla.Focus(); }
        private void btn_Tres_Click(object sender, RoutedEventArgs e) { IngresaNumero("3"); txtBlck_Pantalla.Focus(); }
        private void btn_Cuatro_Click(object sender, RoutedEventArgs e) { IngresaNumero("4"); txtBlck_Pantalla.Focus(); }
        private void btn_Cinco_Click(object sender, RoutedEventArgs e) { IngresaNumero("5"); txtBlck_Pantalla.Focus(); }
        private void btn_Seis_Click(object sender, RoutedEventArgs e) { IngresaNumero("6"); txtBlck_Pantalla.Focus(); }
        private void btn_Siete_Click(object sender, RoutedEventArgs e) { IngresaNumero("7"); txtBlck_Pantalla.Focus(); }
        private void btn_Ocho_Click(object sender, RoutedEventArgs e) { IngresaNumero("8"); txtBlck_Pantalla.Focus(); }
        private void btn_Nueve_Click(object sender, RoutedEventArgs e) { IngresaNumero("9"); txtBlck_Pantalla.Focus(); }
        private void btn_Coma_Click(object sender, RoutedEventArgs e) { IngresaNumero(","); txtBlck_Pantalla.Focus(); }
        private void btn_ClearAll_Click(object sender, RoutedEventArgs e) { BorrarTodo(); txtBlck_Pantalla.Focus(); }
        private void btn_BorrarDigito_Click(object sender, RoutedEventArgs e) { BorrarNumero(); txtBlck_Pantalla.Focus(); }
        private void btn_Sumar_Click(object sender, RoutedEventArgs e) { Sumar(); txtBlck_Pantalla.Focus(); }
        private void btn_Restar_Click(object sender, RoutedEventArgs e) { Restar(); txtBlck_Pantalla.Focus(); }
        private void btn_Multiplicar_Click(object sender, RoutedEventArgs e) { Multiplicar(); txtBlck_Pantalla.Focus(); }
        private void btn_Dividir_Click(object sender, RoutedEventArgs e) { Dividir(); txtBlck_Pantalla.Focus(); }
        private void btn_Clear_Click(object sender, RoutedEventArgs e) { Borrar(); txtBlck_Pantalla.Focus(); }
        private void btn_Igual_Click(object sender, RoutedEventArgs e) { IgualA(); txtBlck_Pantalla.Focus(); }
        private void btn_CambiarSigno_Click(object sender, RoutedEventArgs e) { CambiarSigno(); txtBlck_Pantalla.Focus(); }
        private void btn_RaizCuadradaDeX_Click(object sender, RoutedEventArgs e) { RaizCuadrada(); txtBlck_Pantalla.Focus(); }
        private void btn_XAlCuadrado_Click(object sender, RoutedEventArgs e) { ElevarAlCuadrado(); txtBlck_Pantalla.Focus(); }
        private void btn_UnoPartidoX_Click(object sender, RoutedEventArgs e) { UnoPartido(); txtBlck_Pantalla.Focus(); }
        private void btn_Porcentaje_Click(object sender, RoutedEventArgs e) { Porcentaje(); txtBlck_Pantalla.Focus(); }
    }
}
