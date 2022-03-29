using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class Boat : Vehicle, IEntity
    {
        public ICollection<VehiclePicture> BoatPictures { get; set; }
    }
}

