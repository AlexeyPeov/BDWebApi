using System.ComponentModel.DataAnnotations;
namespace WebBirthdayApp.Validators;
public class JpegValidatorAttribute : ValidationAttribute
{
    public static readonly int MaxImageSizeInBytes = 1024 * 1024 / 2; // 0.5mb

    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value == null)
            return new ValidationResult("Image is empty");

        if (value is not byte[] bytes)
            return new ValidationResult("Not a Jpeg");

        if (bytes.Length > MaxImageSizeInBytes)
            return new ValidationResult($"Image is too large, should be less than {MaxImageSizeInBytes / 1024} kb");

        if (bytes.Length < 1024) 
            return new ValidationResult("Image is too small, probably not a Jpeg");

        if (bytes[0] != 0xFF || bytes[1] != 0xD8)
            return new ValidationResult("Not a Jpeg");   

        return ValidationResult.Success;
    }
}