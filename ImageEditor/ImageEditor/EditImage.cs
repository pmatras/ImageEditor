using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageEditor
{
    interface IEditImage
    {
        void editImage(Bitmap imageToEdit);
    }

    class BlackWhiteEffect : IEditImage
    {
        //Dictionary<int, int> ColorToGraynessPixels;
        public void editImage(Bitmap imageToEdit)
        {
            /*ColorToGraynessPixels = new Dictionary<int, int>();

            for(int i = 0; i < 255; ++i)
            {
                int newPixelValue = 
                ColorToGraynessPixels.Add(key: i, value: newPixelValue);
            }*/
            Color pixel;

            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);


                    var GraynessPixel = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                    imageToEdit.SetPixel(i, j, Color.FromArgb((int)GraynessPixel, (int)GraynessPixel, (int)GraynessPixel));
                    
                }

            UsersImage.saveEditedImage(imageToEdit);
        }
    }

    class NegativeEffect : IEditImage
    {
        private const int maxRGBValue = 255;
        public void editImage(Bitmap imageToEdit)
        {
            Color pixel;

            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    var NegativePixelR = maxRGBValue - pixel.R;
                    var NegativePixelG = maxRGBValue - pixel.G;
                    var NegativePixelB = maxRGBValue - pixel.B;

                    imageToEdit.SetPixel(i, j, Color.FromArgb((int)NegativePixelR, (int)NegativePixelG, (int)NegativePixelB));
                }

            UsersImage.saveEditedImage(imageToEdit);
        }
    }

    class SepiaEffect : IEditImage
    {
        private const int maxRGBValue = 255;
        private const int fillFactor = 20;
        public void editImage(Bitmap imageToEdit)
        {
            Color pixel;

            for (int i = 0; i < imageToEdit.Width; ++i)
                for (int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    var NegativePixelR = maxRGBValue - pixel.R;
                    var NegativePixelG = maxRGBValue - pixel.G;
                    var NegativePixelB = maxRGBValue - pixel.B;

                    imageToEdit.SetPixel(i, j, Color.FromArgb((int)NegativePixelR, (int)NegativePixelG, (int)NegativePixelB));
                }

            for (int i = 0; i < imageToEdit.Width; ++i)
                for (int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    var SepiaPixelR = pixel.R + 2 * fillFactor; //można przygotować gotową tablicę z wartościami pixeli
                    if (SepiaPixelR > 255)
                        SepiaPixelR = 255;

                    var SepiaPixelG = pixel.G + fillFactor;
                    if (SepiaPixelG > 255)
                        SepiaPixelG = 255;

                    var SepiaPixelB = pixel.B;

                    imageToEdit.SetPixel(i, j, Color.FromArgb((int)SepiaPixelR, (int)SepiaPixelG, (int)SepiaPixelB));
                }

            UsersImage.saveEditedImage(imageToEdit);
        }
    }
}
