using ClasesBase.models;
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
    /// Lógica de interacción para WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        private List<Usuario> usuarios=new List<Usuario>();
        public WinLogin()
        {
            InitializeComponent();
            cargarUsuarios();
        }

        private void cargarUsuarios()
        {
           Usuario user1= new Usuario("bart","123");
           Usuario user2 = new Usuario("lisa", "123");
            usuarios.Add(user1);
            usuarios.Add(user2);
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClick_Close(object sender,RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnClick_Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void textBox_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(txtbx_user.IsFocused)
                 txtbx_user.SelectAll();
            if(txtbx_contra.IsFocused)
                 txtbx_contra.SelectAll();
        }
        private void txtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtbx_user.IsFocused)
                txtbx_user.SelectAll();
            if (txtbx_contra.IsFocused)
                txtbx_contra.SelectAll();
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtbx_user.Text.Length == 0) {
                txtbx_user.Text = "Usuario";
            }
            if (txtbx_contra.Text.Length == 0)
            {
                txtbx_contra.Text = "Contraseña";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx_user.Text=="Usuairo" || txtbx_contra.Text == "Contraseña")
            {
                MessageBox.Show("Ingrese Usuario y Contraseña","Validación");
                return;
            }
            try
            {
                Usuario use = usuarios.Find(user => user.User == txtbx_user.Text && user.Contra == txtbx_contra.Text);
                if(use != null)
                {
                    WinMain wm = new WinMain();
                    wm.Show();
                    this.Close();
                    //MessageBox.Show("Es: " + use.User);
                }
                else
                {
                    MessageBox.Show("Usuario No encontrado");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
