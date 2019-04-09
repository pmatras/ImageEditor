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
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {

            InitializeComponent();
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e) {

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ShowDialog();

        }

        private void AuthorsInfo_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show("Piotr Matras");

        }
    }
}
