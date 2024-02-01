using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebBirthdayApp.Models;

public class Person
{
    [ValidateNever]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; init; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = "";
    [Required]
    [StringLength(50)]
    public string SecondName { get; set; } = "";
    [StringLength(50)]
    public string? Patronymic { get; set; }
    public DateOnly Birthday { get; set; }

    public Person(){}
    public static Person CreateCopyNoId(Person p)
    {
        return new Person()
        {
            Name = p.Name,
            SecondName = p.SecondName,
            Patronymic = p.Patronymic,
            Birthday = p.Birthday,
        };
    }

    public static void CopyPerson(in Person from, ref Person to)
    {
        to.Name = from.Name;
        to.SecondName = from.SecondName;
        to.Patronymic = from.Patronymic;
        to.Birthday = from.Birthday;
    }
}