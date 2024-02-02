using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebBirthdayApp.Validators;

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
        if (f.Length == 0)
            return;
        using var ms = new MemoryStream();
        f.CopyTo(ms);
        Bytes = ms.ToArray();
    }
    
    public void SetFromFile(IFormFile f)
    {
        if (f.Length == 0)
            return;
        using var ms = new MemoryStream();
        f.CopyTo(ms);
        Bytes = ms.ToArray();
    }

}