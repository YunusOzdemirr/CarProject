using System;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class VehiclePicture : EntityBase<int>, IEntity
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public byte[] File { get; set; }
    }
}

