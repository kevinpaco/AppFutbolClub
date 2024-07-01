using ClasesBase.DBConect;
using ClasesBase.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para WinMain.xaml
    /// </summary>
    public partial class WinMain : Window
    {
        private string tipoCancha = "";
        private Cancha datosDancha=new Cancha();

        public WinMain()
        {
            InitializeComponent();
            var d = CanchaABM.ListarCanchas();
            //MessageBox.Show("es: " +d);
        }

        private void BtnClick_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnClick_Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void txtb_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (txtb_idCancha.IsFocused)
                txtb_idCancha.SelectAll();
            else if (txtb_tipoCancha.IsFocused)
                txtb_tipoCancha.SelectAll();
            else if (txtb_fecha.IsFocused)
                txtb_fecha.SelectAll();
            else if (txtb_HsInicio.IsFocused)
                txtb_HsInicio.SelectAll();
            else if (txtb_HsFin.IsFocused)
                txtb_HsFin.SelectAll();
            else if (txtb_nombreCliente.IsFocused)
                txtb_nombreCliente.SelectAll();
            else if (txtb_dniCliente.IsFocused)
                txtb_dniCliente.SelectAll();
            else if (txtb_telCLiente.IsFocused)
                txtb_telCLiente.SelectAll();
        }

        private void txtb_LostFocus(object sender, RoutedEventArgs e)
        {
            SolidColorBrush color = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            bdr_hinicio.BorderBrush = color;
            bdr_hfin.BorderBrush = color;

            if (txtb_idCancha.Text.Length == 0)
                txtb_idCancha.Text = "ID Cancha";
            else if (txtb_tipoCancha.Text.Length == 0)
                txtb_tipoCancha.Text = "Tipo de Cancha";
            else if (txtb_fecha.Text.Length == 0)
                txtb_fecha.Text = "Fecha";
            else if (txtb_HsInicio.Text.Length == 0)
                txtb_HsInicio.Text = "Hora Inicio";
            else if (txtb_HsFin.Text.Length == 0)
                txtb_HsFin.Text = "Hora Fin";
            else if (txtb_nombreCliente.Text.Length == 0)
                txtb_nombreCliente.Text = "Nombre del Cliente";
            else if (txtb_dniCliente.Text.Length == 0)
                txtb_dniCliente.Text = "Dni del Cliente";
            else if (txtb_telCLiente.Text.Length == 0)
                txtb_telCLiente.Text = "Telefono del Cliente";
            else if (txtb_hinicio.Text.Length == 0)
                txtb_hinicio.Text = "H.Inicio 00:00";
            else if (txtb_hfin.Text.Length == 0)
                txtb_hfin.Text = "H. Fin 00:00";

        }

        private void txtClient_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtb_nombreCliente.IsFocused)
                txtb_nombreCliente.SelectAll();
            else if (txtb_dniCliente.IsFocused)
                txtb_dniCliente.SelectAll();
            else if (txtb_telCLiente.IsFocused)
                txtb_telCLiente.SelectAll();
        } 

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnClick_CloseSession(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Esta seguro de Salir ?", "Cerrar Session", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes == result)
            {
                WinLogin wl = new WinLogin();
                wl.Show();
                this.Close();
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            cvs_sec1.Visibility = Visibility.Collapsed;
            cvs_sec2.Visibility = Visibility.Collapsed;
            lbl_info.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            cvs_sec1.Visibility = Visibility.Visible;
            cvs_sec2.Visibility = Visibility.Visible;
            lbl_info.Visibility = Visibility.Collapsed;
        }

        private void txtb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtb_hinicio.IsFocused)
            {
                bdr_hinicio.BorderBrush = new SolidColorBrush(Color.FromRgb(130, 195, 216));
                if (txtb_hinicio.Text.Length == 0 || txtb_hinicio.Text.Equals("H.Inicio 00:00"))
                    txtb_hinicio.Text = "";
            }
            else if (txtb_hfin.IsFocused)
            {
                bdr_hfin.BorderBrush = new SolidColorBrush(Color.FromRgb(130, 195, 216));
                if (txtb_hfin.Text.Length == 0 || txtb_hfin.Text.Equals("H. Fin 00:00"))
                    txtb_hfin.Text = "";
            }

        }

        private void txtb_hinicio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "\b" || e.Text == "\u007f")
                return;
            if (!Regex.IsMatch(e.Text, "[0-9:]"))
            {
                e.Handled = true;
            }
        }

        private void BtnClick_ValidarReserva(object sender, RoutedEventArgs e)
        {
            if (VerificarDatosIngresados())
            {
                if (VerificarFormatoHora(txtb_hinicio.Text, txtb_hfin.Text))
                {
                    Validar_Reserva();  
                }
                else
                    ActivarVentanaInfo("Formato de Hora \n debe ser: 00:00");
            }
            else
                ActivarVentanaInfo("Faltan Datos!!");
        }

        private void Validar_Reserva()
        {
            if (CompararHoras(txtb_hinicio.Text, txtb_hfin.Text))
            {
                DateTime fecha = DateTime.Parse(dpr_fechaReserva.Text);
                DateTime hi = DateTime.Parse(txtb_hinicio.Text);
                DateTime hf = DateTime.Parse(txtb_hfin.Text);
                if (Reserva.VerificarDispinibilidad(fecha, hi, hf, datosDancha.Tipo)== "cndm") //if (Cancha.VerificarDisponibilidad(datosDancha.Tipo))
                      ActivarVentanaInfo("Cancha No Disponible");                                
                else
                {
                    if (Reserva.VerificarDispinibilidad(fecha, hi, hf, datosDancha.Tipo) == "cndh")
                        ActivarVentanaInfo("Cancha no disponible\n por horario");        
                    else
                        CargarDatosReserva();
                }
                    
            }
            else
                ActivarVentanaInfo("La Hora de inicio\n debe ser menor\n que la Hora fin ");
        }

        private void CargarDatosReserva()
        {
            txtb_idCancha.Text = datosDancha.IdCacha.ToString();
            txtb_tipoCancha.Text = datosDancha.Tipo;
            txtb_fecha.Text = dpr_fechaReserva.Text;
            txtb_HsInicio.Text = txtb_hinicio.Text;
            txtb_HsFin.Text = txtb_hfin.Text;
            btn_Resgistrar.IsEnabled = true;
            /*List<DetalleReservaDTO> lista = new List<DetalleReservaDTO>();
            DetalleReservaDTO detalleReservaDTO = new DetalleReservaDTO();
            Cancha cancha = CanchaABM.BuscarCanchaPorTipo(tipoCancha);
            detalleReservaDTO.IdCancha = cancha.IdCacha;
            detalleReservaDTO.Tipo = cancha.Tipo;
            detalleReservaDTO.Estado = cancha.Estado;
            detalleReservaDTO.Fecha = DateTime.Parse(dpr_fechaReserva.Text);
            detalleReservaDTO.HoraInicio = txtb_hinicio.Text;
            detalleReservaDTO.HoraFin = txtb_hfin.Text;
            lista.Add(detalleReservaDTO);*/
            //dtg_infoReserva.ItemsSource = lista;
        }

        private void ActivarVentanaInfo(string mensaje)
        {
            WinInfo winInfo = new WinInfo();
            winInfo.Mensaje_Info(mensaje);
            winInfo.ShowDialog();
        }

        private bool VerificarDatosIngresados()
        {
            bool band1 = !(txtb_hinicio.Text.Equals("H.Inicio 00:00") && txtb_hfin.Text.Equals("H. Fin 00:00"));
            bool band2 = dpr_fechaReserva.Text.Length != 0 && datosDancha.Tipo != null;
            return band1 && band2;
        }

        private bool VerificarFormatoHora(string horaInicio, string horaFin)
        {               
            if (horaInicio.Length > 2 && horaFin.Length > 2)
                 if (horaInicio[2].ToString() == ":" && horaFin[2].ToString() == ":")
                        return true;                
            return false;
        }

        private bool VerificarIntervaloHoras(string hora)
        {
            if (hora.Length < 3)
            {
                int h = int.Parse(hora);
                if (h > 7 && h < 24)
                    return true;
            }
            return false;
        }

        private bool VerificarIntervaloMinutos(string hora)
        {
            if (hora.Length < 3)
            {
                int h = int.Parse(hora);
                if (h > 0 && h < 60)
                    return true;
            }
            return false;
        }

        private bool CompararHoras(string horaInicio, string horaFin)
        {
            DateTime fecha1 = DateTime.Parse(horaInicio);
            DateTime fecha2 = DateTime.Parse(horaFin);
            return fecha1 < fecha2;
        }

        private void cbx_tipoCancha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbx_tipoCancha.SelectedItem as DataRowView;
            datosDancha = new Cancha();
            datosDancha.IdCacha = int.Parse(item["idCancha"].ToString());
            datosDancha.Tipo = item["tipo"].ToString();            
        }

     /*   private void dtg_infoReserva_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetalleReservaDTO filaSelecionada = dtg_infoReserva.SelectedItem as DetalleReservaDTO;
            if(filaSelecionada != null)
            {
                txtb_idCancha.Text = filaSelecionada.IdCancha.ToString();
                txtb_tipoCancha.Text = filaSelecionada.Tipo;
                txtb_fecha.Text = filaSelecionada.Fecha.ToString();
                txtb_HsInicio.Text = filaSelecionada.HoraInicio;
                txtb_HsFin.Text = filaSelecionada.HoraFin;
                btn_Resgistrar.IsEnabled = true;
            }
        }*/

        private bool ValidarDatosCliente()
        {
            bool band = !(txtb_nombreCliente.Text.Equals("Nombre Del Cliente")
                        && txtb_telCLiente.Text.Equals("Telefono del Cliente")
                        && txtb_dniCliente.Text.Equals("Dni del Cliente"));                                                                            
            return band;
        }

        private void BtnClick_GuardarReserva(object sender, RoutedEventArgs e)
        {
            if(ValidarDatosCliente())
            {
                var confirmar = MessageBox.Show("Esta Seguro de Resgistrar Reserva?", "Confimacion", MessageBoxButton.YesNo);
                if (confirmar.Equals(MessageBoxResult.Yes))
                   {
                    bool result = Reserva.RegistrarReserva(txtb_nombreCliente.Text,
                                                              int.Parse(txtb_dniCliente.Text),
                                                              long.Parse(txtb_telCLiente.Text),
                                                              DateTime.Parse(txtb_fecha.Text),
                                                              txtb_HsInicio.Text, txtb_HsFin.Text,
                                                              txtb_tipoCancha.Text);

                    if (result == true)
                    {
                        MessageBoxResult r = MessageBox.Show("Reserva Registrada, Imprimir Comprobante ?","Información", MessageBoxButton.YesNo);
                        if (r == MessageBoxResult.Yes)
                        {
                            WinComprobante2 win = new WinComprobante2();
                            win.CargarComprobante(txtb_nombreCliente.Text, txtb_dniCliente.Text, txtb_telCLiente.Text,txtb_tipoCancha.Text, txtb_fecha.Text,
                                                 txtb_HsInicio.Text, txtb_HsFin.Text);
                            win.ShowDialog();
                        }
                    }
                    }

            }
            else
            {
                WinInfo winInfo = new WinInfo();
                winInfo.Mensaje_Info("Debe completar datos\ndel Cliente");
                winInfo.ShowDialog();
            }
        }

        private void txtbCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "[0-9:]"))
            {
                e.Handled = true;
            }
            else
                return;
        }

        private void dpr_fechaReserva_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpr_fechaReserva.SelectedDate < DateTime.Today)
            {
                // Show an error message or clear the selection
                dpr_fechaReserva.SelectedDate = null;
                MessageBox.Show("Fecha invalida.","Error");
            }
        }

        private void txtb_hinicio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape || e.Key == Key.Down)
            {
                // Prevent exiting the text box with Esc or Tab
                e.Handled = true;
            }
        }
    }
}
