using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class Bus : Vehicle, IEntity
    {
        public string Wheels { get; set; }
        public string Headlights { get; set; }
        public ICollection<VehiclePicture> BusPictures { get; set; }
    }
}

