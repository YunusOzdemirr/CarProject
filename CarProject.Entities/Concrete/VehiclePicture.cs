using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class VehiclePicture : EntityBase<int>, IEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public int BoatId { get; set; }
        public Boat Boat { get; set; }
        public byte[] File { get; set; }
    }
}

