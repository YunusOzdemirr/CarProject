using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class Brand : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        IEnumerable<BrandPicture> BrandPictures { get; set; }

    }
}

