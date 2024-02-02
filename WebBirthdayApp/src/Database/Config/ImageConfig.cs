using WebBirthdayApp.Models;
using WebBirthdayApp.Validators;

namespace WebBirthdayApp.Database.Config;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ImageConfig : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Image");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).UseIdentityColumn();

        builder.Property(i => i.Bytes)
            .IsRequired()
            .HasMaxLength(ImageValidatorAttribute.MaxImageSizeInBytes);
    }
}