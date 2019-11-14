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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Diagnostics;

namespace ProyectoTratamientoSenalesBeatBocho
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage bitmapMenu;
        bool jugando = true;
        Stopwatch stopwatch = new Stopwatch();
        TimeSpan tiempoAnterior;
        Bocho bocho;
        public MainWindow()
        {
            InitializeComponent();
            canvasPrincipal.Focus();
            bitmapMenu = new BitmapImage(new Uri("Fondo.png", UriKind.Relative));
            Fondo.Source = bitmapMenu;
            bocho = new Bocho(spriteBocho);
            stopwatch.Start();
            tiempoAnterior = stopwatch.Elapsed;
            ThreadStart threadStart = new ThreadStart(cicloPrincipal);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        public void cicloPrincipal()
        {
            while (jugando)
            {
                Dispatcher.Invoke(actualizar);
       
            }
        }
        public void actualizar()
        {
            TimeSpan tiempoActual = stopwatch.Elapsed;
            double deltaTime = tiempoActual.TotalSeconds - tiempoAnterior.TotalSeconds;

            bocho.Mover(deltaTime);
            bocho.Velocidad += 10 * deltaTime;

            tiempoAnterior = tiempoActual;
        }

        private void canvasPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.IsRepeat)
            {
             
                if (e.Key == Key.Up)
                {
                    bocho.CambiarDireccion(Bocho.Direccion.Arriba);
                }
                if (e.Key == Key.Down)
                {
                    bocho.CambiarDireccion(Bocho.Direccion.Abajo);
                }
            }
        }
    }
}
