using System.Drawing;
using System.Drawing.Imaging;
namespace ImageProcessing;

public abstract class Thresholding
{
    
  public Bitmap GrayImage { get; set; }

    private double threshold {
  get;
  set;
 }
 


 protected Bitmap ApplyThreshold(Bitmap grayImage,double threshold)
 {
  
     int width = grayImage.Width;

     int height = grayImage.Height;
        
     BitmapData bmData = grayImage.LockBits(new Rectangle(0, 0, width, height),
         ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

     Bitmap grayImageApplyThreshold = (Bitmap) grayImage.Clone();


     BitmapData nmData = grayImageApplyThreshold.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite,
         PixelFormat.Format8bppIndexed);
     
     int stride = nmData.Stride;
        
     IntPtr Scan0 = nmData.Scan0;
        
     unsafe
     {
         byte* p = (byte*)(void*)Scan0;
         int nOffset = stride - width;
         for (int y = 0; y < height; ++y)
         {
             for (int x = 0; x < width; ++x)
             {
                 if (p[0] > threshold)
                 {
                     p[0] = 0;
                 }
                 else
                 {
                     p[0] = 255;
                 }
                
                 ++p;

             }
               
             p += nOffset;
         }
     }
     
     grayImage.UnlockBits(bmData);

     grayImageApplyThreshold.UnlockBits(nmData);

     return grayImageApplyThreshold;
 }

 protected abstract double getThreshold();
 
 public Bitmap execute(Bitmap grayImage)
 {
   threshold = getThreshold();
   return ApplyThreshold(grayImage, threshold);
 }

}







