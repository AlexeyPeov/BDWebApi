using System.ComponentModel.DataAnnotations;
namespace WebBirthdayApp.Validators;
public class ImageValidatorAttribute : ValidationAttribute
{
    public static readonly int MaxImageSizeInBytes = 1024 * 1024 / 2; // 0.5mb

    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value == null)
            return new ValidationResult("Image is empty");

        byte[] fileBytes;
        if (value is IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            fileBytes = ms.ToArray();
        }
        else if (value is byte[] bytes)
        {
            fileBytes = bytes;
        }
        else
        {
            return new ValidationResult("Invalid file format");
        }

        if (fileBytes.Length > MaxImageSizeInBytes)
            return new ValidationResult($"Image is too large, should be less than {MaxImageSizeInBytes / 1024} kb");

        if (fileBytes.Length < 1024) 
            return new ValidationResult("Image is too small");

        var jpegHeader = new byte[] { 0xFF, 0xD8 };
        var pngHeader = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

        if (fileBytes.Take(2).SequenceEqual(jpegHeader))
            return ValidationResult.Success;

        if (fileBytes.Take(pngHeader.Length).SequenceEqual(pngHeader))
            return ValidationResult.Success;

        return new ValidationResult("Invalid file type. Only jpg, jpeg, and png are supported");   
    }


}