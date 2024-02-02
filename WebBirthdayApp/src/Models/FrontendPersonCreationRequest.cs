using System.ComponentModel.DataAnnotations;
using WebBirthdayApp.Validators;

namespace WebBirthdayApp.Models;

public class FrontendPersonCreationRequest
{
    [Required] [StringLength(50)] public string Name { get; set; } = "";
    [Required] [StringLength(50)] public string SecondName { get; set;} = "";
    [StringLength(50)] public string? Patronymic { get; set;}
    [Required] public DateOnly Birthday { get; set;}
    [ImageValidator]
    public IFormFile? Img { get; set;}
}