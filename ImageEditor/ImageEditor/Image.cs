using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using Microsoft.Win32;

namespace ImageEditor
{
    class UsersImage
    {
        private static string imagePath;
        private static string editedImagePath; //kolekcje do przertrzymywania w mapie wartosci pixeli dla danego efektu; edytowane bitmapy zapisywac w folderze edited
        
        public static string getImagePath()
        {
            return imagePath;
        }

        public static void setImagePath(string ImagePath)
        {
            imagePath = ImagePath;
        }

        Bitmap image;
        public Bitmap loadImage() 
        {
            

            try
            {
                image = new Bitmap(imagePath, true);
                
            } catch(ArgumentException)
            {
                MessageBox.Show("Error occured!");
            }

            return image;
        }

        public static Bitmap makeCopyToEdit(Bitmap imageToCopy)
        {
            Bitmap clonedImage = new Bitmap(imageToCopy);

            return clonedImage;
        }

        public static void saveEditedImage(string fileName, Bitmap toSave)
        {
            SaveFileDialog dialog = new SaveFileDialog(); //exceptions
            dialog.ShowDialog(); //założyć filtr na obrazu 
            //messageBox gdzie został zapisany zedytowany obraz
            toSave.Save(dialog.FileName/*, ImageFormat.Jpeg*/);
        }

    }

}


