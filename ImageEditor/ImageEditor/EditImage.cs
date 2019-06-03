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

            for(int i = 0; i < 256; ++i)
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

    class BrightnessEffect : IEditImage
    {
        private static int brightnessValue;

        public static void setBrightnessValue(int usersBrightnessValue)
        {
            brightnessValue = usersBrightnessValue;
        }
        
        public void editImage(Bitmap imageToEdit)
        {
            Color pixel;

            for (int i = 0; i < imageToEdit.Width; ++i)
                for (int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    var BrightPixelR = pixel.R + brightnessValue;
                    var BrightPixelG = pixel.G + brightnessValue;
                    var BrightPixelB = pixel.B + brightnessValue;

                    if (BrightPixelR < 0)
                        BrightPixelR = 0;
                    if (BrightPixelR > 255)
                        BrightPixelR = 255;

                    if (BrightPixelG < 0)
                        BrightPixelG = 0;
                    if (BrightPixelG > 255)
                        BrightPixelG = 255;

                    if (BrightPixelB < 0)
                        BrightPixelB = 0;
                    if (BrightPixelB > 255)
                        BrightPixelB = 255;
                                        
                    imageToEdit.SetPixel(i, j, Color.FromArgb((int)BrightPixelR, (int)BrightPixelG, (int)BrightPixelB));
                }
            UsersImage.saveEditedImage(imageToEdit);
        }

        
        }

    class ColorEffect : IEditImage
    {
        public enum colorOptions { Red, Green, Blue }; //to w sumie to metody z obsluga zdarzenia
        private static int colorOption;
        public static void setColorOption(int _colorOption)
        {
            colorOption = _colorOption;
        }

        public void editImage(Bitmap imageToEdit)
        {
            Color pixel;

            for (int i = 0; i < imageToEdit.Width; ++i)
                for (int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    int ColoredPixelR = 0;
                    int ColoredPixelG = 0;
                    int ColoredPixelB = 0;

                    if (colorOption == (int)colorOptions.Red) //zmienić na switch
                    {
                        ColoredPixelR = pixel.R;
                        ColoredPixelG = pixel.G - 255;
                        ColoredPixelB = pixel.B - 255;
                    }
                    if (colorOption == (int)colorOptions.Green) //zmienić na switch
                    {
                        ColoredPixelR = pixel.R - 255;
                        ColoredPixelG = pixel.G;
                        ColoredPixelB = pixel.B - 255;
                    }
                    if (colorOption == (int)colorOptions.Blue) //zmienić na switch
                    {
                        ColoredPixelR = pixel.R - 255;
                        ColoredPixelG = pixel.G - 255;
                        ColoredPixelB = pixel.B;
                    }

                    ColoredPixelR = Math.Max(ColoredPixelR, 0);
                    ColoredPixelR = Math.Min(255, ColoredPixelR);

                    ColoredPixelG = Math.Max(ColoredPixelG, 0);
                    ColoredPixelG = Math.Min(255, ColoredPixelG);

                    ColoredPixelB = Math.Max(ColoredPixelB, 0);
                    ColoredPixelB = Math.Min(255, ColoredPixelB);

                    imageToEdit.SetPixel(i, j, Color.FromArgb((int)ColoredPixelR, (int)ColoredPixelG, (int)ColoredPixelB));
                }

            UsersImage.saveEditedImage(imageToEdit);
        }
    }

    class InvertColorsEffect : IEditImage
    {
        public void editImage(Bitmap imageToEdit)
        {
            Color pixel;

            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j=0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    imageToEdit.SetPixel(i, j, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }

            UsersImage.saveEditedImage(imageToEdit);
        }
    }
}
