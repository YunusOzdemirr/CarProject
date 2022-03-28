using System;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class BrandPicture : EntityBase<int>, IEntity
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public byte[] File { get; set; }
    }
}
