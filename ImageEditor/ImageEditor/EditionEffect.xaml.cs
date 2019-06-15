using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageEditor  
{
    public partial class EditionEffect : Window
    {
        public EditionEffect() 
        {
            InitializeComponent();

            try
            {
                BitmapImage originalImage = new BitmapImage();
                originalImage.BeginInit();
                originalImage.UriSource = new Uri(UsersImage.getImagePath(), UriKind.Absolute);
                originalImage.EndInit();

                BitmapImage editedImage = new BitmapImage();
                editedImage.BeginInit();
                editedImage.UriSource = new Uri(UsersImage.getEditedImagePath(), UriKind.Absolute);
                editedImage.EndInit();

                OriginalImage.Source = originalImage;
                EditedImage.Source = editedImage;
            }
            catch(Exception exception)
            {
                MessageBox.Show("Error occured: " + exception.Message, "Error!");
            }
            
        }

        private void ReplayButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
