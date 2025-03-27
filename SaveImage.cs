using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing;

public class SaveImage
{
    
    public enum ThresholdingType
    {
        Static,
        Mean,
    }
    
    public void SavingImage(string userImage, ThresholdingType thresholdingType)
    {
        try
        {
            Bitmap inputImage = new Bitmap(userImage);
            Thresholding thresholdingAlgorithm = CreateThresholdingAndSave(thresholdingType, inputImage, 127);
            
            thresholdingAlgorithm.execute(inputImage);

            string outputImageFileName = $"output_{thresholdingType}.jpg";
            string outputImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, outputImageFileName);
            inputImage.Save(outputImagePath, ImageFormat.Jpeg);

            Console.WriteLine("Threshold applied successfully. Processed image saved as " + outputImagePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.ToString());
        }
    }
        
         static Thresholding CreateThresholdingAndSave(ThresholdingType type, Bitmap image, int staticThresholdValue)
         {
             Thresholding thresholdingAlgorithm;
            switch (type)
            {
                case ThresholdingType.Static:
                    thresholdingAlgorithm = new StaticThresholding(staticThresholdValue);
                    break;
                case ThresholdingType.Mean:
                    thresholdingAlgorithm = new MeanThresholding(image);
                    break;
                default:
                    throw new ArgumentException("Invalid thresholding type");
            }
        
            thresholdingAlgorithm.execute(image); 
            return thresholdingAlgorithm;
        }
        
        
  

    }
   
   
    
    


