using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;

using ImageEditor;

namespace ImageEditor
{

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
            catch (InvalidOperationException exception)
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

            bool inputIsANumber = false;
            int brightnessValue = 0;

            do
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of brigthness between -255 and 255", "Enter value", "255", -1, -1);
                
                try
                {
                    brightnessValue = Int32.Parse(input);

                    inputIsANumber = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("An error occured: " + exception.Message, "Error!");

                    inputIsANumber = false;
                }

                if (inputIsANumber == true)
                {
                    if (brightnessValue < -255 || brightnessValue > 255)
                    {
                        MessageBox.Show("Entered value isn't in range between -255 and 255. Please try again!", "Wrong value!");
                        inputIsANumber = false;
                    }                    
                }
            }
            while (inputIsANumber == false);


            BrightnessEffect.setBrightnessValue(brightnessValue);

            imageEditor.editImage(imageToEdit);
            EffectSelector.showEditionResults();

            this.Close();

        }

        private void Color_Click(object sender, RoutedEventArgs e) //naprawić, żeby działało na enumach
        {
            Bitmap imageToEdit = EffectSelector.prepareImageToEdit();

            IEditImage imageEditor = new ColorEffect();

            //public enum colors { Red, Green, Blue };
           
            bool inputOK = false;

            do
            {

                string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter color to edit image (red, green or blue)", "Enter color", "red", -1, -1); //na enumach

                if (input == "red") //switch + enum
                    ColorEffect.setColorOption(0);
                if (input == "green")
                    ColorEffect.setColorOption(1);
                if (input == "blue")
                    ColorEffect.setColorOption(2);

            } while (inputOK == false);




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

        private void GammaFiltering_Click(object sender, RoutedEventArgs e) //ogarnac max mozliwosc wartosc do wybrania + sprawdzic algorytm i jaki max wsp gamma i zabezpieczenie przed zla wartoscia
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

            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter value of contrast to adjust between -255 and 255.", "Enter value of contrast adjustment", "50", -1, -1);
            Int32.TryParse(input, out int contrastValue);

            if (contrastValue > 255)
                contrastValue = 255;
            else if (contrastValue < -255)
                contrastValue = -255;

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
