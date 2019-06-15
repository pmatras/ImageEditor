using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;

using ImageEditor;

namespace ImageEditor
{
    enum colors { Red, Green, Blue };
    public partial class selectingEffect : Window
    {
        public selectingEffect()
        {
            InitializeComponent();

            try
            {

                BitmapImage sourceImage = new BitmapImage(); 
                sourceImage.BeginInit();
                sourceImage.UriSource = new Uri(UsersImage.getImagePath(), UriKind.Absolute);
                sourceImage.EndInit();

                OriginalImage.Source = sourceImage; 
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\nPlease choose image properly once again.", "Image isn't set!");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();

            }

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

        private void InvertColors_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new InvertColorsEffect();
            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
            this.Close();

        }

        private void Brightness_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new BrightnessEffect();

            bool correctInput = false;
            int brightnessValue = 0;

            do
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of brigthness between -255 and 255", "Enter value", "255", -1, -1);
                
                try
                {
                    brightnessValue = Int32.Parse(input);

                    correctInput = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("An error occured: " + exception.Message, "Error!");

                    correctInput = false;
                }

                if (correctInput == true)
                {
                    if (brightnessValue < -255 || brightnessValue > 255)
                    {
                        MessageBox.Show("Entered value isn't in range between -255 and 255. Please try again!", "Wrong value!");
                        correctInput = false;
                    }                    
                }
            }
            while (correctInput == false);


            BrightnessEffect.setBrightnessValue(brightnessValue);

            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
            this.Close();

        }

        private void Color_Click(object sender, RoutedEventArgs e) 
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new ColorEffect();            
           
            bool correctInput = true;

            do
            {

                string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter color to edit image (red, green or blue)", "Enter color", "red", -1, -1);

                correctInput = true;

                switch (input)
                {
                    case "red":

                        ColorEffect.setColorOption((int)colors.Red);
                        break;

                    case "green":

                        ColorEffect.setColorOption((int)colors.Green);
                        break;

                    case "blue":

                        ColorEffect.setColorOption((int)colors.Blue);
                        break;

                    default:

                        MessageBox.Show("Wrong color entered! Please try again.", "Wrong choice!");
                        correctInput = false;
                        break;
                }      
               
            } while (correctInput == false);

            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
            this.Close();
        }    

        private void GaussianBlur_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new GaussianBlurEffect();
            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
            this.Close();

        }

        private void GammaFiltering_Click(object sender, RoutedEventArgs e) //ogarnac max mozliwosc wartosc do wybrania + sprawdzic algorytm i jaki max wsp gamma i zabezpieczenie przed zla wartoscia
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();
            
            IEditImage imageEditor = new GammaFilteringEffect();
                         
            bool correctInput = false;
            double gammaValue = 0;

            do
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of gamma filter ratio between 0.2 and 5.", "Enter value of gamma", "1", -1, -1);

                try
                {
                    gammaValue = Double.Parse(input);

                    correctInput = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("An error occured: " + exception.Message, "Error!");

                    correctInput = false;
                }

                if (correctInput == true)
                {
                    if (gammaValue < 0.2 || gammaValue > 5)
                    {
                        MessageBox.Show("Entered value isn't in range between 0,2 and 5. Please try again!", "Wrong value!");
                        correctInput = false;
                    }
                }
            }
            while (correctInput == false);
            

            GammaFilteringEffect.setGammaValue(gammaValue);
            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();


            this.Close();

        }

        private void ChangeExposure_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new ChangeExposureEffect();

            bool correctInput = false;
            double exposureValue = 0;

            do
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of Exposure Value between -8 and 8", "Enter value", "2", -1, -1);

                try
                {
                    exposureValue = Double.Parse(input);

                    correctInput = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("An error occured: " + exception.Message, "Error!");

                    correctInput = false;
                }

                if (correctInput == true)
                {
                    if (exposureValue < -8 || exposureValue > 8)
                    {
                        MessageBox.Show("Entered value isn't in range between -8 and 8. Please try again!", "Wrong value!");
                        correctInput = false;
                    }
                }
            }
            while (correctInput == false);


            ChangeExposureEffect.setExposureCorrectnessRatio(Math.Pow(2.0, exposureValue));

            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();

            this.Close();
        }

        private void Contrast_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new ChangeContrastEffect();

            bool correctInput = false;
            int contrastValue = 0;

            do
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of contrast to adjust between -255 and 255.", "Enter value of contrast adjustment", "50", -1, -1);

                try
                {
                    contrastValue = Int32.Parse(input);

                    correctInput = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("An error occured: " + exception.Message, "Error!");

                    correctInput = false;
                }

                if (correctInput == true)
                {
                    if (contrastValue < -255 || contrastValue > 255)
                    {
                        MessageBox.Show("Entered value isn't in range between -255 and 255. Please try again!", "Wrong value!");
                        correctInput = false;
                    }
                }
            }
            while (correctInput == false);
            
            ChangeContrastEffect.setContrastValue(contrastValue);

            imageEditor.editImage(imageToEdit);

            EffectSelector.showEditionResults();
            this.Close();

        }

        private void HistogramStretching_Click(object sender, RoutedEventArgs e)
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new HistogramStretchingEffect();

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
