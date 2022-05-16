using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mysql
{
    public class Conexion
    {
        public Conexion()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Host { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Conexion> Conexiones { get;} = new ObservableCollection<Conexion>();
        public MainPage()
        {
            this.InitializeComponent();
            Conexiones.Add(new Conexion() { Nombre = "Conexion 1",Host="Host de conexion"});
            Conexiones.Add(new Conexion() { Nombre = "Conexion 2",Host="Host de conexion"});

           
        }
        public static AppWindow appWindow;
        private async void NuevaConexion_Click(object sender, RoutedEventArgs e)
        {
            appWindow = await AppWindow.TryCreateAsync();
            Frame appWindowContentFrame = new Frame();
            appWindowContentFrame.Navigate(typeof(NuevaConexion));
            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowContentFrame);
            await appWindow.TryShowAsync();
            appWindow.Closed += delegate
            {
                appWindowContentFrame.Content = null;
                appWindow = null;
                if (NuevaConexion.Conexion != null)
                {
                    Conexiones.Add(NuevaConexion.Conexion);
                }

            };
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var item = (StackPanel)sender;

            var conn = Conexiones.FirstOrDefault(c => c.Id == Guid.Parse(item.Tag.ToString()));

            Frame.Navigate(typeof(Home),conn); 
        }
    }
}
