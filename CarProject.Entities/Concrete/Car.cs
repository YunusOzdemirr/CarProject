using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class Car : Vehicle, IEntity
    {
        public int Wheels { get; set; }
        public string Headlights { get; set; }
        public ICollection<VehiclePicture> CarPictures { get; set; }
    }
}

