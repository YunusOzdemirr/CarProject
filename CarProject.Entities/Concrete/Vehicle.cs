using System;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    //Vehicle is inheritance from EntityBase because have neccessary fields
    public class Vehicle : EntityBase<int>, IEntity
    {
        public string Name { get; set; }//Araç Adı
        public string Color { get; set; }//Renk
        public string Seat { get; set; }//Koltuk
    }
}

