using System.Windows;

namespace ImageEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow() {

            InitializeComponent();
        }
        private void LoadImageButton_Click(object sender, RoutedEventArgs e) { 

            bool imageSelected = UsersImage.openImageToEdit();

            if (imageSelected)
            {
                selectingEffect selectingEffectWindow = new selectingEffect();
                selectingEffectWindow.Show(); 

                this.Close();
            }

        }

        private void ProgramInfo_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show("Purpose of this program is image processing. \nPlease load a selected image and you will see available edition effects.");
        }
    }
}
