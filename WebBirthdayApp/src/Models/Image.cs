using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
namespace WebBirthdayApp.Models;

public class Image
{
    [ValidateNever]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; init; }
    public byte[] Bytes { get; set; } = Array.Empty<byte>();

    public Image(){}
    
    public Image(IFormFile f)
    {
        SetFromFile(f);
    }
    
    public void SetFromFile(IFormFile f)
    {
        if (f.Length == 0)
            return;

        using var ms = new MemoryStream();
        
        f.CopyTo(ms);

        using var image = SixLabors.ImageSharp.Image.Load(ms.ToArray());
        ms.Position = 0;
        
        int minDim = Math.Min(image.Width, image.Height);
        int xOffset = image.Width - minDim;
        int yOffset = image.Height - minDim;
        
        var cropArea = new Rectangle(xOffset / 2, yOffset / 2, minDim, minDim);
        
        image.Mutate(img => img.Crop(cropArea).Resize(200, 200));
        
        image.SaveAsJpeg(ms);
        
        Bytes = ms.ToArray();
    }


}