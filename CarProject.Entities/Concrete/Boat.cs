using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class Boat : Vehicle, IEntity
    {
        IEnumerable<VehiclePicture> BoatPictures { get; set; }
    }
}

