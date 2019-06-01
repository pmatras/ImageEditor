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
using System.Drawing;

namespace ImageEditor
{
  
    public partial class selectingEffect : Window
    {
        public selectingEffect()
        {
            InitializeComponent();     
                  
            BitmapImage sourceImage = new BitmapImage(); //if users didn't choose an image code to do nothing
            sourceImage.BeginInit();
            sourceImage.UriSource = new Uri(UsersImage.getImagePath(), UriKind.Absolute);
            sourceImage.EndInit();

            OriginalImage.Source = sourceImage; //dodać exceptions
                       
        }

        private void blackWhite_click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new BlackWhiteEffect();
            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
            this.Close();

        }

        private void sepia_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new SepiaEffect();
            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
            this.Close();

        }

        private void Negative_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new NegativeEffect();
            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
            this.Close();
            
        }
    }

    class EffectSelector
    {
        public static Bitmap prepareImageToEdit()
        {
            UsersImage image = new UsersImage(); 
            Bitmap usersImage = image.loadImage();
            Bitmap imageToEdit = UsersImage.makeCopyToEdit(usersImage);

            return imageToEdit;
        }

        public static void showEditionResults()
        {
            EditionEffect editionEffectWindow = new EditionEffect(); 
            editionEffectWindow.Show();
        }
    }
}
