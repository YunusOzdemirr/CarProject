using System;
using System.Collections.Generic;

namespace CarProject.Entities.Concrete
{
    public class Bus : Vehicle
    {
        public string Wheels { get; set; }
        public string Headlight { get; set; }
        IEnumerable<VehiclePicture> BusPictures { get; set; }
    }
}

