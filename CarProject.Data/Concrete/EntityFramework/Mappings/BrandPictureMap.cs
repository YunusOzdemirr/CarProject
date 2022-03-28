using System;
using CarProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarProject.Data.Concrete.EntityFramework.Mappings
{
    public class BrandPictureMap : IEntityTypeConfiguration<BrandPicture>
    {
        public void Configure(EntityTypeBuilder<BrandPicture> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne<Brand>(a => a.Brand).WithMany(b => b.BrandPictures).HasForeignKey(a => a.BrandId);
            builder.ToTable("BrandPictures");
        }
    }
}

