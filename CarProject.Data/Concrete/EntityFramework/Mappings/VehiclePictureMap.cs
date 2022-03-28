using System;
using CarProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarProject.Data.Concrete.EntityFramework.Mappings
{
    public class VehiclePictureMap : IEntityTypeConfiguration<VehiclePicture>
    {
        public void Configure(EntityTypeBuilder<VehiclePicture> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();


            //builder.HasOne<User>(un => un.User).WithMany(u => u.UserNotifications).HasForeignKey(un => un.UserId);

            builder.HasOne<Bus>(a => a.Bus).WithMany(b => b.BusPictures).HasForeignKey(a => a.BusId);
            builder.HasOne<Car>(a => a.Car).WithMany(b => b.CarPictures).HasForeignKey(a => a.CarId);
            builder.HasOne<Boat>(a => a.Boat).WithMany(b => b.BoatPictures).HasForeignKey(a => a.BoatId);
            builder.ToTable("VehiclePictures");
        }
    }
}

