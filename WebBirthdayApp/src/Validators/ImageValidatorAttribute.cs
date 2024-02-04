using System.ComponentModel.DataAnnotations;

namespace WebBirthdayApp.Validators;
public class ImageValidatorAttribute : ValidationAttribute
{
    public static readonly int MaxImageSizeInBytes = 1024 * 1024 * 4; // 4mb
    public static readonly int OneMb = 1024 * 1024;
    
    
    private static readonly byte[] JpegHeader = [0xFF, 0xD8];
    
    private static readonly byte[] PngHeader = 
        [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];


    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value == null)
            return ValidationResult.Success;
        
        if (value is not IFormFile file)
            return new ValidationResult("Invalid file format");

        var fileBytes = new byte[10];
        long size = file.Length;
        using var stream = file.OpenReadStream();
        _ = stream.Read(fileBytes, 0, 10);
        
        if (size > MaxImageSizeInBytes)
            return new ValidationResult($"Image is too large, should be less than {MaxImageSizeInBytes / OneMb} mb");

        if (size < 1024) 
            return new ValidationResult("Image is too small");

        bool isJpg = fileBytes.Take(2).SequenceEqual(JpegHeader);
        bool isPng = fileBytes.Take(PngHeader.Length).SequenceEqual(PngHeader);
        
        if (isJpg || isPng)
            return ValidationResult.Success;

        return new ValidationResult("Invalid file type. Only jpg, jpeg, and png are supported");   
    }
}