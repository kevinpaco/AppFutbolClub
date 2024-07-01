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
    /// Lógica de interacción para WinInfo.xaml
    /// </summary>
    public partial class WinInfo : Window
    {
        public WinInfo()
        {
            InitializeComponent();
        }

        public void Mensaje_Info(string mensaje)
        {
            lbl_info.Content = mensaje;
        }

        private void BtnClick_Cerrar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnClick_Minimizar(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_infoAceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
