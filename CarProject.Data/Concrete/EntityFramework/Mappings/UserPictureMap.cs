using System;
using CarProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarProject.Data.Concrete.EntityFramework.Mappings
{
    public class UserPictureMap : IEntityTypeConfiguration<UserPicture>
    {
        public void Configure(EntityTypeBuilder<UserPicture> builder)
        {
            builder.HasKey(userPicture => userPicture.Id);
            builder.Property(userPicture => userPicture.Id).ValueGeneratedOnAdd();
            builder.Property(userPicture => userPicture.File).IsRequired();
            builder.Property(userPicture => userPicture.File).HasColumnType("VARBINARY(MAX)");

            builder.Property(userPicture => userPicture.IsDeleted).IsRequired();
            builder.Property(userPicture => userPicture.IsActive).IsRequired();
            builder.Property(userPicture => userPicture.CreatedDate).IsRequired(false);
            builder.Property(userPicture => userPicture.CreatedByUserId).IsRequired(false);
            builder.Property(userPicture => userPicture.ModifiedDate).IsRequired(false);
            builder.Property(userPicture => userPicture.ModifiedByUserId).IsRequired(false);

            builder.HasOne<User>(up => up.User).WithMany(user => user.UserPictures)
               .HasForeignKey(up => up.UserId);
            builder.ToTable("UserPictures");
        }
    }
}

