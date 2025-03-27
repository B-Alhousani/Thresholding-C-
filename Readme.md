# Image Thresholding (Binarization) Tool in C#

This C# console application applies two types of thresholding (binarization) to grayscale images: **static thresholding** and **mean thresholding**. It processes 8-bit grayscale images and saves the binarized output.

## Features

- Supports two binarization methods:
  - **Static Thresholding**: Uses a fixed threshold value (127).
  - **Mean Thresholding**: Automatically calculates the mean pixel value of the image.
- Efficient pixel processing using unsafe code blocks
- Processes and saves the output as `.jpg` images

## Project Structure

- `Program.cs`  
  Main entry point. Interacts with the user and applies the selected thresholding method.

- `SaveImage.cs`  
  Manages input and output, delegates thresholding execution.

- `Thresholding.cs`  
  Abstract base class providing core logic for thresholding operations.

- `StaticThresholding.cs`  
  Implements fixed-threshold binarization.

- `MeanThresholding.cs`  
  Implements adaptive binarization using the mean of pixel intensities.

## How to Run

1. Open the project in Visual Studio or any C# IDE.
2. Build and run the project.
3. You will be prompted to:
   - Enter the full path to your image
   - Choose thresholding type: `static` or `mean`

4. Output will be saved in the executable directory as:
   - `output_Static.jpg` or
   - `output_Mean.jpg`

## Notes

- Input image must be 8-bit grayscale (`PixelFormat.Format8bppIndexed`)
- Thresholding turns pixel values into binary:
  - White (255) or Black (0) based on the selected threshold

## Example

```
Write your Image path:
/path/to/image.bmp

What Binarization Type you want?

Enter static for Static Thresholding
Enter mean for Mean Thresholding
mean

Threshold applied successfully. Processed image saved as /your/project/output_Mean.jpg
```
