using Microsoft.Win32;
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

namespace ImageEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow() {

            InitializeComponent();
        }
        private void LoadImageButton_Click(object sender, RoutedEventArgs e) { //dodać exceptions

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;...";
            openDialog.ShowDialog();

            string fileName = openDialog.FileName;

            UsersImage.setImagePath(fileName);

            selectingEffect selectingEffectWindow = new selectingEffect();
            selectingEffectWindow.Show();

            this.Close();

        }

        private void AuthorsInfo_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show("Piotr Matras");
        }
    }
}
