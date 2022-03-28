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
            throw new NotImplementedException();
        }
    }
}

