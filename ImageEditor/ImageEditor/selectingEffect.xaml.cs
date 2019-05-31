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
                  
            BitmapImage sourceImage = new BitmapImage(); //if users didn't choose an image code to do nothing
            sourceImage.BeginInit();
            sourceImage.UriSource = new Uri(UsersImage.getImagePath(), UriKind.Absolute);
            sourceImage.EndInit();

            OriginalImage.Source = sourceImage;
                       
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
