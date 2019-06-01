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

namespace ImageEditor
{
    public partial class EditionEffect : Window
    {
        public EditionEffect()
        {
            InitializeComponent();

            BitmapImage originalImage = new BitmapImage(); //if users didn't choose an image code to do nothing
            originalImage.BeginInit();
            originalImage.UriSource = new Uri(UsersImage.getImagePath(), UriKind.Absolute);
            originalImage.EndInit();

            BitmapImage editedImage = new BitmapImage(); //if users didn't choose an image code to do nothing
            editedImage.BeginInit();
            editedImage.UriSource = new Uri(UsersImage.getEditedImagePath(), UriKind.Absolute);
            editedImage.EndInit();

            OriginalImage.Source = originalImage; //dodać exceptions
            EditedImage.Source = editedImage;
        }
    }
}
