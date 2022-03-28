using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class Boat : Vehicle, IEntity
    {
        public int BoatPictureId { get; set; }
        public ICollection<VehiclePicture> BoatPictures { get; set; }
    }
}

