using System;
using System.Collections.Generic;

namespace CarProject.Entities.Concrete
{
    public class Brand
    {
        public string Name { get; set; }
        IEnumerable<BrandPicture> BrandPictures { get; set; }

    }
}

