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
using ImageEditor;

namespace ImageEditor
{
    /// <summary>
    /// Logika interakcji dla klasy selectingEffect.xaml
    /// </summary>
    /// 
    
    public partial class selectingEffect : Window
    {
        public selectingEffect()
        {
            InitializeComponent();

            //Image image = new Image();

            // if (image.Exists(AppDomain.CurrentDomain.BaseDirectory + "images/lock.png"))
            // Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "images/lock.png", UriKind.RelativeOrAbsolute);
            //MyImage.Source = BitmapFrame.Create(uri);



            BitmapImage source = new BitmapImage(); //spr majpierw czy plik isdtniehje
            source.BeginInit();
            source.UriSource = new Uri(UsersImage.getImagePath(), UriKind.Absolute);
            source.EndInit();

            OriginalImage.Source = source;

            //image.Source = source;

           

            


                 


        }

        private void blackWhite_click(object sender, RoutedEventArgs e)
        {

        }

        private void sepia_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
