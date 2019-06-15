using System;
using System.Drawing;
using System.Windows;
using Microsoft.Win32;

namespace ImageEditor
{
    class UsersImage
    {
        private static string imagePath;
        private static string editedImagePath; 
        
        public static string getImagePath()
        {
            return imagePath;
        }

        public static void setImagePath(string ImagePath)
        {
            imagePath = ImagePath;
        }
        public static string getEditedImagePath()
        {
            return editedImagePath;
        }

        public static void setEditedImagePath(string ImagePath)
        {
            editedImagePath = ImagePath;
        }

        Bitmap image;
        public Bitmap loadImage() 
        {    
            try
            {
                image = new Bitmap(imagePath, true);
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error occured: " + exception.Message);
            }

            return image;
        }

        public Bitmap makeCopyToEdit(Bitmap imageToCopy)
        {
            Bitmap clonedImage = new Bitmap(imageToCopy);

            return clonedImage;
        }

        public static bool openImageToEdit()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;...";
            openFileDialog.Title = "Open Image to Edit";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                string imageToEditPath = openFileDialog.FileName;

                imagePath = imageToEditPath;

                return true;
            }
            else
            {
                MessageBox.Show("Image isn't selected. Please try again!", "Error occured!");

                return false;
            }
        }

        public static void saveEditedImage(Bitmap toSave)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPG Image|*.jpg|JPEG Image|*.jpeg|Bitmap Image|*.bmp|PNG Image|*.png";
            saveFileDialog.Title = "Save Edited Image";
            saveFileDialog.ShowDialog();  
            
            if(saveFileDialog.FileName != "")
            {
                editedImagePath = saveFileDialog.FileName;
                toSave.Save(editedImagePath);

                MessageBox.Show("File saved succesfully in " + editedImagePath, "File saved");
            }
                       
        }

    }

}


