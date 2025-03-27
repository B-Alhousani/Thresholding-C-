namespace ImageProcessing;
using System.Drawing;
using System.Drawing.Imaging;

public class StaticThresholding :Thresholding
{
    private int thresholdValue;

    
    public StaticThresholding(int thresholdValue)
    {
        
        this.thresholdValue = thresholdValue;
    }
 
 protected  override double  getThreshold()
    {
        return thresholdValue;
    }
 
}
    
