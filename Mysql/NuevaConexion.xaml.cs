using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mysql
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NuevaConexion : Page
    {
        public NuevaConexion()
        {
            this.InitializeComponent();
          
       
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MainPage.appWindow.CloseAsync();
        }
        public static Conexion Conexion;
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Conexion = new Conexion() {Clave = Clave.Password,Host=Host.Text,Nombre = Nombre.Text,Usuario = Usuario.Text };
            MainPage.appWindow.CloseAsync();
        }
    }
}
