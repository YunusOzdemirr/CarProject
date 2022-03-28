using System;
using CarProject.Data.Concrete.EntityFramework.Mappings;
using CarProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Data.Concrete.EntityFramework.DatabaseContext
{
    public class Context : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        //public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<VehiclePicture> VehiclePictures { get; set; }
        public DbSet<BrandPicture> BrandPictures { get; set; }
        public DbSet<UserPicture> UserPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new BoatMap());
            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new BrandPictureMap());
            modelBuilder.ApplyConfiguration(new BusMap());
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserPictureMap());
            modelBuilder.ApplyConfiguration(new VehiclePictureMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost;Database=CarProject;User=sa;Password=Password123@jkl#;");
        }
    }
}

