using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebBirthdayApp.Validators;

namespace WebBirthdayApp.Models;

public class Person
{
    [ValidateNever]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; init; }

    [Required] [StringLength(50)] public string Name { get; set; } = "";
    [Required] [StringLength(50)] public string SecondName { get; set; } = "";
    [StringLength(50)] public string? Patronymic { get; set; }
    public DateOnly Birthday { get; set; }
    public int? ImgId { get; set; }
    public virtual Image? Img { get; set; }

    public void CopyFromFrontend(FrontendPersonCreationRequest from)
    {
        Name = from.Name;
        SecondName = from.SecondName;
        Patronymic = from.Patronymic;
        Birthday = from.Birthday;
    }
}