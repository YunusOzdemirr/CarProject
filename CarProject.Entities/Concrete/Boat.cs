using System;
using System.Collections.Generic;

namespace CarProject.Entities.Concrete
{
    public class Boat : Vehicle
    {
        IEnumerable<VehiclePicture> BoatPictures { get; set; }
    }
}

