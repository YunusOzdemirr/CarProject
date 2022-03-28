using System;
using System.Collections.Generic;

namespace CarProject.Entities.Concrete
{
    public class Car : Vehicle
    {
        public string Wheels { get; set; }
        public string Headlights { get; set; }
        IEnumerable<VehiclePicture> CarPictures { get; set; }
    }
}

