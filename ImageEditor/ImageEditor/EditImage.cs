using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

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

    class GaussianBlurEffect : IEditImage
    {
        private const int FilterSize = 5;
        private int[,] GaussFilterArray;
        private int filterWeightsSum;
        private int offset;

        public GaussianBlurEffect()
        {
            this.GaussFilterArray = new int[FilterSize, FilterSize] 
            { 
                { 1, 4, 7, 4, 1 }, 
                { 4, 16, 26, 16, 4 }, 
                { 7, 26, 41, 26, 7 },
                {4, 26, 16, 26, 4 },
                {1, 4, 7, 4, 1 }
            };

            for(int i = 0; i < FilterSize; ++i)
                for(int j = 0; j < FilterSize; ++j)
                    this.filterWeightsSum += GaussFilterArray[i, j];

            this.offset = (int)Math.Floor((double)FilterSize / 2);
        }
        public void editImage(Bitmap imageToEdit)
        {
            Color pixel;

            int sumOfNeighborsR = 0;
            int sumOfNeighborsG = 0;
            int sumOfNeighborsB = 0;

            int filterIteratorX = 0;
            int filterIteratorY = 0;

            for (int i = offset; i < imageToEdit.Width - offset; ++i) 
            {
                for (int j = offset; j < imageToEdit.Height - offset; ++j)
                {

                    for (int k = i - offset; k <= i + offset; ++k)
                    {
                        for (int l = j - offset; l <= j + offset; ++l)
                        {
                            pixel = imageToEdit.GetPixel(k, l);

                            sumOfNeighborsR += pixel.R * GaussFilterArray[filterIteratorX, filterIteratorY];
                            sumOfNeighborsG += pixel.G * GaussFilterArray[filterIteratorX, filterIteratorY];
                            sumOfNeighborsB += pixel.B * GaussFilterArray[filterIteratorX, filterIteratorY++];
                        }
                        ++filterIteratorX;
                        filterIteratorY = 0;
                    }

                    imageToEdit.SetPixel(i, j, Color.FromArgb(sumOfNeighborsR / filterWeightsSum, sumOfNeighborsG / filterWeightsSum, sumOfNeighborsB / filterWeightsSum));

                    sumOfNeighborsR = 0;
                    sumOfNeighborsG = 0;
                    sumOfNeighborsB = 0;
                    filterIteratorX = 0;
                    filterIteratorY = 0;               
                  
                }

            }

            UsersImage.saveEditedImage(imageToEdit);
        }     

    }

    class GammaFilteringEffect : IEditImage
    {
        private static int gammaValue; //oddzielna wartość dla każdego kanału RGB??
        public static void setGammaValue(int value)
        {
            gammaValue = value;
        }
        public void editImage(Bitmap imageToEdit)
        {
            List<int> gammaArray = createGammaArray(); //oddzielne tablice dla każdego kanału??

            Color pixel;

            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);
                    //int pixelR = gammaArray[(int)2];

                   imageToEdit.SetPixel(i, j, Color.FromArgb(gammaArray[(int)pixel.R], gammaArray[(int)pixel.G], gammaArray[(int)pixel.B]));
                }

            UsersImage.saveEditedImage(imageToEdit);

        }

        private List<int> createGammaArray()
        {
            List<int> gammaArray = new List<int>();

            for(int i = 0; i < 256; ++i)
            {
                gammaArray.Add((int)Math.Min(255, (int)255.0 * Math.Pow(i / 255.0, 1.0 / gammaValue) + 0.5)); //rzutowanie??
            }

            return gammaArray;
        }
    }

    class ChangeContrastEffect : IEditImage
    {
        private List<double> LUT;
        private static int contrastValue;
        public static void setContrastValue(int contrast)
        {
            contrastValue = contrast;
        }

        public void editImage(Bitmap imageToEdit)
        {
            makeLUTArray();

            Color pixel;

            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    imageToEdit.SetPixel(i, j, Color.FromArgb((int)LUT[pixel.R], (int)LUT[pixel.G], (int)LUT[pixel.B]));
                }

            UsersImage.saveEditedImage(imageToEdit);
        }

        private void makeLUTArray()
        {
            double contrastCorrectionFactor = (259 * (contrastValue + 255)) / (255 * (259 - contrastValue));

            this.LUT = new List<double>();

            double newContrastedPixel = 0;

            for(int i = 0; i < 256; ++i)
            {
                newContrastedPixel = contrastCorrectionFactor * ((i - 128) + 128);

                if (newContrastedPixel > 255) //lambda??
                    newContrastedPixel = 255;
                else if (newContrastedPixel < 0)
                    newContrastedPixel = 0;

                LUT.Add(newContrastedPixel);
                
            }
        }
    }

    class HistogramStretchingEffect : IEditImage
    {
        private List<double> LUT_R;
        private List<double> LUT_G;
        private List<double> LUT_B;

        private const int maxRGBValue = 255;
        
        public void editImage(Bitmap imageToEdit)
        {
            Color pixel;

            findMinMaxValuesOfComponentsInImage(imageToEdit, out int minRValue, out int maxRValue, out int minGValue, out int maxGValue, out int minBValue, out int maxBValue);              

            this.LUT_R = makeLUTArray(minRValue, maxRValue);
            this.LUT_G = makeLUTArray(minGValue, maxGValue);
            this.LUT_B = makeLUTArray(minBValue, maxBValue);

            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    imageToEdit.SetPixel(i, j, Color.FromArgb((int)LUT_R[pixel.R], (int)LUT_G[pixel.G], (int)LUT_B[pixel.B]));
                }

            UsersImage.saveEditedImage(imageToEdit);
        }

        private void findMinMaxValuesOfComponentsInImage(Bitmap imageToAnalyze, out int minRValue, out int maxRValue, out int minGValue, out int maxGValue, out int minBValue, out int maxBValue)
        {
            Color pixel;

            minRValue = 255;
            maxRValue = 0;

            minGValue = 255;
            maxGValue = 0;

            minBValue = 255;
            maxBValue = 0;

            for (int i = 0; i < imageToAnalyze.Width; ++i)
                for (int j = 0; j < imageToAnalyze.Height; ++j)
                {
                    pixel = imageToAnalyze.GetPixel(i, j);

                    if (pixel.R > maxRValue)
                        maxRValue = pixel.R;
                    if (pixel.R < minRValue)
                        minRValue = pixel.R;

                    if (pixel.G > maxGValue)
                        maxGValue = pixel.G;
                    if (pixel.G < minGValue)
                        minGValue = pixel.G;

                    if (pixel.B > maxBValue)
                        maxBValue = pixel.B;
                    if (pixel.B < minBValue)
                        minBValue = pixel.B;
                }
        }
        private List<double> makeLUTArray(int minComponentValue, int maxComponentValue)
        {
            List<double> LUTArray = new List<double>();

            double newStretchedPixel;

            for(int i = 0; i < 256; ++i)
            {
                newStretchedPixel = (maxRGBValue / (maxComponentValue - minComponentValue)) * (i - minComponentValue);

                if (newStretchedPixel > 255)
                    newStretchedPixel = 255;
                if (newStretchedPixel < 0)
                    newStretchedPixel = 0;

                LUTArray.Add(newStretchedPixel);
            }

            return LUTArray;
        }
    }
}
