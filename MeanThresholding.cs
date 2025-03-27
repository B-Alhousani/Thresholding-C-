using System.Runtime.CompilerServices;
using System.Transactions;

namespace ImageProcessing;
using System.Drawing;
using System.Drawing.Imaging;
public class MeanThresholding : Thresholding
{
    
    
    public  MeanThresholding(Bitmap grayImage)
    {
        this.GrayImage = grayImage;
    }
    
    protected  override double getThreshold()
    {
        return Meanpixels(GrayImage);
    }

    public double Meanpixels(Bitmap grayImage)
    { 
        double PixelsMean = 0;
        
        double PixelsSum = 0;

        int ImageWidth = grayImage.Width;

        int ImageHeight = grayImage.Height;
        
        double PixelsNumber = ImageWidth * ImageHeight;
        
        BitmapData bmData = grayImage.LockBits(new Rectangle(0, 0, grayImage.Width, grayImage.Height),
            ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
        
        int stride = bmData.Stride;
        IntPtr Scan0 = bmData.Scan0;
        
        unsafe
        {
            byte* p = (byte*)(void*)Scan0;
            int nOffset = stride - ImageWidth;
            for (int y = 0; y < ImageHeight; ++y)
            {
                for (int x = 0; x < ImageWidth; ++x)
                {
                    PixelsSum += p[0];
                

                    ++p;

                }
               
                p += nOffset;
            }
        }

        PixelsMean = PixelsSum/PixelsNumber;
        
        grayImage.UnlockBits(bmData);
        
        return PixelsMean;

    }
    
    
}