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

namespace ProyectoTratamientoSenalesBeatBocho
{
    class Obstaculo
    {
        Image Imagen { get; set; }
        BitmapImage ObjetoBmp { get; set; }

        public Obstaculo(Image imagen)
        {
            ObjetoBmp = new BitmapImage(new Uri("arriba1.png", UriKind.Relative));

            Imagen = imagen;
            Imagen.Source = ObjetoBmp;



            PosicionX = Canvas.GetLeft(imagen);
            PosicionY = Canvas.GetTop(imagen);

            Velocidad = 25;

        }
        double PosicionX { get; set; }
        double PosicionY { get; set; }

        public double Velocidad { get; set; }
    }
}
