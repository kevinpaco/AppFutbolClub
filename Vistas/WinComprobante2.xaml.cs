using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WinComprobante2.xaml
    /// </summary>
    public partial class WinComprobante2 : Window
    {
        public WinComprobante2()
        {
            InitializeComponent();
        }

        public void CargarComprobante(string nombre, string dni, string telefono, string tipoCnacha, string fecha, string hi, string hf)
        {
            lblNombre.Content = "Nombre: " + nombre;
            lblDni.Content = "DNI: " + dni;
            lblTel.Content = "Telefono: "+telefono;
            lblTipoCancha.Content = "Tipo de Cancha: "+tipoCnacha;
            lblFecha.Content ="Fecha: "+fecha;
            lblHoraInicio.Content ="Hora Inicio: "+ hi;
            lblHoraFinal.Content ="Hora Fin: "+hf;            
        }

        private void BtnClick_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnClick_Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
