using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace calculadora2.Vistas
{
    public partial class Window1 : Window
    {
        private int valorActual = 0; // Almacena el primer número
        private string operadorActual = ""; // Almacena el operador
        private bool nuevaEntrada = true; // Indica si es una nueva entrada

        public Window1()
        {
            InitializeComponent();
        }

        // Manejar los clics en los botones de números
        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            if (nuevaEntrada)
            {
                ResultadoLabel.Content = "0"; // Reiniciar la pantalla si es una nueva entrada
                nuevaEntrada = false;
            }

            string numero = (sender as Button).Content.ToString();
            if (ResultadoLabel.Content.ToString() == "0")
                ResultadoLabel.Content = numero; // Reemplaza el 0 inicial
            else
                ResultadoLabel.Content += numero; // Agrega al número actual
        }

        // Guardar el valor y el operador
        private void GuardarValor(string operador)
        {
            // Validar que el contenido sea un número válido antes de convertir
            if (int.TryParse(ResultadoLabel.Content.ToString(), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out valorActual))
            {
                operadorActual = operador; // Guardar el operador
                nuevaEntrada = true; // Indicar que la siguiente es una nueva entrada
            }
            else
            {
                // Si no es válido, reiniciar
                ResultadoLabel.Content = "0";
            }
        }

        // Manejar clics en los operadores
        private void Sumar_Click(object sender, RoutedEventArgs e)
        {
            GuardarValor("+");
        }

        private void Restar_Click(object sender, RoutedEventArgs e)
        {
            GuardarValor("-");
        }

        // Manejar el clic en el botón de igual
        private void Igual_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ResultadoLabel.Content.ToString(), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int segundoValor))
            {
                int resultado = 0;

                switch (operadorActual)
                {
                    case "+":
                        resultado = valorActual + segundoValor;
                        break;
                    case "-":
                        resultado = valorActual - segundoValor;
                        break;
                    default:
                        ResultadoLabel.Content = "Error";
                        return;
                }

                ResultadoLabel.Content = resultado.ToString(); // Mostrar resultado en decimal
            }
            else
            {
                ResultadoLabel.Content = "Error"; // Mostrar error si el valor no es válido
            }
        }

        // Manejar el clic en el botón de borrar
        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            ResultadoLabel.Content = "0"; // Reiniciar el display
            valorActual = 0; // Reiniciar el valor actual
            operadorActual = ""; // Reiniciar el operador
            nuevaEntrada = true; // Permitir nueva entrada
        }

        // Manejar los clics en los botones de letras
        private void Letra_Click(object sender, RoutedEventArgs e)
        {
            if (nuevaEntrada)
            {
                ResultadoLabel.Content = ""; // Reiniciar la pantalla si es una nueva entrada
                nuevaEntrada = false;
            }

            string letra = (sender as Button).Content.ToString();
            ResultadoLabel.Content += letra; // Agrega la letra al número actual
        }
    }
}

