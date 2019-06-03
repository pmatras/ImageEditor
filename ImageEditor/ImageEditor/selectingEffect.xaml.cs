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

        private void Brightness_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new BrightnessEffect();

            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of brigthness between -255 and 255", "Enter value", "255", -1, -1);
            int brightnessValue = Int32.Parse(input);

            if (brightnessValue < -255)
                brightnessValue = -255;

            if (brightnessValue > 255)
                brightnessValue = 255;

            BrightnessEffect.setBrightnessValue(brightnessValue);

            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
                        

            this.Close();

        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new ColorEffect();

            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter color to edit image (red, green or blue)", "Enter color", "red", -1, -1); //na enumach

            if (input == "red") //switch + enum
                ColorEffect.setColorOption(0);
            if (input == "green")
                ColorEffect.setColorOption(1);
            if (input == "blue")
                ColorEffect.setColorOption(2);

            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();


            this.Close();

        }

        private void InvertColors_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new InvertColorsEffect();
                        
            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();


            this.Close();

        }

        private void GaussBlur_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new GaussBlurEffect();

            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();


            this.Close();

        }

        private void GammaFiltering_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();
            
            IEditImage imageEditor = new GammaFilteringEffect();

            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of gamma filter ratio.", "Enter value of gamma", "1", -1, -1);
            Int32.TryParse(input, out int gammaValue);
            GammaFilteringEffect.setGammaValue(gammaValue);

            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();


            this.Close();

        }

        private void CropImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Contrast_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new ChangeContrastEffect();

            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of contrast to adjust between -100 and 100.", "Enter value of contrast adjustment", "50", -1, -1);
            Int32.TryParse(input, out int contrastValue);

            ChangeContrastEffect.setContrastValue(contrastValue);

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
