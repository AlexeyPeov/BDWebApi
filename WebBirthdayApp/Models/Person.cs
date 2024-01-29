using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebBirthdayApp.Models;

public class Person
{
    [ValidateNever]
    public int Id { get; init; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = "";
    [Required]
    [StringLength(50)]
    public string SecondName { get; set; } = "";
    [StringLength(50)]
    public string? Patronymic { get; set; }
    public DateOnly Birthday { get; set; }
}