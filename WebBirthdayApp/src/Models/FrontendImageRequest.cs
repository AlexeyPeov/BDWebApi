using WebBirthdayApp.Validators;

namespace WebBirthdayApp.Models;

public class FrontendImageRequest
{
    [ImageValidator]
    public IFormFile? Img { get; set;}
}