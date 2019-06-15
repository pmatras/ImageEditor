using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        private List<int> graynessRPixels;
        private List<int> graynessGPixels;
        private List<int> graynessBPixels;
        public void editImage(Bitmap imageToEdit)
        {
            makeGraynessPixelsLists(); 

            Color pixel;

            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    int newPixelValue = graynessRPixels[pixel.R] + graynessGPixels[pixel.G] + graynessBPixels[pixel.B];
                                                           
                    imageToEdit.SetPixel(i, j, Color.FromArgb(newPixelValue, newPixelValue, newPixelValue));
                    
                }

            UsersImage.saveEditedImage(imageToEdit);
        }

        private void makeGraynessPixelsLists()
        {
            this.graynessRPixels = new List<int>();
            this.graynessGPixels = new List<int>();
            this.graynessBPixels = new List<int>();

            for(int i = 0; i < 256; ++i)
            {
                graynessRPixels.Add((int)(0.299 * i));
                graynessGPixels.Add((int)(0.587 * i));
                graynessBPixels.Add((int)(0.114 * i));
            }

        }
    }

    class InvertColorsEffect : IEditImage
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

                    imageToEdit.SetPixel(i, j, Color.FromArgb(NegativePixelR, NegativePixelG, NegativePixelB));
                }

            UsersImage.saveEditedImage(imageToEdit);
        }
    }

    class SepiaEffect : IEditImage
    {
        private const int maxRGBValue = 255;        
        public void editImage(Bitmap imageToEdit)
        {
            Color pixel;

            int SepiaPixelR = 0;
            int SepiaPixelG = 0;
            int SepiaPixelB = 0;

            for (int i = 0; i < imageToEdit.Width; ++i)
                for (int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);

                    SepiaPixelR = (int)(0.393 * pixel.R + 0.769 * pixel.G + 0.189 * pixel.B);
                    SepiaPixelG = (int)(0.349 * pixel.R + 0.686 * pixel.G + 0.168 * pixel.B);
                    SepiaPixelB = (int)(0.272 * pixel.R + 0.534 * pixel.G + 0.131 * pixel.B);

                    if (SepiaPixelR > maxRGBValue)
                        SepiaPixelR = maxRGBValue;

                    if (SepiaPixelG > maxRGBValue)
                        SepiaPixelG = maxRGBValue;

                    if (SepiaPixelB > maxRGBValue)
                        SepiaPixelB = maxRGBValue;

                    imageToEdit.SetPixel(i, j, Color.FromArgb(SepiaPixelR, SepiaPixelG, SepiaPixelB));
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

        private const int maxRGBValue = 255;
        private const int minRGBValue = 0;
        private List<int> brightenPixels;
                
        public void editImage(Bitmap imageToEdit)
        {
            makeBrightenPixelsList();

            Color pixel;

            for (int i = 0; i < imageToEdit.Width; ++i)
                for (int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);
                                     
                    imageToEdit.SetPixel(i, j, Color.FromArgb(brightenPixels[pixel.R], brightenPixels[pixel.G], brightenPixels[pixel.B]));
                }
            UsersImage.saveEditedImage(imageToEdit);
        }

        private void makeBrightenPixelsList()
        {
            this.brightenPixels = new List<int>();
            
            int brightenPixel = 0;

            for(int i = 0; i < 256; ++i)
            {
                brightenPixel = i + brightnessValue;

                if (brightenPixel > maxRGBValue)
                    brightenPixel = maxRGBValue;

                if (brightenPixel < minRGBValue)
                    brightenPixel = minRGBValue;

                brightenPixels.Add(brightenPixel);

            }
        }        
        }

    class ColorEffect : IEditImage
    {        
        private static int colorOption;
        public static void setColorOption(int _colorOption)
        {
            colorOption = _colorOption;
        }

        private const int maxRGBValue = 255;
        private const int minRGBValue = 0;
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

                    switch(colorOption)
                    {
                        case (int)colors.Red:
                            {
                                ColoredPixelR = pixel.R;
                                ColoredPixelG = pixel.G - maxRGBValue;
                                ColoredPixelB = pixel.B - maxRGBValue;

                                break;
                            }
                        case (int)colors.Green:
                            {
                                ColoredPixelR = pixel.R - maxRGBValue;
                                ColoredPixelG = pixel.G;
                                ColoredPixelB = pixel.B - maxRGBValue;

                                break;
                            }
                        case (int)colors.Blue:
                            {
                                ColoredPixelR = pixel.R - maxRGBValue;
                                ColoredPixelG = pixel.G - maxRGBValue;
                                ColoredPixelB = pixel.B;

                                break;
                            }                     
                    }
                    
                    ColoredPixelR = Math.Max(ColoredPixelR, minRGBValue);
                    ColoredPixelR = Math.Min(maxRGBValue, ColoredPixelR);

                    ColoredPixelG = Math.Max(ColoredPixelG, minRGBValue);
                    ColoredPixelG = Math.Min(maxRGBValue, ColoredPixelG);

                    ColoredPixelB = Math.Max(ColoredPixelB, minRGBValue);
                    ColoredPixelB = Math.Min(maxRGBValue, ColoredPixelB);

                    imageToEdit.SetPixel(i, j, Color.FromArgb(ColoredPixelR, ColoredPixelG, ColoredPixelB));
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
        private const int bitsInByte = 8;
        private int threadsCount;

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
            var rectangle = new Rectangle(0, 0, imageToEdit.Width, imageToEdit.Height);
            var data = imageToEdit.LockBits(rectangle, System.Drawing.Imaging.ImageLockMode.ReadWrite, imageToEdit.PixelFormat);
            var depth = Bitmap.GetPixelFormatSize(data.PixelFormat) / bitsInByte;

            var buffer = new byte[data.Width * data.Height * depth];

            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
             
            this.threadsCount = 2;
            Thread GaussianBlurThread1 = new Thread(() => processImage(buffer, offset, offset, imageToEdit.Width - offset, imageToEdit.Height / threadsCount, imageToEdit.Width, depth));
            Thread GaussianBlurThread2 = new Thread(() => processImage(buffer, offset, imageToEdit.Height / threadsCount, imageToEdit.Width - offset, imageToEdit.Height - offset, imageToEdit.Width, depth));

            GaussianBlurThread1.Start();
            GaussianBlurThread2.Start();
            GaussianBlurThread1.Join();
            GaussianBlurThread2.Join();

            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
            imageToEdit.UnlockBits(data);
                      

            UsersImage.saveEditedImage(imageToEdit);
        } 
        
        private void processImage(byte[] pixelsBuffer, int startX, int startY, int endX, int endY, int width, int depth)
        {
            int sumOfNeighborsR = 0;
            int sumOfNeighborsG = 0;
            int sumOfNeighborsB = 0;

            int filterIteratorX = 0;
            int filterIteratorY = 0;

            for (int i = startX; i < endX; ++i)
            {
                for (int j = startY; j < endY; ++j)
                {

                    for (int k = i - offset; k <= i + offset; ++k)
                    {
                        for (int l = j - offset; l <= j + offset; ++l)
                        {
                            int index = ((l * width) + k) * depth;

                            sumOfNeighborsR += pixelsBuffer[index] * GaussFilterArray[filterIteratorX, filterIteratorY];
                            sumOfNeighborsG += pixelsBuffer[index + 1] * GaussFilterArray[filterIteratorX, filterIteratorY];
                            sumOfNeighborsB += pixelsBuffer[index + 2] * GaussFilterArray[filterIteratorX, filterIteratorY++];
                        }
                        ++filterIteratorX;
                        filterIteratorY = 0;
                    }

                    int indexToSet = ((j * width) + i) * depth;

                    pixelsBuffer[indexToSet] = (byte) (sumOfNeighborsR / filterWeightsSum);
                    pixelsBuffer[indexToSet + 1] = (byte)(sumOfNeighborsG / filterWeightsSum);
                    pixelsBuffer[indexToSet + 2] = (byte)(sumOfNeighborsB / filterWeightsSum);
                    
                    sumOfNeighborsR = 0;
                    sumOfNeighborsG = 0;
                    sumOfNeighborsB = 0;
                    filterIteratorX = 0;
                    filterIteratorY = 0;

                }

            }

        }
        
    }

    class GammaCorrectionEffect : IEditImage 
    {
        private static double gammaValue; 
        public static void setGammaValue(double value)
        {
            gammaValue = value;
        }

        private List<int> pixelsAfterGammaCorrection;
        private const int maxRGBValue = 255;
        private const int minRGBValue = 0;
        public void editImage(Bitmap imageToEdit)
        {
            makeGammaPixelsList();
            
            Color pixel;

            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);
                    
                    imageToEdit.SetPixel(i, j, Color.FromArgb(pixelsAfterGammaCorrection[pixel.R], pixelsAfterGammaCorrection[pixel.G], pixelsAfterGammaCorrection[pixel.B]));
                }

            UsersImage.saveEditedImage(imageToEdit);

        }

        private void makeGammaPixelsList()
        {
            this.pixelsAfterGammaCorrection = new List<int>();

            double pixelAfterGammaCorrection = 0;

            for(int i = 0; i < 256; ++i)
            {
                pixelAfterGammaCorrection = maxRGBValue * Math.Pow(i / (double)maxRGBValue, 1.0 / gammaValue);
                pixelAfterGammaCorrection = Math.Max(pixelAfterGammaCorrection, minRGBValue);
                pixelAfterGammaCorrection = Math.Min(maxRGBValue, pixelAfterGammaCorrection);

                pixelsAfterGammaCorrection.Add((int)pixelAfterGammaCorrection);
            }           
        }
    }

    class ChangeExposureEffect : IEditImage
    {
        private const int maxRGBValue = 255;
        private static double exposureCorrectnessRatio;
        
        public static void setExposureCorrectnessRatio(double value)
        {
            exposureCorrectnessRatio = value;
        }

        private List<int> LUT;
        public void editImage(Bitmap imageToEdit)
        {
            makeLUTArray();

            Color pixel;
            
            for(int i = 0; i < imageToEdit.Width; ++i)
                for(int j = 0; j < imageToEdit.Height; ++j)
                {
                    pixel = imageToEdit.GetPixel(i, j);
                    
                    imageToEdit.SetPixel(i, j, Color.FromArgb(LUT[pixel.R], LUT[pixel.G], LUT[pixel.B]));
                }

            UsersImage.saveEditedImage(imageToEdit);
            
        }

        private void makeLUTArray()
        {
            this.LUT = new List<int>();

            double newPixelValue = 0;

            for(int i = 0; i < 256; ++i)
            {
                newPixelValue = exposureCorrectnessRatio * i;

                if (newPixelValue < maxRGBValue)
                {
                    LUT.Add((int)newPixelValue);
                }
                else
                {
                    LUT.Add(maxRGBValue);
                }
            }

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
