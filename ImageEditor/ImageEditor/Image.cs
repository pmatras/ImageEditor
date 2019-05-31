using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class UsersImage
    {
        // private static string imagePath { public get; public set; }
        private static string imagePath;
        public int x { get; private set; }

        public static string getImagePath()
        {
            return imagePath;
        }

        public static void setImagePath(string ImagePath)
        {
            imagePath = ImagePath;
        }

        public void loadImage()
        {
           
        }

        public void makeCopyToEdit()
        {

        }

        public void saveEditedImage()
        {

        }

    }

}


