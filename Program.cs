

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write your Image path:");

           String UserImage = Console.ReadLine();
           
           Console.WriteLine("What Binarization Type you want? \n\nEnter static for Static Thresholding \nEnter mean for Mean Thresholding");
           string thresholdingTypeString = Console.ReadLine();
           

           if (Enum.TryParse(typeof(SaveImage.ThresholdingType), thresholdingTypeString, true, out object thresholdingTypeObj))
           {
               SaveImage.ThresholdingType thresholdingType = (SaveImage.ThresholdingType)thresholdingTypeObj;
                
               SaveImage obj = new SaveImage();
               obj.SavingImage(UserImage, thresholdingType);
           }
           else
           {
               Console.WriteLine("Invalid Thresholding Type entered.");
           }
        }
    }
}
